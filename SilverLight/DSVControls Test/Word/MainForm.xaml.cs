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
using DSV.Controls.Menu.Ribbon;
using System.Windows.Media.Imaging;

namespace Word
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

        private void ColorsRibbonGallery_ItemsLoading(object sender, RoutedEventArgs e)
        {
            RibbonGallery rg = (sender as RibbonGallery);
            rg.Items.Clear();

            for (int i = 0; i < 10; i++)
            {
                BitmapImage bi = new BitmapImage(new Uri(string.Format("/Word;component/Images/Colors/Color{0}.png", i), UriKind.Relative));
                RibbonDropDownItem rddi = new RibbonDropDownItem()
                {
                    Image = bi,
                    Tag = ColorsTable[i]
                };
                if (rg.Tag.ToString() == "FontColor")
                {
                    rddi.Selected += FontColorChanged;
                }
                //else if (rg.Tag.ToString() == "FillColor")
                //{
                //    rddi.Selected += new RoutedEventHandler(FillColorChanged);
                //}
                //else if (rg.Tag.ToString() == "TextColor")
                //{
                //    rddi.Selected += new RoutedEventHandler(TextColorChanged);
                //}
                //else if (rg.Tag.ToString() == "TextBackground")
                //{
                //    rddi.Selected += new RoutedEventHandler(TextBackgroundChanged);
                //}
                rg.Items.Add(rddi);
            }
        }

        void FontColorChanged(object sender, RoutedEventArgs e)
        {
            RibbonDropDownItem rddi = sender as RibbonDropDownItem;

            if (rtb != null && rtb.Selection.Text.Length > 0)
            {
                if (sender is RibbonDropDownItem)
                {
                    rtb.Selection.ApplyPropertyValue(Run.ForegroundProperty, new SolidColorBrush((Color)rddi.Tag));
                }
                else if (sender is RibbonButton)
                {
                    rtb.Selection.ApplyPropertyValue(Run.ForegroundProperty, new SolidColorBrush(Colors.Black));
                }
            }
            ReturnFocus();
        }

        private void rcbFontStyle_TextChanged(object sender, TextChangedEventArgs e)
        {
            RibbonComboBox rcb = sender as RibbonComboBox;

            if (rtb != null && rtb.Selection.Text.Length > 0)
            {
                rtb.Selection.ApplyPropertyValue(Run.FontFamilyProperty, new FontFamily(rcb.Text));
            }
            ReturnFocus();
        }


        private void ReturnFocus()
        {
            if (rtb != null)
                rtb.Focus();
        }

        private void rcbFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            RibbonComboBox rcb = sender as RibbonComboBox;

            if (rtb != null && rtb.Selection.Text.Length > 0)
            {
                rtb.Selection.ApplyPropertyValue(Run.FontSizeProperty, double.Parse(rcb.Text));
            }
            ReturnFocus();
        }


        private void rtbTextStyle_Click(object sender, RoutedEventArgs e)
        {
            RibbonToggleButton rtbtn = sender as RibbonToggleButton;

            if (rtbtn.Tag.ToString() == "Bold")
            {
                rtb.Selection.ApplyPropertyValue(Run.FontWeightProperty, (rtbtn.IsChecked ? FontWeights.Bold : FontWeights.Normal));
            }
            else if (rtbtn.Tag.ToString() == "Italic")
            {
                rtb.Selection.ApplyPropertyValue(Run.FontStyleProperty, (rtbtn.IsChecked ? FontStyles.Italic : FontStyles.Normal));
            }
            else if (rtbtn.Tag.ToString() == "Underline")
            {
                rtb.Selection.ApplyPropertyValue(Run.TextDecorationsProperty, (rtbtn.IsChecked ? TextDecorations.Underline : null));
            }
        }

        private void rtbTextAlign_Click(object sender, RoutedEventArgs e)
        {
            RibbonToggleButton rtbtn = sender as RibbonToggleButton;

            TextAlignment ta = TextAlignment.Left;
            switch (rtbtn.Tag.ToString())
            {
                case "AlignLeft":
                    ta = TextAlignment.Left;
                    break;
                case "AlignCenter":
                    ta = TextAlignment.Center;
                    break;
                case "AlignRight":
                    ta = TextAlignment.Right;
                    break;
                case "AlignJustify":
                    ta = TextAlignment.Justify;
                    break;
            }

            if (rtb != null && rtb.Selection.Text.Length > 0)
            {
                rtb.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, ta);
            }
            ReturnFocus();
        }

        private void rbInsertImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Изображения (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() != true) return;

            System.IO.Stream fileStream = ofd.File.OpenRead();
            BitmapImage bi = new BitmapImage();
            bi.SetSource(fileStream);
            fileStream.Close();

            Image image = new Image();
            image.Stretch = Stretch.None;
            image.Source = bi;
            
            InlineUIContainer container = new InlineUIContainer();
            container.Child = image;

            rtb.Selection.Insert(container);
            ReturnFocus();
        }

        private void rsbClipboard_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;

            if (element.Tag.ToString() == "Paste")
            {
                rtb.Selection.Text = Clipboard.GetText();
            }
            else if (element.Tag.ToString() == "Cut")
            {
                Clipboard.SetText(rtb.Selection.Text);
                rtb.Selection.Text = "";
            }
            else if (element.Tag.ToString() == "Copy")
            {
                Clipboard.SetText(rtb.Selection.Text);
            }

            ReturnFocus();
        }
    }
}
