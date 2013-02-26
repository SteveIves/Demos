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
using Controls.Menus.Ribbon;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.IO;

namespace Test
{
    public partial class MainPage : UserControl
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void ColorsRibbonGallery_ItemsLoading(object sender, RoutedEventArgs e)
        {
            RibbonItemsGallery rig = (sender as RibbonItemsGallery);
            rig.Items.Clear();

            for (int i = 0; i < 10; i++)
            {
                BitmapImage bi = new BitmapImage(new Uri(string.Format("/Test;component/Images/Colors/Color{0}.png", i), UriKind.Relative));
                rig.Items.Add(new RibbonDropDownItem() { Image = bi });
            }
        }

        private void AlignToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            foreach (RibbonToggleButton rtb in ((sender as RibbonToggleButton).Parent as RibbonBox).Children)
            {
                if (rtb != (sender as RibbonToggleButton)) rtb.IsChecked = false;
            }
        }

        private void RibbonDropDownItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RibbonToggleButton_Click(object sender, RoutedEventArgs e)
        {
            RibbonToggleButton rtb = sender as RibbonToggleButton;

            PasteTab.Visibility =  System.Windows.Visibility.Collapsed;
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            PasteTab.Visibility = System.Windows.Visibility.Collapsed;
        }

    }
}
