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
using System.IO.IsolatedStorage;
using System.IO;
using System.Threading;
using FluxJpeg.Core.Encoder;
using FluxJpeg.Core;
using FluxJpeg.Core.Filtering;
using System.Diagnostics;

namespace silverscreenPrototype
{
    /// <summary>
    /// The AudioRecorder is a helper for the VideoRecorder.
    /// Its purpose is to report audio samples to the VideoRecorder.
    /// </summary>
    internal class AudioRecorder : AudioSink
    {
        VideoRecorder m_Video;
        public AudioRecorder(VideoRecorder video)
        {
            m_Video = video;
        }
        protected override void OnCaptureStarted()
        {
        }

        protected override void OnCaptureStopped()
        {
        }

        protected override void OnFormatChange(AudioFormat audioFormat)
        {
            m_Video.AudioFormat = audioFormat;
        }

        protected override void OnSamples(long sampleTime, long sampleDuration, byte[] sampleData)
        {
            m_Video.OnAudioSamples(sampleTime, sampleDuration, sampleData);
        }
    }

    /// <summary>
    /// The VideoRecorder captures video frames from the camera, audio samples from the mic, and stores them into custom format
    /// audio and video files in IsolatedStorage.  It also stores the first frame of the video file as a jpeg in IsolatedStorage
    /// which can then be found at a known relative path.
    /// </summary>
    public class VideoRecorder : VideoSink
    {
        string m_Filename;
        VideoFormat m_Format;
        AudioRecorder m_AudioRecorder;
        long m_FirstSampleTime = 0;

        #region Buffering Members
        private long m_LastSampleTime;

        IsolatedStorageFileStream m_Stream;
        MemoryStream m_StreamBuffer;

        IsolatedStorageFileStream m_AudioStream;
        MemoryStream m_AudioStreamBuffer;

        const int MemoryBufferSize = 1024 * 1024 * 10;
        #endregion

        long m_FirstAudioSampleTime = -1;
        bool m_WroteLast = true;
        long m_Offset = 0;

        public VideoRecorder()
        {
            m_AudioRecorder = new AudioRecorder(this);
        }

        protected override void OnCaptureStarted()
        {
        }

        protected override void OnCaptureStopped()
        {
        }

        public AudioFormat AudioFormat
        {
            get;
            internal set;
        }

        public string Filename
        {
            get
            {
                return m_Filename;
            }
        }

        protected override void OnFormatChange(VideoFormat videoFormat)
        {
            m_Format = videoFormat;
        }

        public bool IsRecording
        {
            get;
            set;
        }

        public string FilenameThumb
        {
            get
            {
                return Filename + " Thumb";
            }
        }

        public string AudioFilename
        {
            get
            {
                return Filename + " Audio";
            }
        }

        private bool m_CapturedThumbnail;

        public void StartRecording(CaptureSource Source)
        {
            m_WroteLast = true;
            CaptureSource = Source;
            m_AudioRecorder.CaptureSource = Source;

            m_CapturedThumbnail = false;
        }

        public void StopRecording()
        {
            IsRecording = false;

            CaptureSource = null;

            if (m_Stream != null)
            {
                if (m_StreamBuffer != null)
                {
                    if (m_StreamBuffer.Position > 0)
                    {
                        byte[] Data = new byte[m_StreamBuffer.Position];

                        m_StreamBuffer.Seek(0, SeekOrigin.Begin);
                        m_StreamBuffer.Read(Data, 0, Data.Length);

                        m_Stream.Write(Data, 0, Data.Length);
                    }

                    m_StreamBuffer = null;
                }

                byte[] ByteValue = BitConverter.GetBytes(m_LastSampleTime);

                m_Stream.Seek(24, SeekOrigin.Begin);
                m_Stream.Write(ByteValue, 0, ByteValue.Length);

                m_Stream.Flush();

                m_Stream.Dispose();
                m_Stream = null;

            }

            if (m_AudioStream != null)
            {
                if (m_AudioStreamBuffer != null)
                {
                    if (m_AudioStreamBuffer.Position > 0)
                    {
                        byte[] Data = new byte[m_AudioStreamBuffer.Position];

                        m_AudioStreamBuffer.Seek(0, SeekOrigin.Begin);
                        m_AudioStreamBuffer.Read(Data, 0, Data.Length);

                        m_AudioStream.Write(Data, 0, Data.Length);
                    }

                    m_AudioStreamBuffer = null;
                }

                m_AudioStream.Flush();
                m_AudioStream.Dispose();
                m_AudioStream = null;
            }
        }

