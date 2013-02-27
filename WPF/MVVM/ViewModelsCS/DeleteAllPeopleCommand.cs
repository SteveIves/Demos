using System;
using System.Windows.Input;
using Models;

namespace ViewModels
{
    public class DeleteAllPeopleCommand : ICommand
    {
        PeopleBrowserVM vm;
        PeopleService model;

        public DeleteAllPeopleCommand(PeopleBrowserVM aVm, PeopleService aModel)
        {
            vm = aVm;
            model = aModel;
        }

        public bool CanExecute(object parameter)
        {
            return (vm.People.Count > 0);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            model.DeleteAllPeople();
        }
    }
}
