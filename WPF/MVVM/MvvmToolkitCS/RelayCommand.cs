using System;
using System.Windows.Input;
using System.Diagnostics;

namespace MvvmToolkit
{
    /// <summary>
    /// An utility class used in ViewModels to implement ICommands
    /// where the CanExecute and Execute functionality is provided
    /// via delegates to methods which exist in the ViewModel.
    /// </summary>
    public sealed class RelayCommand : ICommand, IDisposable
    {
        #region Member variables

        private Action<object> mExecute;
        private Predicate<object> mCanExecute;

        #endregion

        #region Constructors

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod)
        {
            if (executeMethod != null)
            {
                mExecute = executeMethod;
                mCanExecute = canExecuteMethod;
            }
            else
                throw new ArgumentNullException("execute");
        }

        #endregion

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (mCanExecute!=null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (mCanExecute!=null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return mCanExecute == null ? true : mCanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            mExecute(parameter);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            mExecute = null;
            mCanExecute = null;
        }

        #endregion
    }

    public sealed class RelayCommand<T> : ICommand, IDisposable
    {
        #region Member variables

        private Predicate<T> mCanExecute = null;
        private Action<T> mExecute = null;

        #endregion

        #region Constructors

        public RelayCommand(Action<T> executeMethod)
            : this(executeMethod, null)
        {
        }

        public RelayCommand(Action<T> executeMethod, Predicate<T> canExecuteMethod)
        {
            if (executeMethod != null)
            {
                mExecute = executeMethod;
                mCanExecute = canExecuteMethod;
            }
            else
                throw new ArgumentNullException("executeMethod", "Delegate comamnds can not be null");
        }

        #endregion

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (mCanExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (mCanExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }
        public bool CanExecute(object parameter)
        {
            return mCanExecute == null ? true : mCanExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            mExecute((T)parameter);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            mCanExecute = null;
            mExecute = null;
        }

        #endregion
    }

}
