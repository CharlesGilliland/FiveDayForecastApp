using FiveDayForecastApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FiveDayForecastApp.ViewModel.Helper
{
    public class AccuWeatherHelper
    {
        public const string API_KEY = "u3piUB4U8kUch1YA9tbaDQ2fVAaDWdSK";

        public const string ENDPOINT_BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string FIVE_DAY_FORECAST_ENDPOINT = "forecasts/v1/daily/5day/{0}?apikey={1}&metric=true";

        public static async Task<List<City>> GetCities(string city)
        {
            List<City> cities = new List<City>();

            string url = ENDPOINT_BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, city);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<FiveDayForecast> GetForecast(string cityKey)
        {
            FiveDayForecast forecast;

            string url = ENDPOINT_BASE_URL + string.Format(FIVE_DAY_FORECAST_ENDPOINT, cityKey, API_KEY);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                forecast = JsonConvert.DeserializeObject<FiveDayForecast>(json);
            }

            return forecast;
        }

    }
}
