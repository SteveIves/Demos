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
using System.Windows.Media.Imaging;
using System.Windows.Printing;

namespace Paint
{
    public partial class PrintPreview : UserControl
    {
        #region public UIElement Target

        public UIElement Target
        {
            get { return (UIElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        public static readonly DependencyProperty TargetProperty =
                DependencyProperty.Register(
                        "Target",
                        typeof(UIElement),
                        typeof(PrintPreview),
                        new PropertyMetadata(null, OnTargetPropertyChanged));

        private static void OnTargetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PrintPreview pp = (PrintPreview)d;

            if (e.NewValue != null)
            {
                WriteableBitmap image = new WriteableBitmap((UIElement)e.NewValue, null);
                pp.PreviewImage.Source = image;
            }
        }

        #endregion public string Label
        
        public PrintPreview()
        {
            InitializeComponent();

            Loaded += PrintPreview_Loaded;
        }

        void PrintPreview_Loaded(object sender, RoutedEventArgs e)
        {
            if (Target != null)
            {
                WriteableBitmap image = new WriteableBitmap(Target, null);
                PreviewImage.Source = image;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument theDoc = new PrintDocument();
            theDoc.PrintPage += (s, args) =>
            {
                args.PageVisual = Target;
                args.HasMorePages = false;
            };

            theDoc.EndPrint += (s, args) =>
            {
                MessageBox.Show("The document printed successfully", "Word", MessageBoxButton.OK);
            };

            theDoc.Print("Doc");
        }
    }
}
