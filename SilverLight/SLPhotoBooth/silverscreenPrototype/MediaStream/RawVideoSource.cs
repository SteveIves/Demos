using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using FluxJpeg.Core;
using FluxJpeg.Core.Decoder;
using System.Diagnostics;

namespace silverscreenPrototype
{
    /// <summary>
    /// Extension of the MediaStreamSource which allows raw video and audio playback for our custom media format.
    /// This reads a simple file format which stores media metadata at the top of a file containing a sequence of video frames.
    /// The corresponding audio stream is stored uncompressed in a separate file.
    /// </summary>
    public class RawVideoSource : MediaStreamSource
    {
        const int HeaderBytes = 32;
        const int ChunkHeaderBytes = 20;

        private MediaStreamDescription m_Desc;
        private MediaStreamDescription m_AudioDesc;
        private Size m_Size;
        private long m_Duration;
        private Dictionary<MediaSampleAttributeKeys, string> m_EmptySampleDictionary = new Dictionary<MediaSampleAttributeKeys, string>();
        private string m_Filename;
        private float m_FPS;

        IsolatedStorageFile m_File;
        IsolatedStorageFileStream m_FileStream;
        MemoryStream m_BufferStream = null;
        IsolatedStorageFileStream m_AudioFileStream;
        MemoryStream m_AudioBufferStream = null;
        private long m_AudioTime = 0;

        WaveFormatEx m_WaveFormat;
        int m_BitsPerSample;
        int m_Channels;
        int m_SamplesPerSecond;
        int m_ByteRate;
        bool m_CloseNextAudio = false;

        /// <summary>
        /// Create a raw video stream source.
        /// </summary>
        /// <param name="filename">The filename in IsolatedStorage of the media file.</param>
        public RawVideoSource(string filename)
        {
            m_Filename = filename;
        }

        /// <summary>
        /// Buffered read from the audio file.
        /// This will read in the ByteCount requested but the actual read operations performed are chunked into
        /// 20.0 MB buffers.  We sacrifice memory usage in favor of performance.  This can probably be tweaked
        /// down to a lower value for the audio.
        /// </summary>
        /// <param name="ByteCount">The number of bytes to read.</param>
        /// <returns></returns>
        protected byte[] ReadAudioBytes(int ByteCount)
        {
            byte[] Data = new byte[ByteCount];

            int BytesRead = 0;

            while (BytesRead != ByteCount)
            {
                if (m_AudioBufferStream == null || m_AudioBufferStream.Position == m_AudioBufferStream.Length)
                {
                    byte[] ReadBuffer = new byte[Math.Min(m_AudioFileStream.Length - m_AudioFileStream.Position, 1024 * 1024 * 20)];

                    m_AudioFileStream.Read(ReadBuffer, 0, ReadBuffer.Length);

                    m_AudioBufferStream = new MemoryStream(ReadBuffer);
                }

                int BytesToCopy = Math.Min(ByteCount - BytesRead, (int)(m_AudioBufferStream.Length - m_AudioBufferStream.Position));

                m_AudioBufferStream.Read(Data, BytesRead, BytesToCopy);

                BytesRead += BytesToCopy;

                if (m_AudioBufferStream.Length - m_AudioBufferStream.Position == 0 && m_AudioFileStream.Position - m_AudioFileStream.Length == 0)
                {
                    break;
                }
            }

            return Data;
        }


        /// <summary>
        /// Buffered read from the video file.
        /// This will read in the ByteCount requested but the actual read operations performed are chunked into
        /// 20.0 MB buffers.  We sacrifice memory usage in favor of performance.
        /// </summary>
        /// <param name="ByteCount">The number of bytes to read.</param>
        /// <returns></returns>
        protected byte[] ReadBytes(int ByteCount)
        {
            byte[] Data = new byte[ByteCount];

            int BytesRead = 0;

            while (BytesRead != ByteCount)
            {
                if (m_BufferStream == null || m_BufferStream.Position == m_BufferStream.Length)
                {
                    byte[] ReadBuffer = new byte[Math.Min(m_FileStream.Length - m_FileStream.Position, 1024 * 1024 * 20)];

                    m_FileStream.Read(ReadBuffer, 0, ReadBuffer.Length);

                    m_BufferStream = new MemoryStream(ReadBuffer);
                }

                int BytesToCopy = Math.Min(ByteCount - BytesRead, (int)(m_BufferStream.Length - m_BufferStream.Position));

                m_BufferStream.Read(Data, BytesRead, BytesToCopy);

                BytesRead += BytesToCopy;

                if (m_BufferStream.Length - m_BufferStream.Position == 0 && m_FileStream.Position - m_FileStream.Length == 0)
                {
                    break;
                }
            }

            return Data;
        }

        protected int AudioReadInt()
        {
            return BitConverter.ToInt32(ReadAudioBytes(sizeof(int)), 0);
        }

