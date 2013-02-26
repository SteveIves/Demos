using System;
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
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Threading;
using FluxJpeg.Core.Encoder;
using FluxJpeg.Core;
using FluxJpeg.Core.Filtering;
using System.Windows.Threading;
using System.Windows.Browser;

namespace silverscreenPrototype
{
	public partial class Main : UserControl
    {
        #region Constants
        const string LibraryFilename = "Library.xml";
        const double AnimateFromToTrayMilliseconds = 200.0;
        #endregion

        #region Static Members & Properties
        // The Capture source, stored static so the audio effects can reference it.
        private static CaptureSource m_CaptureSource;

        static public CaptureSource MediaSource
        {
            get
            {
                return m_CaptureSource;
            }
        }

        // The matrix effect video, stored static so the ChromaKey effect can reference it.
        static public MediaElement HiddenVideo;
        #endregion

        #region Private Members
        private ObservableCollection<MediaItem> m_Library;
        private RawVideoSource m_LastVideoSource;
        private VideoBrush m_LiveCameraBrush;
        private VideoRecorder m_Recorder;
        private MainViewModel m_MainViewModel;
        private MouseEventHandler m_DisplayMouseMoveHandler;
        private bool m_WheelMouseOver;
        private DispatcherTimer m_HideControlsTimer;
        private bool m_AreEffectsVisible;
        #endregion


        public Main()  
		{
			InitializeComponent();

            // Create the hidden video used by the ChromaKey effect.
            HiddenVideo = new MediaElement();
            HiddenVideo.Visibility = Visibility.Collapsed;
            HiddenVideo.Volume = 0;
            LayoutRoot.Children.Add(HiddenVideo);

            m_Library = LoadLibrary();

            #region Library Clearing On Load
            // We currently clear out the library on every load, comment this out to have it persist.
            NukeItems(m_Library);
            m_Library = new ObservableCollection<MediaItem>();
            #endregion

            m_Library.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(OnLibraryChanged);
            Wheel.MediaItems = m_Library;
            
            // Initialize the view model.
            DataContext = m_MainViewModel = new MainViewModel 
            { 
                Video = new MediaElement 
                { 
                    AutoPlay = false, 
                    Visibility = Visibility.Collapsed 
                } 
            };

            m_MainViewModel.Video.MediaEnded += new RoutedEventHandler(OnPlaybackEnded);
            m_MainViewModel.EffectChanged += new EventHandler<EffectChangedArgs>(OnEffectChanged);
            LayoutRoot.Children.Add(m_MainViewModel.Video);

            // Create a timer for hiding the wheel controls.
            m_HideControlsTimer = new DispatcherTimer();
            m_HideControlsTimer.Interval = TimeSpan.FromSeconds(2);
            m_HideControlsTimer.Tick += new EventHandler(OnHideWheelControls);
            
            #region Initialize UI Event Handlers
            ArchetypeLogo.MouseLeftButtonDown += new MouseButtonEventHandler(OnClickArchetypeLogo);
            CameraPower.Checked += new RoutedEventHandler(OnClickPower);
            CameraPower.Unchecked += new RoutedEventHandler(OnClickPower);
            Wheel.Record += new EventHandler(OnClickRecord);
            Wheel.MediaItemSelected += new EventHandler(OnItemSelected);
            TurnOnCameraBtn.MouseLeftButtonDown += new MouseButtonEventHandler(OnClickCameraOn);
            TwitterOkButton.Click += new RoutedEventHandler(OnClickTwitterOK);
            CloseEffectButton.Click += new RoutedEventHandler(OnClickCloseEffect);
            MouseMove += new MouseEventHandler(OnMouseMove);
            Wheel.MouseEnter += new MouseEventHandler(OnWheelMouseEnter);
            Wheel.MouseLeave += new MouseEventHandler(OnWheelMouseOut);
            Wheel.EffectsClicked += new EventHandler(OnClickEffects);
            CloseDisplayButton.Click += new RoutedEventHandler(OnClickCloseDisplay);
            CameraModeToggle.Click += new RoutedEventHandler(OnClickToggle);
            Display.MouseLeftButtonDown += new MouseButtonEventHandler(OnClickDisplay);
            CaptureScreenArea.MouseLeftButtonDown += new MouseButtonEventHandler(OnClickDisplay);
            Display.MouseLeftButtonUp += new MouseButtonEventHandler(OnReleaseDisplay);
            CaptureScreenArea.MouseLeftButtonUp += new MouseButtonEventHandler(OnReleaseDisplay);
            m_DisplayMouseMoveHandler = new MouseEventHandler(OnDisplayMouseMove);
            Wheel.PublishClicked += new EventHandler(OnClickPublish);
            ClosePublishButton.Click += new RoutedEventHandler(OnClickClosePublish);
            ClosePublishButton1.Click += new RoutedEventHandler(OnClickClosePublish);
            TwitterPublishButton.Click += new RoutedEventHandler(OnClickPublishToTwitter);
            ResetShaderButton.MouseLeftButtonDown += new MouseButtonEventHandler(OnClickResetShader);
            #endregion

            PublishTo.ItemsSource = new string[] 
            {
                "Twitter"
            };
            PublishTo.SelectedIndex = 0;

            // Set the default UI state.
            #region Default UI State
            VisualStateManager.GoToState(this, "DisplayHidden", false);
            VisualStateManager.GoToState(this, "PublishWindowHidden", false); 
            VisualStateManager.GoToState(this, "EffectsHidden", false);
            VisualStateManager.GoToState(this, "ImagePreview", false);
            Wheel.ShowControls = false;
            // Open the shutter one second after our application has launched.
            DelayDelegate.Queue(TimeSpan.FromSeconds(1), delegate()
            {
                VisualStateManager.GoToState(this, "ShutterOpen", true);
            });
            #endregion

            UpdateShutterClip();
        }

