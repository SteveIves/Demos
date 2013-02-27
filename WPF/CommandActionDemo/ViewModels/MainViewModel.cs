using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CommandActionDemo
{
    public class MainViewModel
    {
        //Commands
        private ICommand _comHoverOnRecCommand;

        public MainViewModel()
        {

        }

        public ICommand HoverOnRecCommand
        {
            get
            {
                if (_comHoverOnRecCommand == null)
                {
                    _comHoverOnRecCommand = new RelayCommand<object>(HoverOverRec_Executed, HoverOverRec_CanExecute);
                }
                return _comHoverOnRecCommand;
            }
        }

        private bool HoverOverRec_CanExecute(object parameter)
        {
            return true;
        }
        private void HoverOverRec_Executed(object parameter)
        {
            MessageBox.Show("You hovered over the rectangle");
        }
    }
}