        protected float AudioReadFloat()
        {
            return BitConverter.ToSingle(ReadAudioBytes(sizeof(float)), 0);
        }

        protected long AudioReadLong()
        {
            return BitConverter.ToInt64(ReadAudioBytes(sizeof(long)), 0);
        }

        protected int ReadInt()
        {
            return BitConverter.ToInt32(ReadBytes(sizeof(int)), 0);
        }

        protected float ReadFloat()
        {
            return BitConverter.ToSingle(ReadBytes(sizeof(float)), 0);
        }

        protected long ReadLong()
        {
            return BitConverter.ToInt64(ReadBytes(sizeof(long)), 0);
        }

        protected override void OpenMediaAsync()
        {
            // Lets open up the file.
            m_File = IsolatedStorageFile.GetUserStoreForApplication();
            m_FileStream = new IsolatedStorageFileStream(m_Filename, FileMode.Open, m_File);

            // Open the associated audio file located at "filename Audio".
            m_AudioFileStream = new IsolatedStorageFileStream(m_Filename + " Audio", FileMode.Open, m_File);

            m_Size = new Size(ReadInt(), ReadInt());
            m_FPS = ReadFloat();
            m_BitsPerSample = ReadInt();
            m_Channels = ReadInt();
            m_SamplesPerSecond = ReadInt();
            m_Duration = ReadLong();

            m_ByteRate = m_SamplesPerSecond * m_Channels * m_BitsPerSample / 8;
            m_WaveFormat = new WaveFormatEx();
            m_WaveFormat.BitsPerSample = (short)m_BitsPerSample;
            m_WaveFormat.AvgBytesPerSec = m_ByteRate;
            m_WaveFormat.Channels = (short)m_Channels;
            m_WaveFormat.BlockAlign = (short)(m_Channels * (m_BitsPerSample / 8));
            m_WaveFormat.ext = null; // ??
            m_WaveFormat.FormatTag = WaveFormatEx.FormatPCM;
            m_WaveFormat.SamplesPerSec = m_SamplesPerSecond;
            m_WaveFormat.Size = 0; // must be zero

            m_WaveFormat.ValidateWaveFormat();

            Dictionary<MediaSourceAttributesKeys, string> sourceAttributes = new Dictionary<MediaSourceAttributesKeys, string>();
            List<MediaStreamDescription> availableStreams = new List<MediaStreamDescription>();

            // Set the duration.
            sourceAttributes[MediaSourceAttributesKeys.Duration] = m_Duration.ToString(CultureInfo.InvariantCulture);
            sourceAttributes[MediaSourceAttributesKeys.CanSeek] = true.ToString();

            // Stream Description 
            Dictionary<MediaStreamAttributeKeys, string> streamAttributes = new Dictionary<MediaStreamAttributeKeys, string>();

            streamAttributes[MediaStreamAttributeKeys.VideoFourCC] = "RGBA";
            streamAttributes[MediaStreamAttributeKeys.Height] = m_Size.Height.ToString();
            streamAttributes[MediaStreamAttributeKeys.Width] = m_Size.Width.ToString();

            m_Desc = new MediaStreamDescription(MediaStreamType.Video, streamAttributes);

            Dictionary<MediaStreamAttributeKeys, string> audioStreamAttributes = new Dictionary<MediaStreamAttributeKeys, string>();
            audioStreamAttributes[MediaStreamAttributeKeys.CodecPrivateData] = m_WaveFormat.ToHexString();
            m_AudioDesc = new MediaStreamDescription(MediaStreamType.Audio, audioStreamAttributes);

            availableStreams.Add(m_Desc);
            availableStreams.Add(m_AudioDesc);

            ReportOpenMediaCompleted(sourceAttributes, availableStreams);
        }

