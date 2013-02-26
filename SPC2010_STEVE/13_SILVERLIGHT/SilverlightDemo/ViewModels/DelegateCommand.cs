using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightDemo.ViewModels
{
    //Public Class DelegateCommand Implements ICommand 
    public class DelegateCommand : ICommand
    {
 
        //Dim _executeAction As Action(Of Object) 
        //Dim _canExecuteCache As Boolean 
        //Dim _canExecute As Func(Of Object, Boolean) 
        Action<object> _executeAction;
        bool _canExecuteCache;
        Func<object,bool> _canExecute;

        ///<summary> 
        ///Initializes a new instance of the <see cref="DelegateCommand"/> class. 
        ///</summary> 
        ///<param name="executeAction">The execute action.</param> 
        ///<param name="canExecute">Whether it can execute.</param>
        //Public Sub New(ByVal executeAction As Action(Of Object), ByVal canExecute As Func(Of Object, Boolean)) 
        //    executeAction = executeAction 
        //    _canExecute = canExecute 
        //End Sub 
        public DelegateCommand(Action<object> executeAction, Func<object,bool> canExecute) 
        {
            _executeAction = executeAction;
            _canExecute = canExecute;
        }
 
        ///<summary> 
        ///Determines whether the command can execute in its current state. 
        ///</summary> 
        ///<param name="parameter">Data used by the command.</param> 
        ///<returns>True if the command can be executed.</returns> 
        //Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute 
        //
        //    Dim temp = _canExecute(parameter) 
        //    If _canExecuteCache <> temp Then 
        //        _canExecuteCache = temp 
        //        RaiseEvent CanExecuteChanged(Me, New EventArgs) 
        //    End If 
        //    Return _canExecuteCache 
        //End Function 
        public bool CanExecute(object parameter)
        { 
            var temp = _canExecute(parameter);
            if (_canExecuteCache != temp)
            {
                _canExecuteCache = temp;

                if (CanExecuteChanged!=null)
                    CanExecuteChanged(this, new EventArgs());
            } 
            return _canExecuteCache;
        }
 
        ///<summary> 
        ///Occurs when changes happen that affects whether the command should execute. 
        ///</summary> 
        //Public Event CanExecuteChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ICommand.CanExecuteChanged 
        public event EventHandler CanExecuteChanged;

            ///<summary> 
        ///Defines method to call when the command is invoked. 
        ///</summary> 
        ///<param name="parameter">Data used by the command.</param>
        //Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute  
        //    _executeAction(parameter) 
        //End Sub
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
