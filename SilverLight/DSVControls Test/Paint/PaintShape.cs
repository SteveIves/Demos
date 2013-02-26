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

namespace Paint
{
    public class PaintShape : ContentControl
    {
        private bool dragging = false;
        private Point lastDragPosition = new Point();
        private int resizing = -1;
        
        #region public bool IsSelected

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
                DependencyProperty.Register(
                        "IsSelected",
                        typeof(bool),
                        typeof(PaintShape),
                        new PropertyMetadata(false, new PropertyChangedCallback(OnIsSelectedChanged)));

        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PaintShape ps = (PaintShape)d;
            if (e.OldValue != e.NewValue) ps.OnIsSelectedChanged();
        }

        #endregion

        //internal bool IsPainting { get; set; }

        #region public double StrokeThickness

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty StrokeThicknessProperty =
                DependencyProperty.Register(
                        "StrokeThickness",
                        typeof(double),
                        typeof(PaintShape),
                        new PropertyMetadata(double.NaN, new PropertyChangedCallback(OnStrokeThicknessChanged)));

        private static void OnStrokeThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PaintShape ps = (PaintShape)d;
            ps.OnStrokeThicknessChanged();
        }

        #endregion

        #region public Brush Stroke

        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public static readonly DependencyProperty StrokeProperty =
                DependencyProperty.Register(
                        "Stroke",
                        typeof(Brush),
                        typeof(PaintShape),
                        new PropertyMetadata(null, new PropertyChangedCallback(OnStrokeChanged)));

        private static void OnStrokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PaintShape ps = (PaintShape)d;
            ps.OnStrokeChanged();
        }

        #endregion

        #region public Brush Fill

        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public static readonly DependencyProperty FillProperty =
                DependencyProperty.Register(
                        "Fill",
                        typeof(Brush),
                        typeof(PaintShape),
                        new PropertyMetadata(null, new PropertyChangedCallback(OnFillChanged)));

        private static void OnFillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PaintShape ps = (PaintShape)d;
            ps.OnFillChanged();
        }

        #endregion

        #region public double FontSize

        new public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        new public static readonly DependencyProperty FontSizeProperty =
                DependencyProperty.Register(
                        "FontSize",
                        typeof(double),
                        typeof(PaintShape),
                        new PropertyMetadata(double.NaN, new PropertyChangedCallback(OnFontSizeChanged)));

        private static void OnFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PaintShape ps = (PaintShape)d;
            ps.OnFontSizeChanged();
        }

        #endregion

        #region public FontFamily FontFamily

        new public FontFamily FontFamily
        {
            get { return (FontFamily)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        new public static readonly DependencyProperty FontFamilyProperty =
                DependencyProperty.Register(
                        "FontFamily",
                        typeof(FontFamily),
                        typeof(PaintShape),
                        new PropertyMetadata(null, new PropertyChangedCallback(OnFontFamilyChanged)));

        private static void OnFontFamilyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PaintShape ps = (PaintShape)d;
            ps.OnFontFamilyChanged();
        }

        #endregion

        #region public FontWeight FontWeight

        new public FontWeight FontWeight
        {
            get { return (FontWeight)GetValue(FontWeightProperty); }
            set { SetValue(FontWeightProperty, value); }
        }

        new public static readonly DependencyProperty FontWeightProperty =
                DependencyProperty.Register(
                        "FontWeight",
                        typeof(FontWeight),
                        typeof(PaintShape),
                        new PropertyMetadata(FontWeights.Normal, new PropertyChangedCallback(OnFontWeightChanged)));

        private static void OnFontWeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PaintShape ps = (PaintShape)d;
            ps.OnFontWeightChanged();
        }

        #endregion

        #region public FontStyle FontStyle

        new public FontStyle FontStyle
        {
            get { return (FontStyle)GetValue(FontStyleProperty); }
            set { SetValue(FontStyleProperty, value); }
        }

        new public static readonly DependencyProperty FontStyleProperty =
                DependencyProperty.Register(
                        "FontStyle",
                        typeof(FontStyle),
                        typeof(PaintShape),
                        new PropertyMetadata(FontStyles.Normal, new PropertyChangedCallback(OnFontStyleChanged)));

        private static void OnFontStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PaintShape ps = (PaintShape)d;
            ps.OnFontStyleChanged();
        }

        #endregion

        #region public TextDecorationCollection TextDecorations

        public TextDecorationCollection TextDecorations
        {
            get { return (TextDecorationCollection)GetValue(TextDecorationsProperty); }
            set { SetValue(TextDecorationsProperty, value); }
        }

        public static readonly DependencyProperty TextDecorationsProperty =
                DependencyProperty.Register(
                        "TextDecorations",
                        typeof(TextDecorationCollection),
                        typeof(PaintShape),
                        new PropertyMetadata(null, new PropertyChangedCallback(OnTextDecorationsChanged)));

        private static void OnTextDecorationsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PaintShape ps = (PaintShape)d;
            ps.OnTextDecorationsChanged();
        }

        #endregion

        #region public Brush TextColor

        public Brush TextColor
        {
            get { return (Brush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly DependencyProperty TextColorProperty =
                DependencyProperty.Register(
                        "TextColor",
                        typeof(Brush),
                        typeof(PaintShape),
                        new PropertyMetadata(null, new PropertyChangedCallback(OnTextColorChanged)));

        private static void OnTextColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PaintShape ps = (PaintShape)d;
            ps.OnTextColorChanged();
        }

        #endregion

        #region public Brush TextBackground

        public Brush TextBackground
        {
            get { return (Brush)GetValue(TextBackgroundProperty); }
            set { SetValue(TextBackgroundProperty, value); }
        }

        public static readonly DependencyProperty TextBackgroundProperty =
                DependencyProperty.Register(
                        "TextBackground",
                        typeof(Brush),
                        typeof(PaintShape),
                        new PropertyMetadata(null, new PropertyChangedCallback(OnTextBackgroundChanged)));

        private static void OnTextBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PaintShape ps = (PaintShape)d;
            ps.OnTextBackgroundChanged();
        }

        #endregion

        public bool IsMouseOver { get; set; }

        public PaintShapesType Type { get; set; }

        public event RoutedEventHandler Selected;
        public event RoutedEventHandler Unselected;
        
        public PaintShape()
        {
            this.DefaultStyleKey = typeof(PaintShape);

            //this.IsPainting = true;
            this.IsMouseOver = false;

            Loaded += new RoutedEventHandler(PaintShape_Loaded);
        }

        void PaintShape_Loaded(object sender, RoutedEventArgs e)
        {
            this.ApplyTemplate();

            OnIsSelectedChanged();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Grid selectionFrame = GetTemplateChild("SelectionFrame") as Grid;
            foreach (FrameworkElement child in selectionFrame.Children)
            {
                if (child.Tag != null)
                {
                    child.MouseLeftButtonDown += new MouseButtonEventHandler(ResizeMarker_MouseLeftButtonDown);
                }
            }
        }
        
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            //if (IsPainting)
            //{
            //    this.IsSelected = false;
            //}
            //else
            {
                //if (!this.IsSelected)
                {
                    this.IsSelected = true;
                }
            }

            this.CaptureMouse();
            lastDragPosition = e.GetPosition(this.Parent as FrameworkElement);
            if (resizing == -1) dragging = true;
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            this.ReleaseMouseCapture();
            dragging = false;
            resizing = -1;
            //IsPainting = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Point currentCanvasPosition = new Point();

            Point position = e.GetPosition(this.Parent as FrameworkElement);
            if (position.X < 0)
            {
                position.X = 0;
            }
            else if (position.X >= (this.Parent as FrameworkElement).ActualWidth)
            {
                position.X = (this.Parent as FrameworkElement).ActualWidth - 1;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
            else if (position.Y >= (this.Parent as FrameworkElement).ActualHeight)
            {
                position.Y = (this.Parent as FrameworkElement).ActualHeight - 1;
            }

            if (resizing > -1)
            {
                if (resizing == 0 || resizing == 4 || resizing == 5)
                {
                    if (this.Height + (this.lastDragPosition.Y - position.Y) >= 10)
                    {
                        this.Height += this.lastDragPosition.Y - position.Y;
                        currentCanvasPosition.Y = Canvas.GetTop(this) + position.Y - this.lastDragPosition.Y;
                        Canvas.SetTop(this, currentCanvasPosition.Y);
                    }
                    else
                    {
                        this.Height = 10;
                    }
                }
                if (resizing == 1 || resizing == 6 || resizing == 7)
                {
                    if (this.Height - (this.lastDragPosition.Y - position.Y) >= 10)
                    {
                        this.Height -= this.lastDragPosition.Y - position.Y;
                    }
                    else
                    {
                        this.Height = 10;
                    }
                }
                if (resizing == 2 || resizing == 4 || resizing == 6)
                {
                    if (this.Width + (this.lastDragPosition.X - position.X) >= 10)
                    {
                        this.Width += this.lastDragPosition.X - position.X;
                        currentCanvasPosition.X = Canvas.GetLeft(this) + position.X - this.lastDragPosition.X;
                        Canvas.SetLeft(this, currentCanvasPosition.X);
                    }
                    else
                    {
                        this.Width = 10;
                    }
                }
                if (resizing == 3 || resizing == 5 || resizing == 7)
                {
                    if (this.Width - (this.lastDragPosition.X - position.X) >= 10)
                    {
                        this.Width -= this.lastDragPosition.X - position.X;
                    }
                    else
                    {
                        this.Width = 10;
                    }
                }
            }

            if (dragging)
            {
                currentCanvasPosition.X = Canvas.GetLeft(this) + position.X - this.lastDragPosition.X;
                currentCanvasPosition.Y = Canvas.GetTop(this) + position.Y - this.lastDragPosition.Y;

                Canvas.SetLeft(this, currentCanvasPosition.X);
                Canvas.SetTop(this, currentCanvasPosition.Y);
            }

            lastDragPosition = position;
        }

        void ResizeMarker_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch ((sender as FrameworkElement).Tag.ToString())
            {
                case "Up":
                    resizing = 0;
                    break;
                case "Down":
                    resizing = 1;
                    break;
                case "Left":
                    resizing = 2;
                    break;
                case "Right":
                    resizing = 3;
                    break;
                case "LeftUp":
                    resizing = 4;
                    break;
                case "RightUp":
                    resizing = 5;
                    break;
                case "LeftDown":
                    resizing = 6;
                    break;
                case "RightDown":
                    resizing = 7;
                    break;
            }
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);

            this.IsMouseOver = true;
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);

            this.IsMouseOver = false;
        }

        protected virtual void OnIsSelectedChanged()
        {
            //if (IsPainting) return;
            VisualStateManager.GoToState(this, (this.IsSelected ? "SelectionShow" : "SelectionHide"), true);

            if (IsSelected) OnSelected(new RoutedEventArgs());
            else OnUnselected(new RoutedEventArgs());
        }

        protected virtual void OnStrokeThicknessChanged()
        {
            if (this.Content != null && this.Content is Shape)
            {
                (this.Content as Shape).StrokeThickness = this.StrokeThickness;
            }
        }

        protected virtual void OnStrokeChanged()
        {
            if (this.Content != null && this.Content is Shape)
            {
                (this.Content as Shape).Stroke = this.Stroke;
            }
        }

        protected virtual void OnFillChanged()
        {
            if (this.Content != null && this.Content is Shape)
            {
                (this.Content as Shape).Fill = this.Fill;
            }
        }

        protected virtual void OnFontSizeChanged()
        {
            if (this.Content != null && this.Content is TextBlock)
            {
                (this.Content as TextBlock).FontSize = this.FontSize;
            }
        }

        protected virtual void OnFontFamilyChanged()
        {
            if (this.Content != null && this.Content is TextBlock)
            {
                (this.Content as TextBlock).FontFamily = this.FontFamily;
            }
        }

        protected virtual void OnFontWeightChanged()
        {
            if (this.Content != null && this.Content is TextBlock)
            {
                (this.Content as TextBlock).FontWeight = this.FontWeight;
            }
        }

        protected virtual void OnTextDecorationsChanged()
        {
            if (this.Content != null && this.Content is TextBlock)
            {
                (this.Content as TextBlock).TextDecorations = this.TextDecorations;
            }
        }

        protected virtual void OnFontStyleChanged()
        {
            if (this.Content != null && this.Content is TextBlock)
            {
                (this.Content as TextBlock).FontStyle = this.FontStyle;
            }
        }

        protected virtual void OnTextColorChanged()
        {
            if (this.Content != null && this.Content is TextBlock)
            {
                (this.Content as TextBlock).Foreground = this.TextColor;
            }
        }

        protected virtual void OnTextBackgroundChanged()
        {
            if (this.Content != null && this.Content is TextBlock)
            {
                this.Background = this.TextBackground;
            }
        }

        protected virtual void OnSelected(RoutedEventArgs e)
        {
            if (Selected != null) Selected(this, e);
        }

        protected virtual void OnUnselected(RoutedEventArgs e)
        {
            if (Unselected != null) Unselected(this, e);
        }
    }
}
