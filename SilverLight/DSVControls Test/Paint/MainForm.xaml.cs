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
using DSV.Controls.Windows;
using System.Windows.Media.Imaging;
using DSV.Controls.Menu.Ribbon;

namespace Paint
{
    public partial class MainForm : Form
    {
        private IList<Color> ColorsTable = new List<Color>()
        {
            Colors.Brown,
            Colors.Red,
            Colors.Orange,
            Colors.Yellow,
            Color.FromArgb(0xFF,0x90,0xEE,0x90),
            Colors.Green,
            Color.FromArgb(0xFF,0xAD,0xD8,0xE6),
            Colors.Blue,
            Color.FromArgb(0xFF,0x00,0x00,0x8B),
            Colors.Purple
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //image.Source = new WriteableBitmap(canvas, null);
        }

        //private void ToolsButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    foreach (RibbonToggleButton rtb in ((sender as RibbonToggleButton).Parent as RibbonBox).Children)
        //    {
        //        if (rtb != (sender as RibbonToggleButton)) rtb.IsChecked = false;
        //    }
        //}

        private void ColorsRibbonGallery_ItemsLoading(object sender, RoutedEventArgs e)
        {
            RibbonGallery rg = (sender as RibbonGallery);
            rg.Items.Clear();

            for (int i = 0; i < 10; i++)
            {
                BitmapImage bi = new BitmapImage(new Uri(string.Format("/Paint;component/Images/Colors/Color{0}.png", i), UriKind.Relative));
                RibbonDropDownItem rddi = new RibbonDropDownItem() 
                { 
                    Image = bi,
                    Tag = ColorsTable[i]
                };
                if (rg.Tag.ToString() == "StrokeColor")
                {
                    rddi.Selected += new RoutedEventHandler(StrokeColorChanged);
                }
                else if (rg.Tag.ToString() == "FillColor")
                {
                    rddi.Selected += new RoutedEventHandler(FillColorChanged);
                }
                else if (rg.Tag.ToString() == "TextColor")
                {
                    rddi.Selected += new RoutedEventHandler(TextColorChanged);
                }
                else if (rg.Tag.ToString() == "TextBackground")
                {
                    rddi.Selected += new RoutedEventHandler(TextBackgroundChanged);
                }
                rg.Items.Add(rddi);
            }
        }

