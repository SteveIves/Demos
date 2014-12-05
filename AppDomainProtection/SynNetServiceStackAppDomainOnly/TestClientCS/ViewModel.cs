
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;

using ServiceStack;
using Services;
using BusinessLogic;

namespace TestClientCS
{
    public class ViewModel : INotifyPropertyChanged
    {

        public ViewModel()
        {
            getSuppliers();
        }

        private ObservableCollection<Supplier> mSuppliers;
        private Supplier mSelectedSupplier;
        private ObservableCollection<Part> mParts;
        private Part mSelectedPart;

        public ObservableCollection<Supplier> Suppliers
        {
            get { return mSuppliers; }
            set
            {
                mSuppliers = value;
                NotifyPropertyChanged("Suppliers");
            }
        }

        public Supplier SelectedSupplier
        {
            get { return mSelectedSupplier; }
            set { 
            mSelectedSupplier = value;
            NotifyPropertyChanged("SelectedSupplier");
            getSupplierParts();
        }
        }

        public ObservableCollection<Part> Parts
        {
            get { return mParts; }
            set
            {
                mParts = value;
                NotifyPropertyChanged("Parts");
            }
        }

        public Part SelectedPart
        {
            get { return mSelectedPart; }
            set
            {
                mSelectedPart = value;
                NotifyPropertyChanged("SelectedPart");
            }
        }

        private void getSuppliers()
        {
            ErrorMessage = "";
            using (var client = new JsonServiceClient("http://localhost:8088"))
            {
                try
                {
                    SupplierReadAllResponse response = client.Get(new SupplierReadAll());
                    Suppliers = new ObservableCollection<Supplier>(response.Suppliers);
                    if (Suppliers.Count > 0)
                        SelectedSupplier = Suppliers[0];
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
        }

        private void getSupplierParts()
        {
            ErrorMessage = "";
            using (var client = new JsonServiceClient("http://localhost:8088"))
            {
                try
                {
                    PartReadSupplierPartsResponse response = client.Get(new PartReadSupplierParts() { SupplierId = SelectedSupplier.SupplierId });
                    Parts = new ObservableCollection<Part>(response.Parts);
                    if (Parts.Count > 0)
                        SelectedPart = Parts[0];
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
        }

        private string mErrorMessage;

        public string ErrorMessage
        {
            get { return mErrorMessage; }
            set
            {
                mErrorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}