        protected void WriteData(byte[] Data)
        {
            if (m_StreamBuffer == null)
            {
                m_StreamBuffer = new MemoryStream(MemoryBufferSize);
            }

            m_StreamBuffer.Write(Data, 0, Data.Length);

            if (m_StreamBuffer.Position > MemoryBufferSize)
            {
                if (m_Stream != null)
                {
                    m_Stream.Write(m_StreamBuffer.GetBuffer(), 0, (int)m_StreamBuffer.Position);

                    m_Stream.Flush();
                }

                m_StreamBuffer.Position = 0;
            }
        }

        protected void WriteAudioData(byte[] Data)
        {
            if (m_AudioStreamBuffer == null)
            {
                m_AudioStreamBuffer = new MemoryStream(MemoryBufferSize);
            }

            m_AudioStreamBuffer.Write(Data, 0, Data.Length);

            if (m_AudioStreamBuffer.Position > MemoryBufferSize)
            {
                if (m_AudioStream != null)
                {
                    m_AudioStream.Write(m_AudioStreamBuffer.GetBuffer(), 0, (int)m_AudioStreamBuffer.Position);

                    m_AudioStream.Flush();
                }

                m_AudioStreamBuffer.Position = 0;
            }
        }

        protected void WriteAudioData(int Value)
        {
            byte[] ByteValue = BitConverter.GetBytes(Value);

            WriteAudioData(ByteValue);
        }

        protected void WriteAudioData(long Value)
        {
            byte[] ByteValue = BitConverter.GetBytes(Value);

            WriteAudioData(ByteValue);
        }

        protected void WriteAudioData(float Value)
        {
            byte[] ByteData = BitConverter.GetBytes(Value);

            WriteAudioData(ByteData);
        }

        protected void WriteData(int Value)
        {
            byte[] ByteValue = BitConverter.GetBytes(Value);

            WriteData(ByteValue);
        }

        protected void WriteData(long Value)
        {
            byte[] ByteValue = BitConverter.GetBytes(Value);

            WriteData(ByteValue);
        }

        protected void WriteData(float Value)
        {
            byte[] ByteData = BitConverter.GetBytes(Value);

            WriteData(ByteData);
        }

        internal void OnAudioSamples(long sampleTime, long sampleDuration, byte[] sampleData)
        {
            try
            {
                if (!IsRecording && m_WroteLast)
                {
                    return;
                }
                if (m_FirstAudioSampleTime == -1)
                    m_FirstAudioSampleTime = sampleTime;

                // The tricky part here is that audio samples come in one second chunks.
                // The first audio sample we receive may acually be before the start of our recording.
                // This causes synch problems when playing the video back, or worse buffering issues.
                // We solve this by finding the "0" time sample within our first chunk of data and write
                // the audio file from that point forward.
                long time = sampleTime - m_FirstSampleTime;
                if (time < 0)
                {
                    m_Offset = -time;
                    long samplesSynch = (long)(m_Offset / 10000000.0 * AudioFormat.SamplesPerSecond);
                    long idx = samplesSynch * AudioFormat.BitsPerSample / 8 * AudioFormat.Channels;

                    long offsetTime = sampleDuration + time;
                    int offsetLength = (int)(sampleData.Length - idx);

                    byte[] offsetBytes = new byte[sampleData.Length - idx];
                    for (int i = 0; i < offsetBytes.Length; i++)
                    {
                        offsetBytes[i] = sampleData[i + idx];
                    }
                    WriteAudioData(offsetBytes);
                }
                else
                {
                    // Simply keep storing the samples in the audio file.
                    WriteAudioData(sampleData);
                }
                if (!IsRecording)
                {
                    // We try to write a little more than we need into the audio file to make sure we have the entire audio
                    // duration for the last video frame.
                    m_WroteLast = true;
                }
            }
            catch (Exception ex)
            {
                // Possibly out of memory.
            }
        }


