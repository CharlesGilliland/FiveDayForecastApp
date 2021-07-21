using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FiveDayForecastApp.ViewModel.Commands
{
    public class NewSearchCommand : ICommand
    {
        public WeatherViewModel viewModel;
        public NewSearchCommand(WeatherViewModel vm)
        {
            viewModel = vm;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.NewSearch();
        }
    }
}
