using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightDemo.SPC2010Server;
//using SilverlightDemo.SPC2010WcfService;

namespace SilverlightDemo.ViewModels
{
    public class CustomersViewModel : INotifyPropertyChanged
    {
        #region Private data

        private static ObservableCollection<Customer> customers;
        private bool isLoadingCustomers;
        private Customer selectedCustomer;
        private static ObservableCollection<Contact> contacts;
        private bool isLoadingContacts;
        private Contact selectedContact;
        private bool canEditContact;
        private bool isEditingContact;

        #endregion

        #region Initialization

        //Constructor.
        public CustomersViewModel()
        {
            SelectedCustomerChanged = new DelegateCommand(OnSelectedCustomerChanged, CanSelectedCustomerChange);
            SelectedContactChanged = new DelegateCommand(OnSelectedContactChanged, CanSelectedContactChange);
            EditContact = new DelegateCommand(OnEditContact, CanEditContact);
            SaveContact = new DelegateCommand(OnSaveContact, CanSaveOrCancelContact);
            CancelEditingContact = new DelegateCommand(OnCancelEditingContact, CanSaveOrCancelContact);
        }

        //Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if ((PropertyChanged != null))
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Customers collection

        public ObservableCollection<Customer> Customers
        {
            get
            {
                if (customers == null)
                {
                    SPC2010WcfServiceClient client = Util.GetClient();
                    customers = new ObservableCollection<Customer>();
                    client.GetCustomersCompleted += new EventHandler<GetCustomersCompletedEventArgs>(client_GetCustomersCompleted);
                    this.IsLoadingCustomers = true;
                    client.GetCustomersAsync();
                }
                return customers;
            }
            private set
            {
                customers = value;
                NotifyPropertyChanged("Customers");
            }
        }

        private void client_GetCustomersCompleted(object sender, GetCustomersCompletedEventArgs e)
        {
            IsLoadingCustomers = false;

            switch (e.Result)
            {
                case MethodStatus.Success:
                    Customers = e.customers;
                    break;
                case MethodStatus.InfoError:
                    //TODO: Cause view to display an information message
                    break;
                case MethodStatus.FatalError:
                    //TODO: Cause view to display an error message and terminate
                    break;
            }
        }

        public bool IsLoadingCustomers
        {
            get
            {
                return this.isLoadingCustomers;
            }
            private set
            {
                if (!this.isLoadingCustomers.Equals(value))
                {
                    this.isLoadingCustomers = value;
                    NotifyPropertyChanged("IsLoadingCustomers");
                }
            }
        }

        #endregion

        #region Selected Customer

        public Customer SelectedCustomer
        {
            get
            {
                return this.selectedCustomer;
            }
            private set
            {
                if (!object.ReferenceEquals(this.selectedCustomer, value))
                {
                    this.selectedCustomer = value;
                    NotifyPropertyChanged("SelectedCustomer");
                }
            }
        }

        public DelegateCommand SelectedCustomerChanged { get; set; }

        private void OnSelectedCustomerChanged(object param)
        {
            this.SelectedCustomer = (Customer)param;
            getContacts(this.selectedCustomer.CustomerId);
        }

        public bool CanSelectedCustomerChange(object parameter)
        {
            return !isEditingContact;
        }

        #endregion

        #region Contacts collection

        public ObservableCollection<Contact> Contacts
        {
            get
            {
                if (contacts == null && selectedCustomer != null)
                {
                    getContacts(selectedCustomer.CustomerId);
                }
                return contacts;
            }
            private set
            {
                if (!object.ReferenceEquals(contacts, value))
                {
                    contacts = value;
                    NotifyPropertyChanged("Contacts");
                }
            }
        }

        private void getContacts(int customerId)
        {
            //SPC2010WebServiceSoapClient client = Util.GetClient();
            SPC2010WcfServiceClient client = Util.GetClient();
            contacts = new ObservableCollection<Contact>();
            client.GetCustomerContactsCompleted += new EventHandler<GetCustomerContactsCompletedEventArgs>(client_GetCustomerContactsCompleted);
            this.IsLoadingContacts = true;
            client.GetCustomerContactsAsync(selectedCustomer.CustomerId);
        }

        private void client_GetCustomerContactsCompleted(object sender, GetCustomerContactsCompletedEventArgs e)
        {
            this.IsLoadingContacts = false;
            this.Contacts = e.Result;
        }

        public bool IsLoadingContacts
        {
            get
            {
                return this.isLoadingContacts;
            }
            private set
            {
                if (!this.isLoadingContacts.Equals(value))
                {
                    this.isLoadingContacts = value;
                    NotifyPropertyChanged("IsLoadingContacts");
                }
            }
        }

        public DelegateCommand SelectedContactChanged { get; set; }
        private void OnSelectedContactChanged(object param)
        {
            this.SelectedContact = (Contact)param;
        }

        public bool CanSelectedContactChange(object parameter)
        {
            return !isEditingContact;
        }

        #endregion

        #region Selected contact

        public Contact SelectedContact
        {
            get
            {
                return this.selectedContact;
            }
            private set
            {
                if (!object.ReferenceEquals(this.selectedContact, value))
                {
                    this.selectedContact = value;
                    NotifyPropertyChanged("SelectedContact");
                    NotifyPropertyChanged("ContactIsLoaded");
                    this.canEditContact = (this.selectedContact != null);
                }
            }
        }

        public bool ContactIsLoaded
        {
            get
            {
                return (this.selectedContact != null);
            }
        }

        #endregion

        #region Contact editing

        public bool CanEditContact(object parameter)
        {
            return canEditContact;
        }

        public bool CanSaveOrCancelContact(object parameter)
        {
            return isEditingContact;
        }

        public DelegateCommand EditContact { get; set; }
        private void OnEditContact(object param)
        {

            /*
             * The UI is starting to edit a contact. Lets refresh the data for the currently selected
             * contact, and also get the GRFA of the record for use later.
             */






            isEditingContact = true;
            canEditContact = false;
        }

        public DelegateCommand SaveContact { get; set; }
        private void OnSaveContact(object param)
        {

            /*
             * The UI has finished editing a contact record, and requires that
             * the contact record be saved.
             */






            isEditingContact = false;
            canEditContact = (selectedContact != null);
        }

        public DelegateCommand CancelEditingContact { get; set; }
        private void OnCancelEditingContact(object param)
        {

            /*
             * The UI has finished editing a contact record, and does not require that
             * the contact record be saved.
             */






            isEditingContact = false;
            canEditContact = (selectedContact != null);
        }

        #endregion

    }

}
