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

namespace silverscreenPrototype
{
    public class PositionSliderChangedArgs : EventArgs
    {
        public PositionSliderChangedArgs(double value)
        {
            Value = value;
        }

        public double Value
        {
            get;
            private set;
        }
    }
    public delegate void PositionSliderChangedEventHandler(object sender, PositionSliderChangedArgs e);

    [TemplatePart(Name = PositionSlider.Scrubber, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = PositionSlider.Track, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = PositionSlider.ProgressTrack, Type = typeof(FrameworkElement))]
    public class PositionSlider : Control
    {
        public event PositionSliderChangedEventHandler ValueChanged;

        private const string Scrubber = "Scrubber";
        private const string Track = "Track";
        private const string ProgressTrack = "ProgressTrack";

        private FrameworkElement m_Scrubber;
        private FrameworkElement m_Track;
        private FrameworkElement m_ProgressTrack;

        private Storyboard mValueAnimation;
        private DoubleAnimation mValueDoubleAnimation;
        private TranslateTransform mScrubberTranslation;
        private MouseEventHandler mScrubberMouseMoveHandler;
        private bool mInteracting;
        private bool mDragged;

        public PositionSlider()
        {
            mValueAnimation = new Storyboard();
            mValueDoubleAnimation = new DoubleAnimation();
            mValueDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.3));
            Storyboard.SetTarget(mValueDoubleAnimation, this);
            Storyboard.SetTargetProperty(mValueDoubleAnimation, new PropertyPath("(PositionSlider.Value)"));
            mValueAnimation.Children.Add(mValueDoubleAnimation);
            CircleEase circleEasing = new CircleEase();
            circleEasing.EasingMode = EasingMode.EaseInOut;
            mValueDoubleAnimation.EasingFunction = circleEasing;
            mValueAnimation.Completed += new EventHandler(mValueAnimation_Completed);
            mValueAnimation.FillBehavior = FillBehavior.HoldEnd;
            mScrubberMouseMoveHandler = new MouseEventHandler(OnScrubberMouseMoved);
            SizeChanged += new SizeChangedEventHandler(Slider_SizeChanged);
        }

        void mValueAnimation_Completed(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, new PositionSliderChangedArgs(mValueDoubleAnimation.To.Value));
            mInteracting = false;
        }

        void Slider_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateValue();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            m_Scrubber = GetTemplateChild(PositionSlider.Scrubber) as FrameworkElement;
            m_Track = GetTemplateChild(PositionSlider.Track) as FrameworkElement;
            m_ProgressTrack = GetTemplateChild(PositionSlider.ProgressTrack) as FrameworkElement;

            if (m_Scrubber != null)
            {
                m_Scrubber.RenderTransform = mScrubberTranslation = new TranslateTransform();
                m_Scrubber.MouseLeftButtonDown += new MouseButtonEventHandler(OnScrubberMouseLeftButtonDown);
                MouseLeftButtonUp += new MouseButtonEventHandler(OnMouseLeftButtonUp);
            }

            if (m_Track != null)
            {
                m_Track.MouseLeftButtonDown += new MouseButtonEventHandler(OnTrackMouseLeftButtonDown);
            }

            UpdateValue();
        }

        void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ReleaseMouseCapture();
            MouseMove -= mScrubberMouseMoveHandler;

            if (mDragged && ValueChanged != null)
                ValueChanged(this, new PositionSliderChangedArgs(Value));

            if (mDragged)
                mInteracting = false;
        }

        void OnScrubberMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mDragged = false;
            CaptureMouse();
            mInteracting = true;
            MouseMove += mScrubberMouseMoveHandler;
        }

        void OnScrubberMouseMoved(object sender, MouseEventArgs e)
        {
            mDragged = true;
            double swidth = m_Scrubber.ActualWidth;
            SetValue(ValueProperty, Math.Max(0, Math.Min(1, (e.GetPosition(m_Track).X - swidth / 2.0) / (m_Track.ActualWidth - swidth))));
        }

        void OnTrackMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            double swidth = m_Scrubber.ActualWidth;
            Position = Math.Max(0, Math.Min(1, (e.GetPosition(m_Track).X - swidth / 2.0) / (m_Track.ActualWidth - swidth)));
        }

        /// <summary>
        /// Animate the position to the target value.
        /// </summary>
        public double Position
        {
            get
            {
                return Value;
            }
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                    return;
                mInteracting = true;

                mValueDoubleAnimation.To = value;
                mValueAnimation.Begin();
            }
        }

        /// <summary>
        /// The position of the slider from 0.0 to 1.0.
        /// </summary>
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                    return;
                if (mInteracting) return;
                SetValue(ValueProperty, value);
            }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(PositionSlider), new PropertyMetadata(0.0, OnValueChanged));

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs events)
        {
            PositionSlider slider = obj as PositionSlider;
            slider.UpdateValue();
        }

        private void UpdateValue()
        {
            if (m_Scrubber == null) return;
            if (double.IsNaN(Value) || double.IsInfinity(Value))
                return;

            //if (Value == 0)
            //    System.Diagnostics.Debug.WriteLine("ER");
            mScrubberTranslation.X = (m_Track.ActualWidth - m_Scrubber.ActualWidth) * Value;
            if (m_ProgressTrack != null)
                m_ProgressTrack.Width = mScrubberTranslation.X + m_Scrubber.ActualWidth;
        }
    }

}
