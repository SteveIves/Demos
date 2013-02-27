using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MvvmToolkit
{
    /// <summary>
    /// An abstract base class used when implementing model logic.
    /// </summary>
    public abstract class ModelBase : INotifyPropertyChanged
    {
        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}
