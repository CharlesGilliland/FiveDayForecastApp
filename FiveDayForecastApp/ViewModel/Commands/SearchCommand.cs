using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FiveDayForecastApp.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherViewModel viewModel;
        public SearchCommand(WeatherViewModel vm)
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
            if (string.IsNullOrWhiteSpace(parameter as string))
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            
            viewModel.GetCitiesQuery();
        }
    }
}
