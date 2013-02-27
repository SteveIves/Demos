using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CommandActionDemo
{
    public sealed class RelayCommand : ICommand, IDisposable
    {
        #region Member variables

        private Predicate<object> _oCanExecuteMethod = null;
        private Action<object> _oExecuteMethod = null;

        #endregion

        #region Constructors

        public RelayCommand(Action<object> oExecuteMethod)
            : this(oExecuteMethod, null)
        {
        }
        public RelayCommand(Action<object> oExecuteMethod, Predicate<object> oCanExecuteMethod)
        {
            if (oExecuteMethod != null)
            {
                _oExecuteMethod = oExecuteMethod;
                _oCanExecuteMethod = oCanExecuteMethod;
            }
            else
            {
                throw new ArgumentNullException("oExecuteMethod", "Delegate comamnds can not be null");
            }
        }

        #endregion

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_oCanExecuteMethod != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_oCanExecuteMethod != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }
        public bool CanExecute(object parameter)
        {
            return _oCanExecuteMethod == null ? true : _oCanExecuteMethod(parameter);
        }
        public void Execute(object parameter)
        {
            _oExecuteMethod(parameter);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _oCanExecuteMethod = null;
            _oExecuteMethod = null;
        }

        #endregion
    }

    public sealed class RelayCommand<T> : ICommand, IDisposable
    {
        #region Member variables

        private Predicate<T> _oCanExecuteMethod = null;
        private Action<T> _oExecuteMethod = null;

        #endregion

        #region Constructors

        public RelayCommand(Action<T> oExecuteMethod)
            : this(oExecuteMethod, null)
        {
        }
        public RelayCommand(Action<T> oExecuteMethod, Predicate<T> oCanExecuteMethod)
        {
            if (oExecuteMethod != null)
            {
                _oExecuteMethod = oExecuteMethod;
                _oCanExecuteMethod = oCanExecuteMethod;
            }
            else
            {
                throw new ArgumentNullException("oExecuteMethod", "Delegate comamnds can not be null");
            }
        }

        #endregion

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_oCanExecuteMethod != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_oCanExecuteMethod != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }
        public bool CanExecute(object parameter)
        {
            return _oCanExecuteMethod == null ? true : _oCanExecuteMethod((T)parameter);
        }
        public void Execute(object parameter)
        {
            _oExecuteMethod((T)parameter);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _oCanExecuteMethod = null;
            _oExecuteMethod = null;
        }

        #endregion
    }
}
