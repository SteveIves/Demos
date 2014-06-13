
using Cirrious.MvvmCross.Wpf.Views;
using TipCalc.Core.ViewModels;

namespace TipCalc.UI.Wpf.Views
{
    /// <summary>
    /// Interaction logic for TipView.xaml
    /// </summary>
    public partial class TipView : MvxWpfView
    {
        public TipView()
        {
            InitializeComponent();
        }

        public new TipViewModel ViewModel
        {
            get { return (TipViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
