using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Net;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Browser;

namespace barcodePrototype
{
	public partial class MainPage : UserControl
    {
        CaptureSource m_CaptureSource;
        bool m_IsCapturing;
        BarcodeCapture m_Capture;

		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();

            ScanButton.Click += new RoutedEventHandler(OnClickScan);
            TurnOnCameraBtn.MouseLeftButtonDown += new MouseButtonEventHandler(OnClickCameraOnBtn);
            VisualStateManager.GoToState(this, "flicker", true);
            ArchetypeLogo.MouseLeftButtonDown += new MouseButtonEventHandler(OnClickArchetypeLogo);
		}

        void OnClickArchetypeLogo(object sender, MouseButtonEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri("http://www.archetype-inc.com/"));
        }

        void OnClickCameraOnBtn(object sender, MouseButtonEventArgs e)
        {
            ActivateCamera();
        }

        void ActivateCamera()
        {
            if (m_CaptureSource == null)
            {
                TurnOnCameraBtn.Visibility = Visibility.Collapsed;
                m_CaptureSource = new CaptureSource();
                m_CaptureSource.VideoCaptureDevice = CaptureDeviceConfiguration.GetDefaultVideoCaptureDevice();

                VideoBrush previewBrush = new VideoBrush();
                previewBrush.Stretch = Stretch.Uniform;
                previewBrush.SetSource(m_CaptureSource);
                PreviewScreen.Fill = previewBrush;

                Size diff = new Size(double.MaxValue, double.MaxValue);
                Size wantedSize = new Size(640, 480);
                VideoFormat bestFormat = null;
                foreach (VideoFormat format in m_CaptureSource.VideoCaptureDevice.SupportedFormats)
                {
                    double x = Math.Abs(format.PixelWidth - wantedSize.Width);
                    double y = Math.Abs(format.PixelHeight - wantedSize.Height);

                    if (x < diff.Width && y < diff.Height)
                    {
                        bestFormat = format;
                        diff.Width = x;
                        diff.Height = y;
                    }
                }
                if (bestFormat != null)
                {
                    m_CaptureSource.VideoCaptureDevice.DesiredFormat = bestFormat;
                }
                if (CaptureDeviceConfiguration.RequestDeviceAccess() || CaptureDeviceConfiguration.AllowedDeviceAccess)
                {
                    m_CaptureSource.Start();
                }
                m_IsCapturing = true;
            }
        }

        void OnClickScan(object sender, RoutedEventArgs e)
        {
            ActivateCamera();

            if (m_Capture == null)
            {
                m_Capture = new BarcodeCapture();
                m_Capture.BarcodeDetected += new EventHandler<BarcodeEventArgs>(OnBarcodeDetected);
                m_Capture.CaptureSource = m_CaptureSource;
            }
        }

        void OnTimeout(object sender, EventArgs e)
        {
            (sender as DispatcherTimer).Stop();
            m_CaptureSource.Stop();
            VisualStateManager.GoToState(this, "results", true);
        }

        void OnBarcodeDetected(object sender, BarcodeEventArgs e)
        {
            Dispatcher.BeginInvoke(delegate()
            {
                //BookTitle.Text = "Looking up: " + e.Barcode;
                if (e.Barcode.Length == 13)
                {
                    VisualStateManager.GoToState(this, "results", true);
                    m_CaptureSource.Stop();
                    WebClient request = new WebClient();
                    request.DownloadStringCompleted += new DownloadStringCompletedEventHandler(OnDownloadStringCompleted);
                    request.DownloadStringAsync(Archetype.External.Request.GetAbsoluteUri("FindProducts.aspx?ISBN=" + e.Barcode));

                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(2);
                    timer.Tick += delegate(object s, EventArgs ev)
                    {
                        results.Storyboard.Pause();
                        timer.Stop();
                    };
                    timer.Start();
                }
            });
        }

        void OnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            results.Storyboard.Resume();
            XElement root = XElement.Parse(e.Result);
            XElement books = root.Element("Books");
            List<XElement> booksList = new List<XElement>(books.Elements("Book"));
            if (booksList.Count > 0)
            {
                string title = booksList[0].Attribute("Title").Value;
                if (title.Length > 50)
                    title = title.Substring(0, 50);
                BookTitle.Text = title;
                image.Source = new BitmapImage { UriSource = new Uri(booksList[0].Attribute("Image").Value) };
                image.Stretch = Stretch.UniformToFill;
                XElement authors = booksList[0].Element("Authors");
                if (authors != null)
                {
                    string authorsText = "";
                    List<XElement> authorElements = new List<XElement>(authors.Elements("Author"));
                    foreach (XElement author in authorElements)
                    {
                        if (authorsText != "")
                            authorsText += ", ";
                        authorsText += author.Value + " (author)";
                    }
                    Authors.Text = authorsText;
                }
            }
        }


		private void showScanner(object sender, System.Windows.RoutedEventArgs e)
		{
            m_CaptureSource.Start();
            m_Capture.Clear();
			VisualStateManager.GoToState(this, "scanner", true);
		}
	}
}