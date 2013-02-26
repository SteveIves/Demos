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
    public partial class TextEditWindow : ChildWindow
    {
        public string EditText { get; set; }
        
        public TextEditWindow()
        {
            InitializeComponent();

            EditText = "";

            Loaded += new RoutedEventHandler(TextEditWindow_Loaded);
        }

        void TextEditWindow_Loaded(object sender, RoutedEventArgs e)
        {
            editTextBox.Text = EditText;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            EditText = editTextBox.Text;
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

