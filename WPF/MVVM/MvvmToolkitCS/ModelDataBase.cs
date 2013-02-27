using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MvvmToolkit
{
    /// <summary>
    /// An abstract base class used when implementing model data classes.
    /// </summary>
    [DataContract]
    public abstract class ModelDataBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        #endregion

        //#region IActiveRecord

        //public abstract bool Create();

        //public abstract bool Update();

        //public abstract bool Delete();

        //#endregion

    }
}
