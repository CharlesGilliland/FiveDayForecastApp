using FiveDayForecastApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FiveDayForecastApp.ViewModel.Commands
{
    public class GetForecastCommand : ICommand
    {
        public WeatherViewModel viewModel;
        public GetForecastCommand(WeatherViewModel vm)
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
            City city = parameter as City;
            if (city == null)
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.GetFiveDayForecast();
        }
    }
}
