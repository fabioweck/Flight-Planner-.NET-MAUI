using MAUIpractice.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.ViewModels
{
    public class ViewFlightPackageModel
    {

        public ViewFlightPackageModel()
        {

        }

        public void AddWeather(string weather)
        {
            FlightPackageModel.Weather = weather;
        }

        public string GetWeather()
        {
            return FlightPackageModel.Weather;
        }

        public void AddSigwx(string link)
        {
            FlightPackageModel.Sigwx = link;
        }

        public string GetSigwx()
        {
            return FlightPackageModel.Sigwx;
        }

        public void AddSatellite(string link)
        {
            FlightPackageModel.Satellite = link;
        }

        public string GetSatellite()
        {
            return FlightPackageModel.Satellite;
        }

        public void AddChart(Stream chart)
        {
            FlightPackageModel.Chart = chart;
        }

        public Stream GetChart()
        {
            return FlightPackageModel.Chart;
        }
    }
}
