using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BitEd.Core
{
    class ActionCommand : ICommand
    {
        private Func<bool> condition;
        private Action executable;

        public ActionCommand(Action commandDelegate, Func<bool> conditionDelegate)
        {
            if (commandDelegate == null)
                throw new ArgumentNullException("Command Delegate argument cannot be null");
            executable = commandDelegate;
            condition = conditionDelegate;
        }

        public bool CanExecute(object parameter)
        {
            if (condition == null)
            {
                return true;
            }
            else
            {
                return condition();
            }
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            executable();
        }
    }
}
