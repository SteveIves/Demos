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
    /// <summary>
    /// This control allows the user to click anywhere on the Silverlight app and extract the color at that pixel.
    /// </summary>
	public partial class ScreenColorPicker : UserControl
	{
        private Rectangle m_ColorSelectionHitter;
        private Panel m_Panel;

		public ScreenColorPicker()
		{
			// Required to initialize variables
			InitializeComponent();
            ColorSelector.MouseLeftButtonDown += new MouseButtonEventHandler(OnClickSelector);
            m_ColorSelectionHitter = new Rectangle { Fill = new SolidColorBrush(new Color { A = 0, G = 0, B = 0, R = 0 }) };
            m_ColorSelectionHitter.MouseLeftButtonDown += new MouseButtonEventHandler(OnClickColorSelector);
		}

        void OnClickColorSelector(object sender, MouseButtonEventArgs e)
        {
            WriteableBitmap bmp = new WriteableBitmap(1, 1);
            Point p = e.GetPosition(m_Panel);
            bmp.Render(m_Panel, new TranslateTransform { X = -p.X, Y = -p.Y });
            bmp.Invalidate();
            m_Panel.Children.Remove(m_ColorSelectionHitter);
            int pixel = bmp.Pixels[0];
            Color = Color.FromArgb(255, (byte)(pixel >> 16), (byte)(pixel >> 8), (byte)pixel);
        }

        void OnClickSelector(object sender, MouseButtonEventArgs e)
        {
            ColorText.Text = "Click anywhere!";
            m_Panel = null;
            for (DependencyObject parent = VisualTreeHelper.GetParent(this); parent != null; parent = VisualTreeHelper.GetParent(parent))
            {
                if (parent is Panel)
                {
                    m_Panel = parent as Panel;
                }
            }
            if (m_Panel != null)
            {
                m_Panel.Children.Add(m_ColorSelectionHitter);
            }
        }


        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Color), typeof(ScreenColorPicker), new PropertyMetadata(Color.FromArgb(255,255,0,0), OnColorValueChanged));

        static void OnColorValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScreenColorPicker picker = d as ScreenColorPicker;
            picker.OnColorChanged();
        }

        private void OnColorChanged()
        {
            ColorSwatch.Fill = new SolidColorBrush(Color);
            ColorText.Text = Color.ToString();
        }
        
	}
}