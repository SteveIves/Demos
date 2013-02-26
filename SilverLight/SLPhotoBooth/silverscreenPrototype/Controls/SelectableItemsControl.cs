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

namespace silverscreenPrototype
{
    public class SelectableItemsControl : ItemsControl
    {
        private MouseButtonEventHandler m_SelectedHandler;
        public SelectableItemsControl()
        {
            m_SelectedHandler = new MouseButtonEventHandler(OnItemSelected);
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            (element as ContentPresenter).MouseLeftButtonDown += m_SelectedHandler;
            base.PrepareContainerForItemOverride(element, item);
        }

        void OnItemSelected(object sender, MouseButtonEventArgs e)
        {
            SelectedItem = (sender as ContentPresenter).DataContext;
        }

        protected override void ClearContainerForItemOverride(DependencyObject element, object item)
        {
            (element as ContentPresenter).MouseLeftButtonDown -= m_SelectedHandler;
            base.ClearContainerForItemOverride(element, item);
        }



        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(SelectableItemsControl), new PropertyMetadata(null));

        
    }
}
