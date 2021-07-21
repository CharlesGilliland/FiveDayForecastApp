using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace FiveDayForecastApp.ViewModel.Helper
{
    public class IntToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case 1:
                case 30:
                    return "../../Images/Sun.png";
                case 2:
                case 3:
                case 4:
                case 5:
                    return "../../Images/DayPartlyCloudy.png";
                case 6:
                case 7:
                case 8:
                case 34:
                case 35:
                case 36:
                case 37:
                case 38:
                    return "../../Images/Cloudy.png";
                case 11:
                    return "../../Images/DayFog.png";
                case 12:
                case 18:
                case 19:
                case 39:
                case 40:
                case 41:
                case 42:
                    return "../../Images/Rain.png";
                case 13:
                case 14:
                case 20:
                case 21:
                    return "../../Images/DayPartlyCloudyRain.png";
                case 15:
                    return "../../Images/Thunderstorm.png";
                case 16:
                case 17:
                    return "../../Images/SunStorm.png";
                case 22:
                case 23:
                case 43:
                case 44:
                    return "../../Images/Snow.png";
                case 24:
                case 25:
                case 26:
                case 31:
                    return "../../Images/Ice.png";
                case 29:
                    return "../../Images/RainAndIce.png";
                case 32:
                    return "../../Images/Wind.png";
                case 33:
                    return "../../Images/NightClear.png";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