        void OnClickArchetypeLogo(object sender, MouseButtonEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri("http://www.archetype-inc.com/"));
        }

        void OnClickResetShader(object sender, MouseButtonEventArgs e)
        {
            if (m_MainViewModel.SelectedEffect != null)
            {
                m_MainViewModel.SelectedEffect.ResetDefaults();
            }
        }

        /// <summary>
        /// This occurs when the OK button in the success/failure window is clicked.
        /// </summary>
        void OnClickTwitterOK(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "PublishWindowHidden", true);
        }

        /// <summary>
        /// An item in the dropdown from the Effects window has been selected.
        /// </summary>
        void OnEffectChanged(object sender, EffectChangedArgs e)
        {
            if (e.Effect is silverscreenPrototype.Effects.Crayon)
            {
                // The crayon effect samples neighboring pixels to produce it's effect, in order to do this
                // it needs to know the dimensions of the source image.
                silverscreenPrototype.Effects.Crayon crayon = e.Effect as silverscreenPrototype.Effects.Crayon;
                crayon.InputWidth = (float)PreviewScreen.ActualWidth;
                crayon.InputHeight = (float)PreviewScreen.ActualHeight;
            }
            if (e.Effect is silverscreenPrototype.Effects.None)
            {
                ResetShaderButton.Visibility =
                ShaderOnCheckbox.Visibility = Visibility.Collapsed;
            }
            else
            {
                ResetShaderButton.Visibility =
                ShaderOnCheckbox.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Recorded video playback has ended.
        /// </summary>
        void OnPlaybackEnded(object sender, RoutedEventArgs e)
        {
            UpdateToSelectedMedia();
        }

        /// <summary>
        /// Update the clipping path around the shutter animation.
        /// This is built dynamically because the window can be different
        /// sizes depending on the camera format.
        /// </summary>
        private void UpdateShutterClip()
        {
            double w = CameraScreen.Width -16*2;
            double h = CameraScreen.Height -36-16;
            Shutter.Clip = new RectangleGeometry
                    {
                         RadiusX = 5,
                         RadiusY = 5,
                         Rect = new Rect(Shutter.Width / 2 - w / 2, Shutter.Height / 2 - h / 2, w, h)
                    };
        }

        /// <summary>
        /// Publish the selected image to twitter.
        /// </summary>
        void OnClickPublishToTwitter(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "Publishing", true);
            UpdateTwitterProfileImage.Upload(TwitterUser.Text, TwitterPassword.Password, Wheel.SelectedItem.FileContents, delegate(bool published)
            {
                Dispatcher.BeginInvoke(delegate()
                {
                    if (published)
                    {
                        VisualStateManager.GoToState(this, "PublishSuccess", true);
                    }
                    else
                    {
                        VisualStateManager.GoToState(this, "PublishWindowHidden", true);
                    }
                });
            });
        }

        /// <summary>
        /// The publish process has been canceled as the user clicked the X close button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnClickClosePublish(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "PublishWindowHidden", true);
        }

        /// <summary>
        /// The publish button on the wheel has been clicked.
        /// </summary>
        void OnClickPublish(object sender, EventArgs e)
        {
            if (Wheel.SelectedItem == null || Wheel.SelectedItem.IsVideo)
            {
                return;
            }
            VisualStateManager.GoToState(this, "PublishWindowVisible", true);
        }

        /// <summary>
        /// The mouse is moving over the camera source window.  This only occurs when the mouse is pressed.
        /// </summary>
        void OnDisplayMouseMove(object sender, MouseEventArgs e)
        {
            FrameworkElement display = sender as FrameworkElement;
            if (m_MainViewModel.SelectedEffectIndex != -1)
            {
                // If we have a selected effect, report the position of the mouse to it 
                // so it can bind it to any effect property it wishes to.
                Point p = e.GetPosition(display);
                p.X /= display.ActualWidth;
                p.Y /= display.ActualHeight;
                m_MainViewModel.Effects[m_MainViewModel.SelectedEffectIndex].OnDisplayMouseDrag(p);
            }
        }

        /// <summary>
        /// The mouse left button has been released after dragging around on the window.
        /// </summary>
        void OnReleaseDisplay(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement display = sender as FrameworkElement;
            if (m_MainViewModel.SelectedEffectIndex != -1)
            {
                // Report the event to the selected effect.
                Point p = e.GetPosition(display);
                p.X /= display.ActualWidth;
                p.Y /= display.ActualHeight;
                m_MainViewModel.Effects[m_MainViewModel.SelectedEffectIndex].OnDisplayMouseUp(p);
            }
            display.MouseMove -= m_DisplayMouseMoveHandler;
            display.ReleaseMouseCapture();
        }

        /// <summary>
        /// The capture window has been clicked on, start a drag operation.
        /// </summary>
        void OnClickDisplay(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement display = sender as FrameworkElement;
            display.CaptureMouse();
            display.MouseMove += m_DisplayMouseMoveHandler;
            if (m_MainViewModel.SelectedEffectIndex != -1)
            {
                // We report the click as the start of a drag operation on the 
                // camera window.  This can be used to do things like place the
                // center of the bulge effect.
                Point p = e.GetPosition(display);
                p.X /= display.ActualWidth;
                p.Y /= display.ActualHeight;
                m_MainViewModel.Effects[m_MainViewModel.SelectedEffectIndex].OnDisplayMouseDown(p);
                e.Handled = true;
            }
        }

        /// <summary>
        /// The video/camera button toggle has been clicked.
        /// </summary>
        void OnClickToggle(object sender, RoutedEventArgs e)
        {
            Wheel.IsCameraMode = CameraModeToggle.IsChecked == true;
        }

        /// <summary>
        /// The recorded/captured media window's X close button has been clicked.
        /// </summary>
        void OnClickCloseDisplay(object sender, RoutedEventArgs e)
        {
            Wheel.SelectedItem = null;
            VisualStateManager.GoToState(this, "DisplayHidden", true);
        }

        /// <summary>
        /// The effects button in the wheel has been clicked.
        /// </summary>
        void OnClickEffects(object sender, EventArgs e)
        {
            m_MainViewModel.SelectedEffectIndex = 0;
            AreEffectsVisible = !AreEffectsVisible;
        }

        /// <summary>
        /// Our hide controls timer has ticked, hide the wheel controls.
        /// </summary>
        void OnHideWheelControls(object sender, EventArgs e)
        {
            Wheel.ShowControls = false;
        }

        /// <summary>
        /// The user has moved the mouse away from the wheel. Much like a video
        /// player we start a timer to hide the controls until the user returns
        /// their focus to the wheel.  We also keep track of the mouse no longer
        /// being over the wheel.
        /// </summary>
        void OnWheelMouseOut(object sender, MouseEventArgs e)
        {
            m_HideControlsTimer.Stop();
            m_HideControlsTimer.Start();
            m_WheelMouseOver = false; 
        }

        /// <summary>
        /// The mouse is over the wheel.
        /// Stop the hide controls timer and track that the mouse is currently 
        /// on the wheel.
        /// </summary>
        void OnWheelMouseEnter(object sender, MouseEventArgs e)
        {
            m_HideControlsTimer.Stop();
            m_WheelMouseOver = true;
        }

        /// <summary>
        /// The mouse has moved, show wheel controls.
        /// </summary>
        void OnMouseMove(object sender, MouseEventArgs e)
        {
            m_HideControlsTimer.Stop();
            if (!m_WheelMouseOver)
            {
                // If our focus is not on the wheel, immediately start a timer to hide the controls
                // afer a period of inactivity.
                m_HideControlsTimer.Start();
            }
            Wheel.ShowControls = true;
        }

        /// <summary>
        /// Property to set the effect window visibility.
        /// </summary>
        public bool AreEffectsVisible
        {
            get
            {
                return m_AreEffectsVisible;
            }
            set
            {
                if (m_AreEffectsVisible == value)
                {
                    return;
                }
                m_AreEffectsVisible = value;

                VisualStateManager.GoToState(this, value ? "EffectsVisible" : "EffectsHidden", true);
            }
        }

        /// <summary>
        /// The X close button on the effects window has been clicked.
        /// </summary>
        void OnClickCloseEffect(object sender, RoutedEventArgs e)
        {
            AreEffectsVisible = false;
        }

        /// <summary>
        /// The Turn Camera On button has been clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnClickCameraOn(object sender, MouseButtonEventArgs e)
        {
            TurnOnCameraBtn.Visibility = Visibility.Collapsed;
            CameraPower.IsChecked = true;
        }

        /// <summary>
        /// An item in the wheel has been clicked on.
        /// </summary>
        void OnItemSelected(object sender, EventArgs e)
        {
            if (Wheel.SelectedItem == null)
            {
                return;
            }
            // Animate the item from the wheel to the display screen.
            MediaItem item = Wheel.SelectedItem;
            DisplayGhost.Fill = new ImageBrush 
            { 
                ImageSource = item.IsVideo ? item.ThumbnailBitmap : item.Bitmap, 
                Stretch = Stretch.Uniform, 
                Transform = new ScaleTransform 
                { 
                    ScaleY = item.IsVideo ? -1 : 1, 
                    CenterY = DisplayGhost.ActualHeight / 2 
                } 
            };
            TranslateTransform xform = new TranslateTransform 
            { 
                X = -(DisplayScreenGrid.RenderTransform as TranslateTransform).X - DisplayScreenGrid.ActualWidth/2, 
                Y = LayoutRoot.ActualHeight - (DisplayScreenGrid.RenderTransform as TranslateTransform).Y 
            };
            ScaleTransform scale = new ScaleTransform 
            { 
                ScaleX = 0.0, 
                ScaleY = 0.0 
            };

            Point target = new Point(0,0);
            Point start = new Point(xform.X, xform.Y);
            TransformGroup g = new TransformGroup();
            g.Children.Add(scale);
            g.Children.Add(xform);
            DisplayGhost.RenderTransform = g;
            DisplayGhost.Opacity = 0.0;
            Storyboard story = new Storyboard();
            DateTime startTime = DateTime.Now;
            story.Completed += new EventHandler(delegate(object s, EventArgs ev)
            {
                TimeSpan elapsed = DateTime.Now.Subtract(startTime);
                double f = elapsed.TotalMilliseconds / AnimateFromToTrayMilliseconds;
                double easeF = Math.Pow(f, 0.7);
                double invf = 1.0 - easeF;
                xform.X = target.X * easeF + start.X * invf;
                xform.Y = target.Y * easeF + start.Y * invf;
                DisplayGhost.Opacity = f;

                scale.ScaleX = f;
                scale.ScaleY = f;
                
                if (f >= 1.0)
                {
                    xform.X = target.X;
                    xform.Y = target.Y;
                    DisplayGhost.Opacity = 1;
                    scale.ScaleX = scale.ScaleY = 1;

                    UpdateToSelectedMedia();
                }
                else
                {
                    story.Begin();
                }

            });
            story.Begin();
        }

        /// <summary>
        /// Synchronize the display window with the selected item from the wheel.
        /// </summary>
        public void UpdateToSelectedMedia()
        {
            if (Wheel.SelectedItem == null)
            {
                return;
            }
            if (m_LastVideoSource != null)
            {
                m_LastVideoSource.Close();
                m_LastVideoSource = null;
            }
            m_MainViewModel.Video.Stop();
            if (Wheel.SelectedItem.IsVideo)
            {
                VideoBrush previewBrush = new VideoBrush();
                previewBrush.Stretch = Stretch.Uniform;
                previewBrush.Transform = new ScaleTransform { ScaleY = -1, CenterY=Display.ActualHeight/2};
                m_LastVideoSource = new RawVideoSource(Wheel.SelectedItem.Filename);

                m_MainViewModel.Video.SetSource(m_LastVideoSource);
                previewBrush.SetSource(m_MainViewModel.Video);
                Display.Fill = previewBrush;
                VisualStateManager.GoToState(this, "VideoPlayback", true);
            }
            else
            {
                Display.Fill = new ImageBrush { Stretch = Stretch.Uniform, ImageSource = Wheel.SelectedItem.Bitmap };
                VisualStateManager.GoToState(this, "ImagePreview", true);
            }
            VisualStateManager.GoToState(this, "DisplayVisible", true);
        }

        /// <summary>
        /// Whenever our ObservableCollection of MediaItems is changed, save it to IsolatedStorage.
        /// At this point this is a very light operation as the media files have already been stored.
        /// All we're saving is some xml.
        /// </summary>
        void OnLibraryChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SaveLibrary(m_Library);
        }

        /// <summary>
        /// Animates a MediaItem from the capture window to the tray.
        /// </summary>
        /// <param name="delaySeconds">Number of seconds to wait before animating.</param>
        /// <param name="item">The media item displayed.</param>
        private void MediaItemToTrayAnimation(double delaySeconds, MediaItem item)
        {
            DelayDelegate.Queue(TimeSpan.FromSeconds(delaySeconds), delegate()
                                             {
                                                 PreviewGhost.Fill = new ImageBrush 
                                                 { 
                                                     ImageSource = item.Bitmap, Stretch = Stretch.Uniform, 
                                                     Transform = new ScaleTransform 
                                                     { 
                                                         ScaleY = item.IsVideo ? -1 : 1, 
                                                         CenterY = PreviewGhost.ActualHeight / 2 
                                                     } 
                                                 };
                                                 TranslateTransform xform = new TranslateTransform();
                                                 ScaleTransform scale = new ScaleTransform();
                                                 Point target = new Point(-(CameraScreen.RenderTransform as TranslateTransform).X + CameraScreen.ActualWidth, LayoutRoot.ActualHeight - (CameraScreen.RenderTransform as TranslateTransform).Y);
                                                 Point start = new Point(0, 0);
                                                 TransformGroup g = new TransformGroup();
                                                 g.Children.Add(scale);
                                                 g.Children.Add(xform);
                                                 PreviewGhost.RenderTransform = g;
                                                 PreviewGhost.Opacity = 1.0;

                                                 Storyboard story = new Storyboard();
                                                 DateTime startTime = DateTime.Now;
                                                 story.Completed += new EventHandler(delegate(object s, EventArgs ev)
                                                 {
                                                     TimeSpan elapsed = DateTime.Now.Subtract(startTime);
                                                     double f = elapsed.TotalMilliseconds / AnimateFromToTrayMilliseconds;
                                                     double easeF = Math.Pow(f, 1.3);
                                                     double invf = 1.0 - easeF;
                                                     xform.X = target.X * easeF + start.X * invf;
                                                     xform.Y = target.Y * easeF + start.Y * invf;
                                                     PreviewGhost.Opacity = 1.0-f;

                                                     scale.ScaleX = 1.0 - f;
                                                     scale.ScaleY = 1.0 - f;

                                                     if (f >= 1.0)
                                                     {
                                                         xform.X = target.X;
                                                         xform.Y = target.Y;
                                                         PreviewGhost.Opacity = 0;
                                                         scale.ScaleX = scale.ScaleY = 1;

                                                         UpdateToSelectedMedia();
                                                         PopWheel.Begin();

                                                         m_Library.Insert(0, item);
                                                         DelayDelegate.Queue(TimeSpan.FromSeconds(delaySeconds), delegate()
                                                         {
                                                             Wheel.SelectedItem = item;
                                                         });
                                                     }
                                                     else
                                                     {
                                                         story.Begin();
                                                     }

                                                 });
                                                 story.Begin();
                                             });
        }

        /// <summary>
        /// The record button has been clicked.
        /// </summary>
        void OnClickRecord(object sender, EventArgs e)
        {
            if (CameraPower.IsChecked == false)
            {
                CameraPower.IsChecked = true;
                return;
            }
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isf.Quota < 1024 * 1024 * 1024)
                {
                    if (!isf.IncreaseQuotaTo(1024 * 1024 * 1024))
                        return;
                    return;
                }
            }
            if (CameraModeToggle.IsChecked == false)
            {
                // Video Mode
                if (m_Recorder.IsRecording)
                {
                    m_Recorder.StopRecording();
                    CameraPower.IsChecked = true;
                    MediaItem item = new MediaItem { IsVideo = true, Filename = m_Recorder.Filename, ThumbnailFilename = m_Recorder.FilenameThumb };
                    MediaItemToTrayAnimation(0.5,item);
                }
                else
                {
                    m_Recorder.StartRecording(m_CaptureSource);
                }
            }
            else
            {
                ShutterSound.Stop();
                ShutterSound.Play();
                // Camera Mode
                ShutterSound.Play();
                VisualStateManager.GoToState(this, "ShutterClosed", true);
                DelayDelegate.Queue(TimeSpan.FromSeconds(1), delegate()
                {
                    VisualStateManager.GoToState(this, "ShutterOpen", true);
                });

                DelayDelegate.Queue(TimeSpan.FromSeconds(0.05), delegate()
                {
                    // Capture the image from the actual VideoBrush + Effect.
                    WriteableBitmap bmp = new WriteableBitmap((int)CaptureScreenArea.ActualWidth, (int)CaptureScreenArea.ActualHeight);
                    bmp.Render(CaptureScreenArea, null);
                    bmp.Invalidate();
                    
                    int width = bmp.PixelWidth;
                    int height = bmp.PixelHeight;
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
                            int pixel = bmp.Pixels[width * row + column];
                            raster[0][column, row] = (byte)(pixel >> 16);
                            raster[1][column, row] = (byte)(pixel >> 8);
                            raster[2][column, row] = (byte)pixel;
                        }
                    }

                    // JPEG encoding seems to take a couple seconds, lets do it in another thread to not block the UI.
                    Thread encodeThread = new Thread(
                             delegate()
                             {
                                 using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
                                 {
                                     // Get a unique filename.
                                     string filename = null;
                                     for (int pictureIndex = 1; true; pictureIndex++)
                                     {
                                         string filetest = "Picture " + pictureIndex;
                                         if (!file.FileExists(filetest))
                                         {
                                             filename = filetest;
                                             break;
                                         }
                                     }

                                     string thumbFilename = filename + " Thumb";

                                     MemoryStream ms = new MemoryStream();
                                     FluxJpeg.Core.Image image = new FluxJpeg.Core.Image(new FluxJpeg.Core.ColorModel { colorspace = FluxJpeg.Core.ColorSpace.RGB }, raster);
                                     
                                     // Encode our captured picture.
                                     JpegEncoder encoder = new JpegEncoder(image, 90, ms);
                                     encoder.Encode();

                                     // Save the picture.
                                     using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(filename, FileMode.Create, file))
                                     {
                                         byte[] bytes = new byte[ms.Length];
                                         ms.Position = 0;
                                         ms.Read(bytes, 0, bytes.Length);
                                         stream.Write(bytes, 0, bytes.Length);
                                     }

                                     // Resize and encode a thumbnail from the original picture.
                                     ms = new MemoryStream();
                                     ImageResizer resizer = new ImageResizer(image);
                                     FluxJpeg.Core.Image small = resizer.Resize(80, ResamplingFilters.NearestNeighbor);
                                     encoder = new JpegEncoder(image, 90, ms);
                                     encoder.Encode();

                                     // Save the thumbnail.
                                     using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(thumbFilename, FileMode.Create, file))
                                     {
                                         byte[] bytes = new byte[ms.Length];
                                         ms.Position = 0;
                                         ms.Read(bytes, 0, bytes.Length);
                                         stream.Write(bytes, 0, bytes.Length);
                                     }

                                     // Add our image to the library.
                                     Dispatcher.BeginInvoke(delegate()
                                     {
                                         MediaItem item =new MediaItem { IsVideo = false, Filename = filename, ThumbnailFilename = thumbFilename };
                                         
                                         MediaItemToTrayAnimation(0.2, item);
                                     });
                                 }
                             });
                    encodeThread.Start();
                });
            }
        }

        /// <summary>
        /// Clear out a list of items from IsolatedStorage.
        /// </summary>
        /// <param name="items">The list of MediaItems to remove from IsolatedStorage.</param>
        public void NukeItems(ObservableCollection<MediaItem> items)
        {
            using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                foreach (MediaItem item in items)
                {
                    if (file.FileExists(item.Filename))
                    {
                        file.DeleteFile(item.Filename);
                    }
                    if (file.FileExists(item.ThumbnailFilename))
                    {
                        file.DeleteFile(item.ThumbnailFilename);
                    }
                    if (file.FileExists(item.Filename + " Audio"))
                    {
                        file.DeleteFile(item.Filename + " Audio");
                    }
                }
            }
        }

        /// <summary>
        /// Load a list of MediaItems from IsolatedStorage.
        /// </summary>
        /// <returns>An ObservableCollection of MediaItems.</returns>
        public ObservableCollection<MediaItem> LoadLibrary()
        {
            System.Collections.ObjectModel.ObservableCollection<MediaItem> items = new System.Collections.ObjectModel.ObservableCollection<MediaItem>();
            using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (file.FileExists(LibraryFilename))
                {
                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(LibraryFilename, FileMode.Open, file))
                    {
                        StreamReader reader = new StreamReader(stream);
                        string xml = reader.ReadToEnd();
                        XElement root = XElement.Parse(xml);
                        List<MediaItem> itemsList = (from media in root.Elements("MediaItem") select new MediaItem(media)).ToList<MediaItem>();
                        foreach (MediaItem item in itemsList)
                        {
                            items.Add(item);
                        }
                    }
                }
            }
            return items;
        }

        /// <summary>
        /// Save a list of MediaItems to IsolatedStorage so that it can be persisted between sessions.
        /// </summary>
        /// <param name="library">The list of MediaItems to store.</param>
        public void SaveLibrary(ObservableCollection<MediaItem> library)
        {
            XElement root = new XElement("Library");
            foreach (MediaItem item in library)
            {
                root.Add(item.ToXml());
            }

            using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(LibraryFilename, FileMode.Create, file))
                {
                    System.Text.Encoding encoding = new System.Text.UTF8Encoding();
                    byte[] bytes = encoding.GetBytes(root.ToString());
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
        }

        /// <summary>
        /// The turn on camera button has just been clicked.
        /// </summary>
        void OnClickPower(object sender, RoutedEventArgs e)
        {
            if (m_CaptureSource == null)
            {
                // Initialize the video/audio capture source.
                m_CaptureSource = new CaptureSource();
                m_CaptureSource.VideoCaptureDevice = CaptureDeviceConfiguration.GetDefaultVideoCaptureDevice();

                // Create a VideoBrush which we use to display the capured video frames as they stream in.
                m_LiveCameraBrush = new VideoBrush();
                m_LiveCameraBrush.Stretch = Stretch.Uniform;
                m_LiveCameraBrush.SetSource(m_CaptureSource);
                PreviewScreen.Fill = m_LiveCameraBrush;

                // Search for a format that's as close as possible to 640x480.
                Size diff = new Size(double.MaxValue, double.MaxValue);
                Size wantedSize = new Size(640, 480);
                VideoFormat bestFormat = null;
                m_Recorder = new VideoRecorder();
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
                    // Once we've found a video format we need to resize our display with the frame size.
                    m_CaptureSource.VideoCaptureDevice.DesiredFormat = bestFormat;
                    // We actually display half the format in pixels, this was done to promote higher quality results
                    // from the pixel shader. We don't think we're seeing the desired results, possibly because
                    // Silverlight optimizes the image sent to the pixel shader to match the on screen dimensions.
                    // The little bit of padding is for the chrome.
                    DisplayScreenGrid.Width = CameraScreen.Width = bestFormat.PixelWidth/2+16*2;
                    DisplayScreenGrid.Height = CameraScreen.Height = bestFormat.PixelHeight/2 + 36 + 16;

                    // Update the clip area of the shutter animation.
                    UpdateShutterClip();
                }
                // Request Camera/Mic access.
                if (CaptureDeviceConfiguration.RequestDeviceAccess() || CaptureDeviceConfiguration.AllowedDeviceAccess)
                {
                    m_CaptureSource.Start();
                    Wheel.SelectedItem = null;
                }
                return;
            }
            if (CameraPower.IsChecked == true)
            {
                PreviewScreen.Fill = m_LiveCameraBrush;
                if (CaptureDeviceConfiguration.AllowedDeviceAccess || CaptureDeviceConfiguration.RequestDeviceAccess())
                {
                    Wheel.SelectedItem = null;
                    m_CaptureSource.Start();
                }
            }
            else if(CameraPower.IsChecked == false)
            {
                m_CaptureSource.Stop();
            }
        }
	}
}