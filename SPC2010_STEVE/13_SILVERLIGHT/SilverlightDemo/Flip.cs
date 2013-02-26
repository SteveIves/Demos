using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Interactivity;
using System.ComponentModel;

namespace SilverlightDemo
{
    public enum RotationDirection
    {
        LeftToRight,
        RightToLeft,
        TopToBottom,
        BottomToTop
    }

    public class Flip : TriggerAction<FrameworkElement>
    {
        public static readonly DependencyProperty FrontElementNameProperty =
            DependencyProperty.Register("FrontElementName", typeof(string),
                                        typeof(Flip), new PropertyMetadata(null));

        [Category("Flip Properties")]
        public string FrontElementName { get; set; }

        public static readonly DependencyProperty BackElementNameProperty =
            DependencyProperty.Register("BackElementName", typeof(string),
                                        typeof(Flip), new PropertyMetadata(null));

        [Category("Flip Properties")]
        public string BackElementName { get; set; }

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(Duration),
                                        typeof(Flip), new PropertyMetadata(null));

        [Category("Animation Properties")]
        public Duration Duration { get; set; }

        public static readonly DependencyProperty RotationProperty =
            DependencyProperty.Register("Rotation", typeof(RotationDirection),
                                        typeof(Flip), new PropertyMetadata(RotationDirection.LeftToRight));

        [Category("Animation Properties")]
        public RotationDirection Rotation { get; set; }

        private readonly Storyboard _sbF = new Storyboard();
        private readonly Storyboard _sbB = new Storyboard();
        private bool _forward = true;

        protected override void Invoke(object parameter)
        {
            if (AssociatedObject.Projection == null)
            {
                FrameworkElement parent = AssociatedObject as FrameworkElement;
                UIElement f = null;
                UIElement b = null;

                if (parent != null)
                {
                    f = parent.FindName(FrontElementName) as UIElement;
                    if (f != null)
                    {
                        PlaneProjection ppFront = new PlaneProjection { CenterOfRotationY = .51 };
                        f.Projection = ppFront;
                        f.RenderTransformOrigin = new Point(.5, .5);
                    }
                    b = parent.FindName(BackElementName) as UIElement;
                    if (b != null)
                    {
                        PlaneProjection ppBack = new PlaneProjection { CenterOfRotationY = .51, RotationY = 180.0 };
                        b.Projection = ppBack;
                        b.RenderTransformOrigin = new Point(.5, .5);
                        b.Opacity = 0.0;
                    }
                }

                PlaneProjection pp = new PlaneProjection { CenterOfRotationY = .51 };

                AssociatedObject.RenderTransformOrigin = new Point(.5, .5);
                AssociatedObject.Projection = pp;

                double to = 180.0;
                double from = 0.0;
                string property = "RotationY";

                switch (Rotation)
                {
                    case RotationDirection.RightToLeft:
                        to = 0.0;
                        from = 180.0;
                        break;
                    case RotationDirection.TopToBottom:
                        property = "RotationX";
                        break;
                    case RotationDirection.BottomToTop:
                        to = 0.0;
                        from = 180.0;
                        property = "RotationX";
                        break;
                }

                _sbF.Duration = Duration;
                _sbB.Duration = Duration;

                _sbF.Children.Add(CreateDoubleAnimation(pp, property, from, to, true));
                _sbB.Children.Add(CreateDoubleAnimation(pp, property, to, from, true));

                _sbF.Children.Add(CreateDoubleAnimation(f, "Opacity", 1.0, 0.0, false));
                _sbB.Children.Add(CreateDoubleAnimation(f, "Opacity", 0.0, 1.0, false));

                _sbF.Children.Add(CreateDoubleAnimation(b, "Opacity", 0.0, 1.0, false));
                _sbB.Children.Add(CreateDoubleAnimation(b, "Opacity", 1.0, 0.0, false));
            }
            if (_forward)
            {
                _sbF.Begin();
                _forward = false;
            }
            else
            {
                _sbB.Begin();
                _forward = true;
            }
        }

        private static DoubleAnimation CreateDoubleAnimation(DependencyObject element, string property, double from,
                                                             double to, bool addEasing)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.To = to;
            da.From = from;
            if (addEasing)
                da.EasingFunction = new PowerEase() { EasingMode = EasingMode.EaseOut, Power = 3 };


            Storyboard.SetTargetProperty(da, new PropertyPath(property));
            Storyboard.SetTarget(da, element);
            return da;
        }
    }
}
