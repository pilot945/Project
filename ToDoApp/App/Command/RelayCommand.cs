using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App.Command
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        public Func<object, bool> canExecute;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? paramater)
        {
           return execute != null && canExecute(paramater);
        }

        public void Execute(object? paramater)
        {
            execute(paramater);
        }
    }
}