        private void ShapeRibbonDropDownItem_Click(object sender, RoutedEventArgs e)
        {
            RibbonDropDownItem rddi = sender as RibbonDropDownItem;

            PaintShape shape = new PaintShape() { Width = 50, Height=50};
            if (rddi.Tag.ToString() == "Text")
            {
                shape.Content = new TextBlock() { Text = "Новый текст", TextWrapping= TextWrapping.Wrap};
                shape.Type = PaintShapesType.Text;
                canvas.DrawingMode = DrawingModes.Shape;
            }
            else if (rddi.Tag.ToString() == "Rectangle")
            {
                shape.Content = new Rectangle()
                {
                    Fill = new SolidColorBrush(Colors.Transparent)
                };
                shape.Type = PaintShapesType.Rectangle;
            }
            else if (rddi.Tag.ToString() == "Ellipse")
            {
                shape.Content = new Ellipse()
                {
                    Fill = new SolidColorBrush(Colors.Transparent)
                };
                shape.Type = PaintShapesType.Ellipse;
            }
            else if (rddi.Tag.ToString() == "RoundRectangle")
            {
                shape.Content = new Rectangle()
                {
                    Fill = new SolidColorBrush(Colors.Transparent),
                    RadiusX = 5, 
                    RadiusY = 5
                };
                shape.Type = PaintShapesType.RoundRectangle;
            }
            else if (rddi.Tag.ToString() == "Triangle")
            {
                PointCollection points = new PointCollection();
                points.Add(new Point(1000,0));
                points.Add(new Point(0,2000));
                points.Add(new Point(2000,2000));
                points.Add(new Point(1000,0));
                shape.Content = new Polygon()
                {
                    Fill = new SolidColorBrush(Colors.Transparent),
                    Points = points,
                    Stretch = Stretch.Fill
                };
                shape.Type = PaintShapesType.Triangle;
            }
            else if (rddi.Tag.ToString() == "ArrowRight")
            {
                PointCollection points = new PointCollection();
                points.Add(new Point(0, 500));
                points.Add(new Point(1000, 500));
                points.Add(new Point(1000, 0));
                points.Add(new Point(2000, 1000));
                points.Add(new Point(1000, 2000));
                points.Add(new Point(1000, 1500));
                points.Add(new Point(0, 1500));
                points.Add(new Point(0, 500));
                shape.Content = new Polygon()
                {
                    Fill = new SolidColorBrush(Colors.Transparent),
                    Points = points,
                    Stretch = Stretch.Fill
                };
                shape.Type = PaintShapesType.ArrowRight;
            }
            else if (rddi.Tag.ToString() == "ArrowDown")
            {
                PointCollection points = new PointCollection();
                points.Add(new Point(1500, 0));
                points.Add(new Point(1500, 1000));
                points.Add(new Point(2000, 1000));
                points.Add(new Point(1000, 2000));
                points.Add(new Point(0, 1000));
                points.Add(new Point(500, 1000));
                points.Add(new Point(500, 0));
                points.Add(new Point(1500, 0));
                shape.Content = new Polygon()
                {
                    Fill = new SolidColorBrush(Colors.Transparent),
                    Points = points,
                    Stretch = Stretch.Fill
                };
                shape.Type = PaintShapesType.ArrowDown;
            }
            else if (rddi.Tag.ToString() == "Star")
            {
                PointCollection points = new PointCollection();
                points.Add(new Point(1500, 0));
                points.Add(new Point(2000, 1500));
                points.Add(new Point(3000, 1500));
                points.Add(new Point(2200, 2500));
                points.Add(new Point(2700, 4000));
                points.Add(new Point(1500, 3300));
                points.Add(new Point(300, 4000));
                points.Add(new Point(800, 2500));
                points.Add(new Point(0, 1500));
                points.Add(new Point(1000, 1500));
                points.Add(new Point(1500, 0));
                shape.Content = new Polygon()
                {
                    Fill = new SolidColorBrush(Colors.Transparent),
                    Points = points,
                    Stretch = Stretch.Fill
                };
                shape.Type = PaintShapesType.Star;
            }
            else return;

            canvas.Items.Add(shape);
            shape.IsSelected = true;

            canvas.DrawingMode = DrawingModes.Shape;
        }

        private void LineRibbonDropDownItem_Selected(object sender, RoutedEventArgs e)
        {
            RibbonDropDownItem rddi = sender as RibbonDropDownItem;
            canvas.StrokeThickness = int.Parse(rddi.Tag.ToString());
        }


        void StrokeColorChanged(object sender, RoutedEventArgs e)
        {
            if (sender is RibbonDropDownItem)
            {
                RibbonDropDownItem rddi = sender as RibbonDropDownItem;
                canvas.Stroke = new SolidColorBrush((Color)rddi.Tag);
            }
            else if (sender is RibbonButton)
            {
                canvas.Stroke = new SolidColorBrush(Colors.Transparent);
            }
        }

