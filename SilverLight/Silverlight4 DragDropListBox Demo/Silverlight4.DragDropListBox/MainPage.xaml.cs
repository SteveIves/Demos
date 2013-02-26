
using System.Windows.Controls;

namespace Silverlight4.DragDropListBox
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            customerListBoxMain.ItemsSource = PersonDataProvider.GetData();
        }
    }
}
