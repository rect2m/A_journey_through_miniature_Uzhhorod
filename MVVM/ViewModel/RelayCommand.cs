using System.Windows.Input;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool>? canExecute;

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Func<object, bool>? canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