        void FillColorChanged(object sender, RoutedEventArgs e)
        {
            if (sender is RibbonDropDownItem)
            {
                RibbonDropDownItem rddi = sender as RibbonDropDownItem;
                canvas.Fill = new SolidColorBrush((Color)rddi.Tag);
            }
            else if (sender is RibbonButton)
            {
                canvas.Fill = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void FonttSizeRibbonDropDownItem_Selected(object sender, RoutedEventArgs e)
        {
            RibbonDropDownItem rddi = sender as RibbonDropDownItem;
            canvas.FontSize = int.Parse(rddi.Label);
        }

        private void FontFamilyRibbonDropDownItem_Selected(object sender, RoutedEventArgs e)
        {
            RibbonDropDownItem rddi = sender as RibbonDropDownItem;
            canvas.FontFamily = new System.Windows.Media.FontFamily(rddi.Label);
        }

        private void BoldRibbonToggleButton_Click(object sender, RoutedEventArgs e)
        {
            RibbonToggleButton rtb = sender as RibbonToggleButton;
            canvas.FontWeight =  (rtb.IsChecked ? FontWeights.Bold : FontWeights.Normal);
        }

        private void ItalicRibbonToggleButton_Click(object sender, RoutedEventArgs e)
        {
            RibbonToggleButton rtb = sender as RibbonToggleButton;
            canvas.FontStyle = (rtb.IsChecked ? FontStyles.Italic : FontStyles.Normal);
        }

        private void UnderlineRibbonToggleButton_Click(object sender, RoutedEventArgs e)
        {
            RibbonToggleButton rtb = sender as RibbonToggleButton;
            canvas.TextDecorations = (rtb.IsChecked ? TextDecorations.Underline : null);
        }

        void TextColorChanged(object sender, RoutedEventArgs e)
        {
            RibbonDropDownItem rddi = sender as RibbonDropDownItem;
            canvas.TextColor = new SolidColorBrush((Color)rddi.Tag); 
        }

        void TextBackgroundChanged(object sender, RoutedEventArgs e)
        {
            if (sender is RibbonDropDownItem)
            {
                RibbonDropDownItem rddi = sender as RibbonDropDownItem;
                canvas.TextBackground = new SolidColorBrush((Color)rddi.Tag);
            }
            else if (sender is RibbonButton)
            {
                canvas.TextBackground = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void ToolButtonsCheckedChange(object sender, RoutedEventArgs e)
        {
            RibbonToggleButton rtb = sender as RibbonToggleButton;

            canvas.DrawingMode = DrawingModes.None;
            if (rtb.IsChecked)
            {
                if (rtb.Tag.ToString() == "Pen")
                {
                    canvas.DrawingMode = DrawingModes.Ink;
                }
                else if (rtb.Tag.ToString() == "Eraser")
                {
                    canvas.DrawingMode = DrawingModes.Eraser;
                }
            }
        }

        private void PasteFromRibbonButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Изображения (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() != true) return;

            System.IO.Stream fileStream = ofd.File.OpenRead();
            BitmapImage bi  = new BitmapImage();
            bi.SetSource(fileStream);
            fileStream.Close();

            Image image = new Image();
            image.Stretch = Stretch.Uniform;
            image.Source = bi;

            PaintShape shape = new PaintShape();
            shape.Content = image;
            shape.Width = bi.PixelWidth;
            shape.Height = bi.PixelHeight;
            shape.Type = PaintShapesType.Image;
            shape.IsSelected = true;
            canvas.Items.Add(shape);

            canvas.DrawingMode = DrawingModes.Shape;
        }

        private void canvas_ShapeSelected(object sender, ShapeSelectEventArgs e)
        {
            if (e.Shape == null)
            {
                //TextTab.IsShow = false;
                ribbon.HideTab(TextTab);
                return;
            }
            
            if (e.Shape.Type == PaintShapesType.Text)
            {
                //TextTab.IsShow = true;
                ribbon.ShowTab(TextTab);
                //TextTab.IsSelected = true;
            }
            else
            {
                //TextTab.IsShow = false;
                ribbon.HideTab(TextTab);
            }
        }

        private void TextEditRibbonButton_Click(object sender, RoutedEventArgs e)
        {
            if (canvas.SelectedItem != null && canvas.SelectedItem.Content is TextBlock)
            {
                TextEditWindow tew = new TextEditWindow();
                tew.Closed += new EventHandler(TextEditWindow_Closed);
                tew.EditText = (canvas.SelectedItem.Content as TextBlock).Text;
                tew.Show();
            }
        }

        void TextEditWindow_Closed(object sender, EventArgs e)
        {
            TextEditWindow tew = sender as TextEditWindow;
            if (tew.DialogResult != true) return;

            (canvas.SelectedItem.Content as TextBlock).Text = tew.EditText;
        }

        private void RibbonOfficeMenuTab_Loaded(object sender, RoutedEventArgs e)
        {
            canvas.HideSelection();
        }
    }
}
