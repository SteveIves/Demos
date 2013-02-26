using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Threading;

namespace silverscreenPrototype
{
    /// <summary>
    /// The wheel control. Displays an infinite number of items, revealed by turning the wheel.
    /// </summary>
	public partial class Wheel : UserControl
	{
        public event EventHandler Record;
        public event EventHandler MediaItemSelected;
        public event EventHandler EffectsClicked;
        public event EventHandler PublishClicked;

        List<WheelWedge> m_Wedges;
        private System.Collections.Specialized.NotifyCollectionChangedEventHandler m_MediaItemsChangedHandler;
        private int m_OffsetIndex;
        private MediaItem m_SelectedItem;
        private bool m_Animating;
        private DispatcherTimer m_Timer;

		public Wheel()
		{
			// Required to initialize variables
			InitializeComponent();

            m_MediaItemsChangedHandler = new System.Collections.Specialized.NotifyCollectionChangedEventHandler(OnCollectionChanged);
            RecordButton.Click += new RoutedEventHandler(OnClickRecord);
            CameraPictureButton.Click += new RoutedEventHandler(OnClickRecord);
            m_Wedges = new List<WheelWedge>()
            {
                Wedge0,
                Wedge1,
                Wedge2,
                Wedge3,
                Wedge4,
                Wedge5,
                Wedge6
            };
            foreach (WheelWedge wedge in m_Wedges)
            {
                wedge.WedgeSelected += new EventHandler(OnWedgeSelected);
            }
            LeftButton.Click += new RoutedEventHandler(OnClickLeft);
            RightButton.Click += new RoutedEventHandler(OnClickRight);


            m_Timer = new DispatcherTimer();
            m_Timer.Tick += new EventHandler(OnDelayTimer);
            m_Timer.Interval = TimeSpan.FromSeconds(0.7);

            EffectsButton.MouseLeftButtonDown += new MouseButtonEventHandler(OnClickEffects);

            PublishButton.MouseLeftButtonDown += new MouseButtonEventHandler(OnClickPublish);
		}

        void OnClickPublish(object sender, MouseButtonEventArgs e)
        {
            if (PublishClicked != null)
            {
                PublishClicked(this, null);
            }
        }

        private bool m_IsCameraMode;
        public bool IsCameraMode
        {
            get
            {
                return m_IsCameraMode;
            }
            set
            {
                if (m_IsCameraMode == value)
                {
                    return;
                }
                m_IsCameraMode = value;
                VisualStateManager.GoToState(this, !m_IsCameraMode ? "VideoMode" : "CameraMode", true);
            }
        }
        void OnClickEffects(object sender, MouseButtonEventArgs e)
        {
            if (EffectsClicked != null)
            {
                EffectsClicked(this, null);
            }
        }


        public MediaItem SelectedItem
        {
            get
            {
                return m_SelectedItem;
            }
            set
            {
                if (m_SelectedItem == value)
                {
                    return;
                }
                m_SelectedItem = value;
                SetItems(m_OffsetIndex);
                if (MediaItemSelected != null)
                {
                    MediaItemSelected(this, null);
                }
            }
        }

        void OnClickRecord(object sender, RoutedEventArgs e)
        {
            if(Record != null )
            {
                Record(this, null);
            }
        }

        void OnWedgeSelected(object sender, EventArgs e)
        {
            WheelWedge selectedWedge = sender as WheelWedge;
            SelectedItem = selectedWedge.MediaItem;
            foreach (WheelWedge wedge in m_Wedges)
            {
                if (selectedWedge == wedge)
                {
                    continue;
                }
                wedge.SetSelected(false, true);
            }
        }

        void OnDelayTimer(object sender, EventArgs e)
        {
            m_Timer.Stop();
            VisualStateManager.GoToState(this, "normal", false);
            SetItems(m_OffsetIndex);
            m_Animating = false;
            LeftButton.IsEnabled = true;
            RightButton.IsEnabled = true;
            System.Diagnostics.Debug.WriteLine("Animating Done");
        }

        void OnClickLeft(object sender, RoutedEventArgs e)
        {
            if (m_Animating)
            {
                return;
            }
            m_Animating = true;
            m_OffsetIndex--;
            VisualStateManager.GoToState(this, "rotateRight", true);
            LeftButton.IsEnabled = false;
            RightButton.IsEnabled = false;
            System.Diagnostics.Debug.WriteLine("Rotating Right");
            m_Timer.Stop();
            m_Timer.Start();
        }

        void OnClickRight(object sender, RoutedEventArgs e)
        {
            if (m_Animating)
            {
                return;
            }
            m_Animating = true;
            m_OffsetIndex++;
            VisualStateManager.GoToState(this, "rotateLeft", true);
            LeftButton.IsEnabled = false;
            RightButton.IsEnabled = false;
            System.Diagnostics.Debug.WriteLine("Rotating Left");
            m_Timer.Stop();
            m_Timer.Start();
        }

        void SetItems(int offset)
        {
            for (int i = 0; i < m_Wedges.Count; i++)
            {
                int idx = offset + i;
                m_Wedges[i].MediaItem = idx < 0 || idx >= MediaItems.Count ? null : MediaItems[idx];
                if (m_Wedges[i].MediaItem == m_SelectedItem)
                {
                    m_Wedges[i].IsSelected = true;
                }
                else
                {
                    m_Wedges[i].IsSelected = false;
                }
            }
        }

        public bool ShowControls
        {
            set
            {
                VisualStateManager.GoToState(this, value ? "ControlsVisible" : "ControlsHidden", true);
            }
        }

        public ObservableCollection<MediaItem> MediaItems
        {
            get { return (ObservableCollection<MediaItem>)GetValue(MediaItemsProperty); }
            set { SetValue(MediaItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MediaItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MediaItemsProperty =
            DependencyProperty.Register("MediaItems", typeof(ObservableCollection<MediaItem>), typeof(Wheel), new PropertyMetadata(null, OnChangeMediaItems));

        static void OnChangeMediaItems(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Wheel wheel = d as Wheel;
            wheel.OnMediaItemsChanged(e.OldValue as ObservableCollection<MediaItem>);
        }

        private void OnMediaItemsChanged(ObservableCollection<MediaItem> oldItems)
        {
            if (oldItems != null)
            {
                oldItems.CollectionChanged -= m_MediaItemsChangedHandler;
            }
            m_OffsetIndex = -3;
            MediaItems.CollectionChanged += m_MediaItemsChangedHandler;
            SetItems(m_OffsetIndex);
        }

        void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Pop back to the front of the wheel
            m_OffsetIndex = -3;
            SetItems(m_OffsetIndex);
        }
	}
}