using System;
using System.ComponentModel;
using System.Diagnostics;

namespace MvvmToolkit
{
    /// <summary>
    /// An abstract ase class for used when implementing ViewModel classes.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        #region DisplayName

        /// <summary>
        /// Returns the user-friendly name of this object.
        /// Child classes can set this property to a new value,
        /// or override it to determine the value on-demand.
        /// </summary>
        public virtual string DisplayName { get; protected set; }

        #endregion // DisplayName

        #region INotifyPropertyChanged

		/// <summary>
		/// Raised when a property on this object has a new value.
		/// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raises this object's PropertyChanged event.
		/// </summary>
		/// <param name="propertyName">The property that has a new value.</param>
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            //Raising propertychanged on a null property name will
            //raise the event for all properties. This is useful when
            //a VM exposes individual properties from a single object
            //or struct backing field, becaus if the backing field changes
            //then potentially all of the exposed properties change also.

            if (propertyName != null)
                this.VerifyPropertyName(propertyName);

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(null));
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            this.OnDispose();
        }

        /// <summary>
        /// Child classes can override this method to perform 
        /// clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void OnDispose()
        {
        }

#if DEBUG
        /// <summary>
        /// Useful for ensuring that ViewModel objects are properly garbage collected.
        /// </summary>
        ~ViewModelBase()
        {
            string msg = string.Format("{0} ({1}) ({2}) Finalized", this.GetType().Name, this.DisplayName, this.GetHashCode());
            System.Diagnostics.Debug.WriteLine(msg);
        }
#endif

        #endregion // IDisposable Members

        #region Debugging Aides

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real public instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = String.Format("Invalid property name: {0}",propertyName);
                if (ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }

        ///<summary>
        ///Returns whether an exception is thrown, or if a Debug.Fail() is used
        ///when an invalid property name is passed to the VerifyPropertyName method.
        ///The default value is false, but subclasses used by unit tests might 
        ///override this property's getter to return true.
        ///</summary>
        protected bool ThrowOnInvalidPropertyName { get; set; }

        #endregion

    }
}
