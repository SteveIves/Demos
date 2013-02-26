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
using System.IO;

namespace silverscreenPrototype
{
    /// <summary>
    /// Simple AudioSink which looks for average volume levels.
    /// </summary>
    public class VolumeCapture : AudioSink
    {
        AudioFormat m_Format;

        public double Volume
        {
            get;
            private set;
        }
        protected override void OnCaptureStarted()
        {
        }

        protected override void OnCaptureStopped()
        {
        }

        protected override void OnFormatChange(AudioFormat audioFormat)
        {
            m_Format = audioFormat;
        }

        protected override void OnSamples(long sampleTime, long sampleDuration, byte[] sampleData)
        {
            MemoryStream stream = new MemoryStream(sampleData);
            int samples = sampleData.Length / 2;
            BinaryReader reader = new BinaryReader(stream);
            double sum = 0.0;
            int count = 0;
            int max = 100;
            int step = samples / max;
            try
            {
                while (stream.Position < stream.Length - 2 && count < max)
                {
                    short value = reader.ReadInt16();
                    sum += Math.Abs(value) / (double)short.MaxValue;
                    count++;
                    stream.Seek(2 * step, SeekOrigin.Current);
                }
            }
            catch (Exception)
            {
            }

            Volume = sum / count;
        }
    }
}
