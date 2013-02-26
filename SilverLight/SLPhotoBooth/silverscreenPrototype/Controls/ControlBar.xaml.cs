using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace silverscreenPrototype
{
    /// <summary>
    /// The video controls bar.
    /// </summary>
    public partial class ControlBar : UserControl
    {
        private RoutedEventHandler m_StateChangedHandler;

        public ControlBar()
        {
            // Required to initialize variables
            InitializeComponent();

            m_StateChangedHandler = new RoutedEventHandler(Video_CurrentStateChanged);

            Storyboard story = new Storyboard();
            story.Completed += new EventHandler(story_Completed);
            story.Begin();

            Scrubber.ValueChanged += new PositionSliderChangedEventHandler(OnScrubberChanged);

            PlayButton.MouseLeftButtonDown += new MouseButtonEventHandler(PlayButton_MouseLeftButtonDown);

            Volume.ValueChanged += new PositionSliderChangedEventHandler(Volume_ValueChanged);
            FullScreenButton.MouseLeftButtonDown += new MouseButtonEventHandler(OnClickFullScreen);

            Application.Current.Host.Content.FullScreenChanged += new EventHandler(Content_FullScreenChanged);
        }

        void Content_FullScreenChanged(object sender, EventArgs e)
        {
            if (Application.Current.Host.Content.IsFullScreen)
            {
                VisualStateManager.GoToState(this, "FullScreen", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "Windowed", true);
            }
        }

        void OnClickFullScreen(object sender, MouseButtonEventArgs e)
        {
            if (FullscreenCommand != null)
            {
                FullscreenCommand.Execute(Video);
            }
        }

        void Volume_ValueChanged(object sender, PositionSliderChangedArgs e)
        {
            if (Video == null) return;
            Video.Volume = e.Value;
        }

        void PlayButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Video == null) return;
            if (Video.CurrentState == MediaElementState.Playing)
                Video.Pause();
            else
                Video.Play();
        }

        void OnScrubberChanged(object sender, PositionSliderChangedArgs e)
        {
            if (Video == null) return;

            Video.Position = TimeSpan.FromSeconds(e.Value * Video.NaturalDuration.TimeSpan.TotalSeconds);
        }

        void story_Completed(object sender, EventArgs e)
        {
            (sender as Storyboard).Begin();

            if (Video == null) return;
            try
            {
                Scrubber.Value = Video.Position.TotalSeconds / Video.NaturalDuration.TimeSpan.TotalSeconds;
                if (Video.NaturalDuration.TimeSpan.TotalHours > 1.0)
                {
                    TimeDisplay.Text = string.Format("{0:00}:{1:00}:{2:00}", Video.Position.Hours, Video.Position.Minutes, Video.Position.Seconds)
                                        + " / " + string.Format("{0:00}:{1:00}:{2:00}", Video.NaturalDuration.TimeSpan.Hours, Video.NaturalDuration.TimeSpan.Minutes, Video.NaturalDuration.TimeSpan.Seconds);
                }
                else
                {
                    TimeDisplay.Text = string.Format("{0:00}:{1:00}", Video.Position.Minutes, Video.Position.Seconds)
                                        + " / " + string.Format("{0:00}:{1:00}", Video.NaturalDuration.TimeSpan.Minutes, Video.NaturalDuration.TimeSpan.Seconds);
                }
            }
            catch (Exception)
            {
            }

        }

        public MediaElement Video
        {
            get { return (MediaElement)GetValue(VideoProperty); }
            set { SetValue(VideoProperty, value); }
        }

        public static readonly DependencyProperty VideoProperty = DependencyProperty.Register("Video", typeof(MediaElement), typeof(ControlBar), new PropertyMetadata(null, OnVideoSourceChanged));

        private static void OnVideoSourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs events)
        {
            ControlBar bar = obj as ControlBar;
            bar.UpdateVideoSource(events.OldValue as MediaElement);
        }

        private void UpdateVideoSource(MediaElement old)
        {
            if (old != null)
            {
                old.CurrentStateChanged -= m_StateChangedHandler;
            }

            Volume.Value = Video.Volume;
            Video.CurrentStateChanged += m_StateChangedHandler;
        }

        void Video_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            switch (Video.CurrentState)
            {
                case MediaElementState.Paused:
                    VisualStateManager.GoToState(this, "Paused", true);
                    break;
                case MediaElementState.Playing:
                    VisualStateManager.GoToState(this, "Playing", true);
                    break;
            }
        }

        public ICommand FullscreenCommand
        {
            get { return (ICommand)GetValue(FullscreenCommandProperty); }
            set { SetValue(FullscreenCommandProperty, value); }
        }

        public static readonly DependencyProperty FullscreenCommandProperty = DependencyProperty.Register("FullscreenCommand", typeof(ICommand), typeof(ControlBar), new PropertyMetadata(null));


    }

}