        protected override void OnSample(long sampleTime, long frameDuration, byte[] sampleData)
        {
            try
            {
                if (AudioFormat == null)
                {
                    // wait for audio
                    return;
                }
                IsRecording = true;
                if (m_Stream == null)
                {
                    m_FirstSampleTime = sampleTime;
                    m_WroteLast = false;
                    using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        string filename = null;

                        for (int i = 1; true; i++)
                        {
                            string fname = "Recording " + i;
                            if (!file.FileExists(fname))
                            {
                                filename = fname;
                                break;
                            }
                        }

                        if (filename != null)
                        {
                            m_Stream = new IsolatedStorageFileStream(filename, FileMode.Create, file);
                            m_AudioStream = new IsolatedStorageFileStream(filename + " Audio", FileMode.Create, file);

                            // Just create it.
                            m_Filename = filename;

                            WriteData(m_Format.PixelWidth);//4
                            WriteData(m_Format.PixelHeight);//4
                            WriteData(m_Format.FramesPerSecond);//4
                            WriteData(AudioFormat.BitsPerSample);//4
                            WriteData(AudioFormat.Channels);//4
                            WriteData(AudioFormat.SamplesPerSecond);//4

                            long duration = 0;
                            WriteData(duration);//8
                        }
                        else
                        {
                            m_Filename = null;
                        }
                    }
                }

                sampleTime -= m_FirstSampleTime;
                m_LastSampleTime = sampleTime;
                WriteData(sampleTime);
                WriteData(frameDuration);
                WriteData(sampleData.Length);
                WriteData(sampleData);

                if (!m_CapturedThumbnail)
                {
                    m_CapturedThumbnail = true;

                    int width = m_Format.PixelWidth;
                    int height = m_Format.PixelHeight;
                    int bands = 3;
                    byte[][,] raster = new byte[bands][,];
                    for (int i = 0; i < bands; i++)
                    {
                        raster[i] = new byte[width, height];
                    }

                    for (int row = 0; row < height; row++)
                    {
                        for (int column = 0; column < width; column++)
                        {
                            int idx = width * row + column;
                            int idx4 = idx * 4;
                            raster[0][column, row] = sampleData[idx4 + 2];
                            raster[1][column, row] = sampleData[idx4 + 1];
                            raster[2][column, row] = sampleData[idx4 + 0];
                        }
                    }

                    // Encoding seems to take a couple seconds, lets do it in another thread to not block the UI.
                    Thread encodeThread = new Thread(
                             delegate()
                             {

                                 using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
                                 {

                                     FluxJpeg.Core.Image image = new FluxJpeg.Core.Image(new FluxJpeg.Core.ColorModel { colorspace = FluxJpeg.Core.ColorSpace.RGB }, raster);

                                     // Resize and encode a thumbnail from the original picture.
                                     MemoryStream ms = new MemoryStream();
                                     ImageResizer resizer = new ImageResizer(image);
                                     FluxJpeg.Core.Image small = resizer.Resize(80, ResamplingFilters.NearestNeighbor);
                                     JpegEncoder encoder = new JpegEncoder(image, 90, ms);
                                     encoder.Encode();

                                     // Save the thumbnail.
                                     using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(FilenameThumb, FileMode.Create, file))
                                     {
                                         byte[] bytes = new byte[ms.Length];
                                         ms.Position = 0;
                                         ms.Read(bytes, 0, bytes.Length);
                                         stream.Write(bytes, 0, bytes.Length);
                                     }
                                 }
                             });

                    encodeThread.Start();
                }
            }
            catch (Exception ex)
            {
                //Main.Debug("VideoRecorder::OnSample - " + ex.Message);
            }
        }
    }
}
