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

namespace silverscreenPrototype.Behaviors
{
    public class DragBehavior : System.Windows.Interactivity.Behavior<FrameworkElement>
    {
        private MouseButtonEventHandler m_ClickHandler;
        private MouseEventHandler m_MouseMoveHandler;
        private MouseButtonEventHandler m_MouseUpHandler;
        private TranslateTransform m_Translation;
        private Point m_ClickPoint;
        private Point m_TranslationOrigin;
        private MouseEventHandler m_MouseCaptureLostHandler;

        public DragBehavior()
        {
            m_ClickHandler = new MouseButtonEventHandler(AssociatedObject_MouseLeftButtonDown);
            m_MouseMoveHandler = new MouseEventHandler(OnMouseMove);
            m_MouseUpHandler = new MouseButtonEventHandler(OnMouseUp);
            m_MouseCaptureLostHandler = new MouseEventHandler(OnMouseCaptureLost);
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            if (AssociatedObject.RenderTransform is TranslateTransform)
            {
                m_Translation = AssociatedObject.RenderTransform as TranslateTransform;
            }
            else if (AssociatedObject.RenderTransform is TransformGroup)
            {
                TransformGroup group = AssociatedObject.RenderTransform as TransformGroup;
                for (int i = 0; i < group.Children.Count; i++)
                {
                    if (group.Children[i] is TranslateTransform)
                    {
                        m_Translation = group.Children[i] as TranslateTransform;
                    }
                }
            }
            else if (AssociatedObject.RenderTransform is MatrixTransform)
            {
                AssociatedObject.RenderTransform = m_Translation = new TranslateTransform();
            }
            else if (AssociatedObject.RenderTransform == null)
            {
                AssociatedObject.RenderTransform = m_Translation = new TranslateTransform();
            }

            if (m_Translation != null)
            {
                m_Translation.X = OriginX;
                m_Translation.Y = OriginY;
            }
            AssociatedObject.MouseLeftButtonUp += m_MouseUpHandler;
            AssociatedObject.MouseLeftButtonDown += m_ClickHandler;
            AssociatedObject.LostMouseCapture += m_MouseCaptureLostHandler;
        }

        void OnMouseCaptureLost(object sender, MouseEventArgs e)
        {
            AssociatedObject.MouseMove -= m_MouseMoveHandler;
        }

        void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            AssociatedObject.MouseMove -= m_MouseMoveHandler;
            AssociatedObject.ReleaseMouseCapture();
        }

        void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AssociatedObject.MouseMove += m_MouseMoveHandler;
            AssociatedObject.CaptureMouse();
            m_ClickPoint = e.GetPosition(AssociatedObject.Parent as FrameworkElement);
            if (m_Translation == null)
            {
                return;
            }
            m_TranslationOrigin = new Point(m_Translation.X, m_Translation.Y);
        }

        void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (m_Translation == null)
            {
                return;
            }
            Point movePoint = e.GetPosition(AssociatedObject.Parent as FrameworkElement);
            m_Translation.X = m_TranslationOrigin.X + (movePoint.X - m_ClickPoint.X);
            m_Translation.Y = m_TranslationOrigin.Y + (movePoint.Y - m_ClickPoint.Y);
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonUp -= m_MouseUpHandler;
            AssociatedObject.MouseLeftButtonDown -= m_ClickHandler;
            AssociatedObject.LostMouseCapture -= m_MouseCaptureLostHandler;
        }

        public double OriginX
        {
            get;
            set;
        }

        public double OriginY
        {
            get;
            set;
        }
    }
}
