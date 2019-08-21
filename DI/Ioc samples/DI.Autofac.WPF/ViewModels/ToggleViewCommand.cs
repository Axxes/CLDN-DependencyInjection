using System;
using System.Windows.Input;

namespace DI.WPF.ViewModels
{
    public class ToggleViewCommand : ICommand
    {
        public ToggleViewCommand(MainWindowViewModel viewModel)
        {
            _ViewModel = viewModel;
        }

        private readonly MainWindowViewModel _ViewModel;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _ViewModel.OnToggleViewCommand();
        }
    }
}
