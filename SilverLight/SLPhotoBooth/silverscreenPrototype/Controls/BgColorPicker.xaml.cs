using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Collections;

namespace silverscreenPrototype
{
	public partial class BgColorPicker : UserControl
	{
		public BgColorPicker()
		{
			// Required to initialize variables
			InitializeComponent();

            Binding binding = new Binding("ItemsSource");
            binding.Source = this;
            ItemsList.SetBinding(ItemsControl.ItemsSourceProperty, binding);

            binding = new Binding("SelectedItem");
            binding.Source = ItemsList;
            SetBinding(BgColorPicker.SelectedItemProperty, binding);
		}

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(BgColorPicker), new PropertyMetadata(null));

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(BgColorPicker), new PropertyMetadata(null));
	}
}