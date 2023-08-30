using MAUIpractice.Resources.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MAUIpractice.Resources.ViewModels
{

    public class ViewAirportListModel
    {

        public ObservableCollection<AirportModel> Airports { get; set; }
        public List<AirportModel> CalculateDistance { get; set; }
        private string filePath;

        public ViewAirportListModel()
        {

            string getFilePath = Assembly.GetExecutingAssembly().Location;
            int index = getFilePath.IndexOf("bin");
            getFilePath = getFilePath.Substring(0, index);
            getFilePath += @"Resources\Files\airport_list.csv";
            filePath = getFilePath;
            Airports = new();
            CalculateDistance = new();
            PopulateList();

        }

        public async Task FetchList()
        {
            KeysModel apiKeys = new();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://aisweb.decea.gov.br/api/");
                HttpResponseMessage response = await client.GetAsync($"?{apiKeys.GetDeceaApiKey()}&{apiKeys.GetDeceaApiPass()}&area=rotaer&rowend=6000");

                if(response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    XmlSerializer serializer = new XmlSerializer(typeof(AirportListModel));

                    using(StringReader reader = new StringReader(responseBody))
                    {

                        AirportListModel AirportList = (AirportListModel)serializer.Deserialize(reader);

                        using(StreamWriter writer = new StreamWriter(filePath))
                        {
                            foreach (var airport in AirportList.rotaer.item)
                            {
                                writer.WriteLine(airport.AeroCode);
                            }
                        }
                    }
                }
            }           
        }

        public void PopulateList()
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    Airports.Add(new AirportModel() { Airport = line });
                }

                streamReader.Close();
            }
        }

        public async Task<string> GetAirportCoordinates(string location)
        {
            string airportDetails = string.Empty;
            KeysModel apiKeys = new();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://aisweb.decea.gov.br/api/");
                HttpResponseMessage response = await client.GetAsync($"?{apiKeys.GetDeceaApiKey()}&{apiKeys.GetDeceaApiPass()}&area=rotaer&aero={location}");

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    XmlSerializer serializer = new XmlSerializer(typeof(AirportListModel));

                    using (StringReader reader = new StringReader(responseBody))
                    {

                        AirportListModel AirportList = (AirportListModel)serializer.Deserialize(reader);

                        AirportModel AddAirport = new AirportModel()
                        {
                            Airport = AirportList.rotaer.item[0].AeroCode,
                            Name = AirportList.rotaer.item[0].name,
                            City = AirportList.rotaer.item[0].city,
                            Latitude = AirportList.rotaer.item[0].lat,
                            Longitude = AirportList.rotaer.item[0].lng,
                        };

                        CalculateDistance.Add(AddAirport);

                        airportDetails = AddAirport.GetAirportDetails();

                        return airportDetails;

                    }
                }
                else
                {
                    airportDetails = "Unable to find location.";
                    return airportDetails;
                }
            }
        }

        public void RemoveLastAirport()
        {
            CalculateDistance.RemoveAt(1);
        }

        public double GetDistance()
        {

            //Calculates the distance between two points provided by the user in nautical miles (aviaton pattern)
            double distance = 0;
            const double pi = 3.14;
            double firstWaypointLat = Math.Round(Convert.ToDouble(CalculateDistance[0].Latitude), 2);
            double firstWaypointLong = Math.Round(Convert.ToDouble(CalculateDistance[0].Longitude), 2);
            double secondWaypointLat = Math.Round(Convert.ToDouble(CalculateDistance[1].Latitude), 2);
            double secondWaypointLong = Math.Round(Convert.ToDouble(CalculateDistance[1].Longitude), 2);

            firstWaypointLat = Math.Round(firstWaypointLat * (pi / 180.0), 3);
            secondWaypointLat = Math.Round(secondWaypointLat * (pi / 180.0), 3);
            firstWaypointLong = Math.Round(firstWaypointLong * (pi / 180.0), 3);
            secondWaypointLong = Math.Round(secondWaypointLong * (pi / 180.0), 3);


            distance = 3440.07 * Math.Acos(Math.Sin(firstWaypointLat)
                               * Math.Sin(secondWaypointLat)
                               + Math.Cos(firstWaypointLat)
                               * Math.Cos(secondWaypointLat)
                               * Math.Cos(secondWaypointLong - firstWaypointLong));

            return Math.Round(distance, 1);

        }

        public string GetTime(double distance, int speed)
        {
            
            DateTime newTime = new DateTime(2000,01,01,0,0,0);
            int time = Convert.ToInt32((distance * 60) / speed);
            DateTime flightTime = newTime.AddMinutes(time);
            string timeString = flightTime.ToString("HH:mm");

            return timeString;
        }

        public void ClearCalculateDistance()
        {
            CalculateDistance.Clear();
        }

    }
}
