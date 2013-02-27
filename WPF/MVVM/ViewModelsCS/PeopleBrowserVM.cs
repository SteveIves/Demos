using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using MvvmToolkit;
using Models;

namespace ViewModels
{
    public class PeopleBrowserVM : ViewModelBase
    {
        #region Private data

        //Models
        PeopleService model;

        //Backing fields for properties
        ObservableCollection<Person> mPeople;
        Person mSelectedPerson;

        //Backing storage for commands
        DeleteAllPeopleCommand mDeleteAllPeopleCommand;
        RelayCommand mDeletePersonCommand;
        RelayCommand mReloadPeopleCommand;
        ICommand mSetStatusBarTextCommand;
        RelayCommand mCloseApplicationCommand;

        #endregion

        #region Constructors

        public PeopleBrowserVM()
        {
            model = new PeopleService();
        }

        #endregion

        #region Public properties for data binding

        public ObservableCollection<Person> People
        {
            get
            {
                if (mPeople == null)
                    People = model.GetAllPeople();
                return mPeople;
            }
            private set
            {
                mPeople = value;
                NotifyPropertyChanged("People");
            }
        }

        public Person SelectedPerson
        {
            get
            {
                return mSelectedPerson;
            }
            set
            {
                if (value != mSelectedPerson)
                {
                    mSelectedPerson = value;
                    NotifyPropertyChanged("SelectedPerson");
                }
            }
        }

        #endregion

        #region DeletePerson command

        public ICommand DeletePerson
        {
            get
            {
                if (mDeletePersonCommand == null)
                    mDeletePersonCommand = new RelayCommand(doDeletePerson, canDeletePerson);
                return mDeletePersonCommand;
            }
        }

        void doDeletePerson(object param)
        {
            //Figure out the index of the next person to be selected
            int newSelectedIndex = mPeople.IndexOf(mSelectedPerson);
            if (newSelectedIndex == mPeople.Count - 1)
                newSelectedIndex--;

            model.DeletePerson(mSelectedPerson);

            //Focus the new person
            if (newSelectedIndex > -1)
                SelectedPerson = mPeople[newSelectedIndex];
        }

        bool canDeletePerson(object param)
        {
            return (mSelectedPerson != null);
        }

        #endregion

        #region DeleteAllPeople command

        public ICommand DeleteAllPeople
        {
            get
            {
                if (mDeleteAllPeopleCommand == null)
                    mDeleteAllPeopleCommand = new DeleteAllPeopleCommand(this,model);
                return mDeleteAllPeopleCommand;
            }
        }
        #endregion

        #region ReloadPeople command

        public ICommand ReloadPeople
        {
            get
            {
                if (mReloadPeopleCommand == null)
                    mReloadPeopleCommand = new RelayCommand(doReloadPeople);
                return mReloadPeopleCommand;
            }
        }

        void doReloadPeople(object param)
        {
            People = model.ReloadPeople();
        }

        #endregion


        public ICommand SetStatusBarTextCommand
        {
            get
            {
                if (mSetStatusBarTextCommand == null)
                    mSetStatusBarTextCommand = new RelayCommand<object>(SetStatusBarTextCommand_Execute);
                return mSetStatusBarTextCommand;
            }
        }

        private void SetStatusBarTextCommand_Execute(object parameter)
        {
            StatusBarText = (String)parameter;
        }

        private String mStatusBarText;

        public String StatusBarText
        {
            get { return mStatusBarText; }
            set
            {
                mStatusBarText = value;
                NotifyPropertyChanged("StatusBarText");
            }
        }
        


        #region CloseApplication command

        public ICommand CloseApplication
        {
            get
            {
                if (mCloseApplicationCommand == null)
                    mCloseApplicationCommand = new RelayCommand(doCloseApp);
                return mCloseApplicationCommand;
            }
        }

        void doCloseApp(object param)
        {
             System.Windows.Application.Current.Shutdown();
        }

        #endregion

    }
}