        protected override void GetSampleAsync(MediaStreamType mediaStreamType)
        {
            if (mediaStreamType == MediaStreamType.Audio)
            {
                // We're buffering audio samples.
                if (m_File == null)
                {
                    // If we don't have a valid file, close the stream.
                    ReportGetSampleCompleted(new MediaStreamSample(
                            m_AudioDesc,
                            null,
                            0,
                            0,
                            0,
                            m_EmptySampleDictionary));
                    return;
                }

                MediaStreamSample msSamp = null;
                try
                {
                    if (m_AudioTime >= m_Duration || m_CloseNextAudio)
                    {
                        // If our last read brought us to the end of the stream, close it.
                        ReportGetSampleCompleted(new MediaStreamSample(
                            m_AudioDesc,
                            null,
                            0,
                            0,
                            0,
                            m_EmptySampleDictionary));
                        return;
                    }
                    // Buffer in the next half second of audio from the file stream.
                    double bufferSeconds = 0.5;
                    long bufferSamples = (long)(bufferSeconds * m_SamplesPerSecond * m_BitsPerSample / 8 * m_Channels);
                    if (m_AudioTime + bufferSeconds * 10000000.0 > m_Duration)
                    {
                        // Make sure we don't read past the end.
                        int overflowTime = (int)((m_AudioTime + bufferSeconds * 10000000.0) - m_Duration);
                        bufferSamples -= (int)(overflowTime / 10000000.0 * m_SamplesPerSecond * m_BitsPerSample / 8 * m_Channels);
                        m_CloseNextAudio = true;
                    }

                    // Create the stream used to report the samples and calculate the duration of this stream (we always try to get 0.5 seconds
                    // but if we're at the end of the stream we may not get exactly what we want).
                    byte[] SampleData = ReadAudioBytes((int)bufferSamples);
                    MemoryStream Stream = new MemoryStream(SampleData);
                    long duration = (long)((bufferSamples / m_Channels / (m_BitsPerSample / 8) / (double)m_SamplesPerSecond) * 10000000.0);

                    ReportGetSampleCompleted(new MediaStreamSample(
                        m_AudioDesc,
                        Stream,
                        0,
                        bufferSamples,
                        m_AudioTime,
                        duration,
                        m_EmptySampleDictionary));
                    m_AudioTime += duration;
                }
                catch (Exception ex)
                {
                    // If anything were to go wrong with our buffering, just close the stream.
                    msSamp = new MediaStreamSample(
                            m_AudioDesc,
                            null,
                            0,
                            0,
                            0,
                            m_EmptySampleDictionary);
                }
            }
            else if (mediaStreamType == MediaStreamType.Video)
            {
                // We're buffering a video frame.

                if (m_File == null)
                {
                    // If we don't have a valid file, close the stream.
                    ReportGetSampleCompleted(new MediaStreamSample(
                            m_Desc,
                            null,
                            0,
                            0,
                            0,
                            m_EmptySampleDictionary));
                    return;
                }
                // Read the header from the frame chunk.
                long sampleTime = ReadLong();
                long frameDuration = ReadLong();
                int sampleLength = ReadInt();

                MediaStreamSample msSamp = null;
                if (m_Duration == sampleTime)
                {
                    // We've reached the end of the stream, close it.
                    msSamp = new MediaStreamSample(
                        m_Desc,
                        null,
                        0,
                        0,
                        0,
                        m_EmptySampleDictionary);
                }
                else
                {
                    // Buffer the contents of this frame chunk (simply the entire framebuffer).
                    byte[] SampleData = ReadBytes(sampleLength);
                    MemoryStream Stream = new MemoryStream(SampleData);

                    msSamp = new MediaStreamSample(
                        m_Desc,
                        Stream,
                        0,
                        sampleLength,
                        sampleTime,
                        m_EmptySampleDictionary);
                }
                ReportGetSampleCompleted(msSamp);
            }
        }

        public void Close()
        {
            m_FileStream.Dispose();
            m_AudioFileStream.Dispose();
            m_File.Dispose();
            m_File = null;
        }

        protected override void CloseMedia()
        {
            m_FileStream.Dispose();
            m_AudioFileStream.Dispose();
            if (m_File != null)
            {
                m_File.Dispose();
                m_File = null;
            }
        }

        protected override void GetDiagnosticAsync(MediaStreamSourceDiagnosticKind diagnosticKind)
        {
            throw new NotImplementedException();
        }

        protected override void SwitchMediaStreamAsync(MediaStreamDescription mediaStreamDescription)
        {
            throw new NotImplementedException();
        }

        protected override void SeekAsync(long seekToTime)
        {
            if (m_File != null)
            {
                // Seek video stream to the closest frame for the requested time.
                int frameBufferSize = (int)(m_Size.Width * m_Size.Height * 4);
                double factor = seekToTime / (double)m_Duration;
                double frames = (m_FileStream.Length - HeaderBytes) / (double)(ChunkHeaderBytes + frameBufferSize);
                long frame = (long)(frames * factor);
                long idx = HeaderBytes + frame * (ChunkHeaderBytes + frameBufferSize);
                m_FileStream.Seek(idx, SeekOrigin.Begin);
                m_BufferStream = null;
                long sampleTime = ReadLong();
                m_FileStream.Seek(idx, SeekOrigin.Begin);
                m_BufferStream = null;

                // Seek audio stream to the closest sample for the requested time.
                if (m_AudioFileStream != null)
                {
                    double seconds = sampleTime / 10000000.0;
                    long sidx = (long)(seconds * m_SamplesPerSecond) * m_Channels * (m_BitsPerSample / 8);
                    m_AudioFileStream.Seek(sidx, SeekOrigin.Begin);
                    m_AudioBufferStream = null;
                    m_CloseNextAudio = false;
                    m_AudioTime = sampleTime;
                }
            }
            ReportSeekCompleted(seekToTime);
        }
    }
}
