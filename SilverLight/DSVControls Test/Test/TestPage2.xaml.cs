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
using DSV.Controls.Menu;
using DSV.Controls.Menu.Ribbon;
using System.Windows.Media.Imaging;
using DSV.Controls.Windows;

namespace Test
{
    public partial class TestPage2 : UserControl
    {
        public TestPage2()
        {
            InitializeComponent();

            Loaded += new RoutedEventHandler(TestPage2_Loaded);

            
        }

        void TestPage2_Loaded(object sender, RoutedEventArgs e)
        {
            DSV.Controls.Windows.Icon paint = new  DSV.Controls.Windows.Icon(
                new BitmapImage(new Uri("Icons/Paint16.png", UriKind.RelativeOrAbsolute)),
                new BitmapImage(new Uri("Icons/Paint32.png", UriKind.RelativeOrAbsolute)),
                null);
            DSV.Controls.Windows.Icon word = new  DSV.Controls.Windows.Icon(
                new BitmapImage(new Uri("Icons/Word16.png", UriKind.RelativeOrAbsolute)),
                new BitmapImage(new Uri("Icons/Word32.png", UriKind.RelativeOrAbsolute)),
                null);

            Core.CreateShortcut("Word",word, "Word.xap");
            Core.CreateShortcut("Paint",paint, "Paint.xap");

            string strBaseWebAddress = App.Current.Host.Source.AbsoluteUri;
        }

    }
}
