using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace silverscreenPrototype
{
	public partial class WheelWedge : UserControl
	{
        public event EventHandler WedgeSelected;

		public WheelWedge()
		{
			// Required to initialize variables
			InitializeComponent();

            Loaded += new RoutedEventHandler(OnLoaded);

            MouseLeftButtonDown += new MouseButtonEventHandler(OnClicked);
		}

        void OnClicked(object sender, MouseButtonEventArgs e)
        {
            if (WedgeSelected != null)
            {
                WedgeSelected(this, null);
            }
            SetSelected(true, true);
        }

        public void SetSelected(bool isSelected, bool animate)
        {
            if (m_IsSelected == isSelected)
            {
                return;
            }
            m_IsSelected = isSelected;
            VisualStateManager.GoToState(this, m_IsSelected ? "Selected" : "NotSelected", animate);
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateItem();
        }

        private MediaItem m_MediaItem;
        public MediaItem MediaItem
        {
            get
            {
                return m_MediaItem;
            }
            set
            {
                if (m_MediaItem == value)
                {
                    return;
                }
                m_MediaItem = value;
                UpdateItem();
            }
        }

        private bool m_IsSelected;
        public bool IsSelected
        {
            get
            {
                return m_IsSelected;
            }
            set
            {
                SetSelected(value, false);
            }
        }

        private void UpdateItem()
        {
            if (m_MediaItem == null)
            {
                VisualStateManager.GoToState(this, "None", false);
            }
            else
            {
                VisualStateManager.GoToState(this,m_MediaItem.IsVideo ?  "Video": "Image", false);
                Thumb.Fill = new ImageBrush { ImageSource = m_MediaItem.ThumbnailBitmap };
            }
        }
	}
}