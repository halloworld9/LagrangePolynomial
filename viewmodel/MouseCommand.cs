using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LagrangePolynomial.viewmodel
{
    internal class MouseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action<Point?> action;
        private Predicate<Point?>? canExecute;

        public MouseCommand(
            Action<Point?> action,
            Predicate<Point?>? canExecute = null
            )
        {
            this.action = action;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object? parameter)
        {
            if (parameter != null)
            {
                return canExecute?.Invoke((Point?)parameter) == true;
            }
            else return true;
        }

        public void Execute(object? parameter)
        {
            action.Invoke((Point?)parameter);
        }
    }
}
