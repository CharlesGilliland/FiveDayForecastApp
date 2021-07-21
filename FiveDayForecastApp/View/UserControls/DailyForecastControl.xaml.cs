using FiveDayForecastApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FiveDayForecastApp.View.UserControls
{
    /// <summary>
    /// Interaction logic for DailyForecastControl.xaml
    /// </summary>
    public partial class DailyForecastControl : UserControl
    {


        public DailyForecast DailyForecast
        {
            get { return (DailyForecast)GetValue(DailyForecastProperty); }
            set { SetValue(DailyForecastProperty, value); }
        }

        public static readonly DependencyProperty DailyForecastProperty = DependencyProperty.Register("DailyForecast", typeof(DailyForecast), typeof(DailyForecastControl), new PropertyMetadata(null, SetValues));

        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DailyForecastControl dailyForecastControl = d as DailyForecastControl;

            if(dailyForecastControl != null)
            {
                dailyForecastControl.DataContext = dailyForecastControl.DailyForecast;
            }
        }

        public DailyForecastControl()
        {
            InitializeComponent();
        }
    }
}
