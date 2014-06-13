using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculationService _calculation;

        public TipViewModel(ICalculationService calculation)
        {
            _calculation = calculation;
        }

        public override void Start()
        {
            _subTotal = 100;
            _generosity = 18;
            Recalculate();
            base.Start();
        }

        private double _subTotal;

        public double SubTotal
        {
            get
            {
                return _subTotal;
            }
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);
                Recalculate();
            }
        }

        private int _generosity;

        public int Generosity
        {
            get
            {
                return _generosity;
            }
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);
                Recalculate();
            }
        }

        private double _tip;

        public double Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        private double _Total;

        public double Total
        {
            get
            {
                return _Total;
            }
            set
            {
                _Total = value;
                RaisePropertyChanged(() => Total);
            }
        }

        private void Recalculate()
        {
            Tip = _calculation.TipAmount(SubTotal, Generosity);
            Total = _subTotal + _tip;
        }

        private MvxCommand _AboutCommand;

        public ICommand AboutCommand
        {
            get
            {
                if (_AboutCommand == null)
                    _AboutCommand = new MvxCommand(doAboutCommand);
                return _AboutCommand;
            }
        }

        private void doAboutCommand()
        {
            //Navigate to AboutViewModel
            base.ShowViewModel<AboutViewModel>();
        }

    }
}
