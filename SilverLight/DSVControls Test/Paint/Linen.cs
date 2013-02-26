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
using System.Windows.Ink;
using System.Collections.ObjectModel;

namespace Paint
{
    public class Linen : ItemsControl
    {
        private bool dragging = false;
        private Point lastDragPosition = new Point();
        private InkCollector inkCollector = null;

        public PaintShape SelectedItem { get; set; }

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
                        typeof(Linen),
                        new PropertyMetadata(double.NaN, new PropertyChangedCallback(OnStrokeThicknessChanged)));

        private static void OnStrokeThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Linen l = (Linen)d;
            l.OnStrokeThicknessChanged();
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
                        typeof(Linen),
                        new PropertyMetadata(null, new PropertyChangedCallback(OnStrokeChanged)));

        private static void OnStrokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Linen l = (Linen)d;
            l.OnStrokeChanged();
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
                        typeof(Linen),
                        new PropertyMetadata(null, new PropertyChangedCallback(OnFillChanged)));

        private static void OnFillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Linen l = (Linen)d;
            l.OnFillChanged();
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
                        typeof(Linen),
                        new PropertyMetadata(double.NaN, new PropertyChangedCallback(OnFontSizeChanged)));

        private static void OnFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Linen l = (Linen)d;
            l.OnFontSizeChanged();
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
                        typeof(Linen),
                        new PropertyMetadata(null, new PropertyChangedCallback(OnFontFamilyChanged)));

        private static void OnFontFamilyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Linen l = (Linen)d;
            l.OnFontFamilyChanged();
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
                        typeof(Linen),
                        new PropertyMetadata(FontWeights.Normal, new PropertyChangedCallback(OnFontWeightChanged)));

        private static void OnFontWeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Linen l = (Linen)d;
            l.OnFontWeightChanged();
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
                        typeof(Linen),
                        new PropertyMetadata(FontStyles.Normal, new PropertyChangedCallback(OnFontStyleChanged)));

        private static void OnFontStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Linen l = (Linen)d;
            l.OnFontStyleChanged();
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
                        typeof(Linen),
                        new PropertyMetadata(null, new PropertyChangedCallback(OnTextDecorationsChanged)));

        private static void OnTextDecorationsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Linen l = (Linen)d;
            l.OnTextDecorationsChanged();
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
                        typeof(Linen),
                        new PropertyMetadata(null, new PropertyChangedCallback(OnTextColorChanged)));

        private static void OnTextColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Linen l = (Linen)d;
            l.OnTextColorChanged();
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
                        typeof(Linen),
                        new PropertyMetadata(null, new PropertyChangedCallback(OnTextBackgroundChanged)));

        private static void OnTextBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Linen l = (Linen)d;
            l.OnTextBackgroundChanged();
        }

        #endregion

        #region public DrawingModes DrawingMode

        public DrawingModes DrawingMode
        {
            get { return (DrawingModes)GetValue(DrawingModeProperty); }
            set { SetValue(DrawingModeProperty, value); }
        }

        public static readonly DependencyProperty DrawingModeProperty =
                DependencyProperty.Register(
                        "DrawingMode",
                        typeof(DrawingModes),
                        typeof(Linen),
                        new PropertyMetadata(DrawingModes.None, new PropertyChangedCallback(OnDrawingModeChanged)));

        private static void OnDrawingModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Linen l = (Linen)d;
            l.OnDrawingModeChanged();
        }

        #endregion

        #region public DrawingAttributes DrawingBrush
        public DrawingAttributes DrawingBrush
        {
            get 
            {
                return inkCollector.DefaultDrawingAttributes; 
            }
            set 
            {
                inkCollector.DefaultDrawingAttributes = value; 
                
            }
        }

        #endregion

        public event ShapeSelectEventHandler ShapeSelected;

        public Linen()
        {
            this.DefaultStyleKey = typeof(Linen);

            DrawingMode = DrawingModes.None;

            Loaded += (sender, e) => ApplyTemplate();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            InkPresenter ink = GetTemplateChild("Ink") as InkPresenter;
            RectangleGeometry MyRectangleGeometry = new RectangleGeometry();
            MyRectangleGeometry.Rect = new Rect(0, 0, this.Width, this.Height);
            ink.Clip = MyRectangleGeometry;
            inkCollector = new InkCollector(ink);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new PaintShape();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is PaintShape;
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            PaintShape shape = element as PaintShape;
            //int i = ItemContainerGenerator.IndexFromContainer(element);

            if (shape != null)
            {
                base.PrepareContainerForItemOverride(element, item);

                shape.Selected += shape_Selected;

                shape.StrokeThickness = this.StrokeThickness;
                shape.Stroke = this.Stroke;
                shape.Fill = this.Fill;
                shape.FontSize = this.FontSize;
                shape.FontFamily = this.FontFamily;
                shape.FontWeight = this.FontWeight;
                shape.FontStyle = this.FontStyle;
                shape.TextDecorations = this.TextDecorations;
                shape.TextColor = this.TextColor;
                shape.TextBackground = this.TextBackground;

            }
        }

        void shape_Selected(object sender, RoutedEventArgs e)
        {
            foreach (PaintShape ps in Items)
            {
                if ((sender as PaintShape) != ps) ps.IsSelected = false;
            }

            if (this.SelectedItem != sender)
            {
                this.SelectedItem = sender as PaintShape;

                OnShapeSelected(new ShapeSelectEventArgs(sender as PaintShape));
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if (!Items.Any(i => (i as PaintShape).IsMouseOver))
            {
                HideSelection();
            }
        }

        public void HideSelection()
        {
            foreach (PaintShape ps in Items)
            {
                ps.IsSelected = false;
            }

            if (this.SelectedItem != null)
            {
                this.SelectedItem = null;

                OnShapeSelected(new ShapeSelectEventArgs(null));
            }
        }

        private void OnStrokeThicknessChanged()
        {
            if (this.SelectedItem != null)
            {
                this.SelectedItem.StrokeThickness = this.StrokeThickness;
            }

            if (inkCollector != null)
            {
                inkCollector.DefaultDrawingAttributes.Height = this.StrokeThickness;
                inkCollector.DefaultDrawingAttributes.Width = this.StrokeThickness;
            }
        }

        private void OnStrokeChanged()
        {
            if (this.SelectedItem != null)
            {
                this.SelectedItem.Stroke = this.Stroke;
            }

            if (inkCollector != null)
            {
                if (this.Stroke is SolidColorBrush)
                {
                    inkCollector.DefaultDrawingAttributes.OutlineColor = (this.Stroke as SolidColorBrush).Color;
                }
                else if (this.Stroke is LinearGradientBrush)
                {
                    inkCollector.DefaultDrawingAttributes.OutlineColor = (this.Stroke as LinearGradientBrush).GradientStops[0].Color;
                }
                else if (this.Stroke is RadialGradientBrush)
                {
                    inkCollector.DefaultDrawingAttributes.OutlineColor = (this.Stroke as RadialGradientBrush).GradientStops[0].Color;
                }
            }
        }

        private void OnFillChanged()
        {
            if (this.SelectedItem != null)
            {
                this.SelectedItem.Fill = this.Fill;
            }

            if (inkCollector != null)
            {
                if (this.Fill is SolidColorBrush)
                {
                    inkCollector.DefaultDrawingAttributes.Color = (this.Fill as SolidColorBrush).Color;
                }
                else if (this.Fill is LinearGradientBrush)
                {
                    inkCollector.DefaultDrawingAttributes.Color = (this.Fill as LinearGradientBrush).GradientStops[0].Color;
                }
                else if (this.Fill is RadialGradientBrush)
                {
                    inkCollector.DefaultDrawingAttributes.Color = (this.Fill as RadialGradientBrush).GradientStops[0].Color;
                }
            }
        }

        private void OnFontSizeChanged()
        {
            if (this.SelectedItem == null) return;

            this.SelectedItem.FontSize = this.FontSize;
        }

        private void OnFontFamilyChanged()
        {
            if (this.SelectedItem == null) return;

            this.SelectedItem.FontFamily = this.FontFamily;
        }

        private void OnFontWeightChanged()
        {
            if (this.SelectedItem == null) return;

            this.SelectedItem.FontWeight = this.FontWeight;
        }

        private void OnTextDecorationsChanged()
        {
            if (this.SelectedItem == null) return;

            this.SelectedItem.TextDecorations = this.TextDecorations;
        }

        private void OnFontStyleChanged()
        {
            if (this.SelectedItem == null) return;

            this.SelectedItem.FontStyle = this.FontStyle;
        }

        private void OnTextColorChanged()
        {
            if (this.SelectedItem == null) return;

            this.SelectedItem.TextColor = this.TextColor;
        }

        private void OnTextBackgroundChanged()
        {
            if (this.SelectedItem == null) return;

            this.SelectedItem.TextBackground = this.TextBackground;
        }

        private void OnDrawingModeChanged()
        {
            if (this.DrawingMode == DrawingModes.Ink)
            {
                inkCollector.Mode = InkMode.Ink;
            }
            else if (this.DrawingMode == DrawingModes.Eraser)
            {
                inkCollector.Mode = InkMode.PointErase;
            }
            else
            {
                inkCollector.Mode = InkMode.None;
            }
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            HideSelection();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
        }

        //ink
        //Stroke MyStroke;
        //DrawingAttributes MyDA = new DrawingAttributes() { Height=3, Color=Colors.Black, Width=3 };
        //void ink_LostMouseCapture(object sender, MouseEventArgs e)
        //{
        //    if (this.DrawingMode != DrawingModes.Ink) return;
            
        //    MyStroke = null;
        //}

        //void ink_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (this.DrawingMode != DrawingModes.Ink) return;
            
        //    InkPresenter ink = sender as InkPresenter;

        //    if (MyStroke != null)
        //        MyStroke.StylusPoints.Add(e.StylusDevice.GetStylusPoints(ink));

        //}

        //void ink_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (this.DrawingMode != DrawingModes.Ink) return;
            
        //    InkPresenter ink = sender as InkPresenter;

        //    ink.CaptureMouse();
        //    StylusPointCollection MyStylusPointCollection = new StylusPointCollection();
        //    MyStylusPointCollection.Add(e.StylusDevice.GetStylusPoints(ink));
        //    MyStroke = new Stroke(MyStylusPointCollection);
        //    MyStroke.DrawingAttributes = CloneDrawingAttributes(MyDA);
        //    ink.Strokes.Add(MyStroke);

        //}

        //private DrawingAttributes CloneDrawingAttributes(DrawingAttributes attributes)
        //{
        //    if (attributes == null) return attributes;

        //    DrawingAttributes cloneAttribute = new DrawingAttributes();
        //    cloneAttribute.Color = attributes.Color;
        //    cloneAttribute.Height = attributes.Height;
        //    cloneAttribute.OutlineColor = attributes.OutlineColor;
        //    cloneAttribute.Width = attributes.Width;
        //    return cloneAttribute;
        //}


        protected virtual void OnShapeSelected(ShapeSelectEventArgs e)
        {
            if (ShapeSelected != null) ShapeSelected(this, e);
        }
    }
}
