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
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using System.IO.IsolatedStorage;
using System.IO;
using FluxJpeg.Core.Decoder;

namespace silverscreenPrototype
{
    public class MediaItem
    {
        public MediaItem()
        {

        }

        public MediaItem(XElement xml)
        {
            XAttribute att = xml.Attribute("ThumbnailFilename");
            if (att != null)
            {
                ThumbnailFilename = att.Value;
            }

            att = xml.Attribute("Filename");
            if (att != null)
            {
                Filename = att.Value;
            }

            att = xml.Attribute("IsVideo");
            if (att != null)
            {
                bool isVideo;
                if (bool.TryParse(att.Value, out isVideo))
                {
                    IsVideo = isVideo;
                }
            }
        }

        private BitmapImage m_ThumbnailBitmap;
        public BitmapImage ThumbnailBitmap
        {
            get
            {
                if (m_ThumbnailBitmap == null)
                {
                    using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(ThumbnailFilename, FileMode.Open, file))
                        {
                            m_ThumbnailBitmap = new BitmapImage();
                            m_ThumbnailBitmap.SetSource(stream);
                        }
                    }
                }
                return m_ThumbnailBitmap;
            }
        }

        public byte[] FileContents
        {
            get
            {
                if (IsVideo)
                {
                    return null;
                }
                using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(Filename, FileMode.Open, file))
                    {
                        byte[] bytes = new byte[stream.Length];
                        stream.Read(bytes, 0, bytes.Length);
                        return bytes;
                    }
                }
                return null;
            }
        }

        private BitmapImage m_Bitmap;
        public BitmapImage Bitmap
        {
            get
            {
                if (IsVideo)
                {
                    return ThumbnailBitmap;
                }
                if (m_Bitmap == null)
                {
                    using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(Filename, FileMode.Open, file))
                        {
                            m_Bitmap = new BitmapImage();
                            m_Bitmap.SetSource(stream);
                        }
                    }
                }
                return m_Bitmap;
            }
        }

        public string ThumbnailFilename
        {
            get;
            set;
        }

        public string Filename
        {
            get;
            set;
        }

        public bool IsVideo
        {
            get;
            set;
        }

        public XElement ToXml()
        {
            return new XElement("MediaItem", new XAttribute("ThumbnailFilename", ThumbnailFilename), new XAttribute("Filename", Filename), new XAttribute("IsVideo", IsVideo));
        }
    }
}
