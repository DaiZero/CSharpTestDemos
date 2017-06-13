using System;
using System.Windows.Input;

namespace WpfApp_TestDemo.Command
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (CanExecutrFunc==null)
            {
                return true;
            }
           return CanExecutrFunc(parameter);
        }

        public void Execute(object parameter)
        {
            if (ExecuteAction==null)
            {
                return;
            }
            ExecuteAction(parameter);
        }
        public Action<object> ExecuteAction { get; set; }
        public Func<object,bool> CanExecutrFunc { get; set; }
    }
}
