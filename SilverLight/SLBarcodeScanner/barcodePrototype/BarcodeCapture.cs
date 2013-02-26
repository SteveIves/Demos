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
using System.Threading;

namespace barcodePrototype
{
    public class BarcodeEventArgs : EventArgs
    {
        public string Barcode
        {
            get;
            private set;
        }

        public BarcodeEventArgs(string barcode)
        {
            Barcode = barcode;
        }
    }

    public class BarcodeCapture : VideoSink
    {
        public event EventHandler<BarcodeEventArgs> BarcodeDetected;

        private VideoFormat m_VideoFormat;
        private List<string> m_Codes;
        public BarcodeCapture()
        {
            m_Codes = new List<string>();
        }
        public void Clear()
        {
            m_Codes.Clear();
        }

        protected override void OnCaptureStarted()
        {
        }

        protected override void OnCaptureStopped()
        {
        }

        protected override void OnFormatChange(VideoFormat videoFormat)
        {
            m_VideoFormat = videoFormat;
        }

        protected override void OnSample(long sampleTime, long frameDuration, byte[] sampleData)
        {
            Bitmap bitmap = new Bitmap();
            bitmap.PixelFormat = PixelFormat.Format32bppRgb;
            bitmap.Buffer = sampleData;
            bitmap.Width = m_VideoFormat.PixelWidth;
            bitmap.Height = m_VideoFormat.PixelHeight;

            List<string> codes = new List<string>();
            BarcodeImaging.FullScanPage(ref codes, bitmap, 300, ref m_Offset);
            foreach (string s in codes)
            {
                if (m_Codes.Contains(s))
                {
                    continue;
                }
                m_Codes.Add(s);
                if (BarcodeDetected != null)
                {
                    BarcodeDetected(this, new BarcodeEventArgs(s));
                }
            }
        }
        long m_Offset = 0;
    }
}
