using FiveDayForecastApp.Model;
using FiveDayForecastApp.ViewModel.Commands;
using FiveDayForecastApp.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace FiveDayForecastApp.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private string citySearch;
        public string CitySearch
        {
            get { return citySearch; }
            set 
            { 
                citySearch = value;
                OnPropertyChanged("CitySearch");
            }
        }

        private ObservableCollection<City> cities;
        public ObservableCollection<City> Cities
        {
            get { return cities; }
            set 
            { 
                cities = value;
                OnPropertyChanged("Cities");
            }
        }

        private City selectedCity;
        public City SelectedCity
        {
            get { return selectedCity; }
            set 
            { 
                selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }

        private FiveDayForecast fiveDayForecast;
        public FiveDayForecast FiveDayForecast
        {
            get { return fiveDayForecast; }
            set
            {
                fiveDayForecast = value;
                OnPropertyChanged("FiveDayForecast");
                PopulateDailyForecasts();
            }
        }
        private ObservableCollection<DailyForecast> dailyForecasts;
        public ObservableCollection<DailyForecast> DailyForecasts
        {
            get { return dailyForecasts; }
            set
            {
                dailyForecasts = value;
                OnPropertyChanged("DailyForecasts");
            }
        }
        private DailyForecast selectedDay;
        public DailyForecast SelectedDay
        {
            get { return selectedDay; }
            set
            {
                selectedDay = value;
                OnPropertyChanged("SelectedDay");
            }
        }
        public List<int> TesterList = new List<int>() { 1, 2, 3, 4, 5 };
        

        private Visibility citiesVis;
        public Visibility CitiesVis
        {
            get { return citiesVis; }
            set 
            { 
                citiesVis = value;
                OnPropertyChanged("CitiesVis");
            }
        }

        private Visibility searchVis;
        public Visibility SearchVis
        {
            get { return searchVis; }
            set
            {
                searchVis = value;
                OnPropertyChanged("SearchVis");
            }
        }

        private Visibility fiveDayVis;
        public Visibility FiveDayVis
        {
            get { return fiveDayVis; }
            set
            {
                fiveDayVis = value;
                OnPropertyChanged("FiveDayVis");
            }
        }

        public SearchCommand SearchCommand { get; set; }
        public GetForecastCommand GetForecastCommand { get; set; }
        public NewSearchCommand NewSearchCommand { get; set; }

        public WeatherViewModel()
        {
            Cities = new ObservableCollection<City>();
            DailyForecasts = new ObservableCollection<DailyForecast>();

            SearchCommand = new SearchCommand(this);
            GetForecastCommand = new GetForecastCommand(this);
            NewSearchCommand = new NewSearchCommand(this);

            CitiesVis = Visibility.Collapsed;
            SearchVis = Visibility.Visible;
            FiveDayVis = Visibility.Collapsed;
        }

        public async void GetCitiesQuery()
        {
            List<City> cities;
            try
            {
                cities = await AccuWeatherHelper.GetCities(CitySearch);
            } 
            catch(Exception)
            {
                MessageBox.Show("Please check your connection and try again");
                return;
            }
            

            Cities.Clear();
            foreach(City city in cities)
            {
                Cities.Add(city);
            }
            CitiesVis = Visibility.Visible;
        }

        public async void GetFiveDayForecast()
        {
            var forecast = await AccuWeatherHelper.GetForecast(SelectedCity.Key);
            FiveDayForecast = forecast;

            SearchVis = Visibility.Collapsed;
            FiveDayVis = Visibility.Visible;
        }

        public void PopulateDailyForecasts()
        {
            DailyForecasts.Clear();
            foreach(DailyForecast dailyforecast in FiveDayForecast.DailyForecasts)
            {
                DailyForecasts.Add(dailyforecast);
            }
            SelectedDay = DailyForecasts[0];
        }

        public void NewSearch()
        {
            SearchVis = Visibility.Visible;
            FiveDayVis = Visibility.Collapsed;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
