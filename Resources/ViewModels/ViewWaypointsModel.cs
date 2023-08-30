using MAUIpractice.Resources.Models;
using MAUIpractice.Resources.Views;
using Microsoft.Maui.Devices.Sensors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MAUIpractice.Resources.ViewModels
{
    public class ViewWaypointsModel
    {

        public ObservableCollection<WaypointModel> ListOfWaypoints { get; set; }

        public ViewWaypointsModel()
        {
            ListOfWaypoints = new ObservableCollection<WaypointModel>();
            ConvertXml();
        }

        public async Task ConvertXml()
        {

            KeysModel apiKeys = new();

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://aisweb.decea.gov.br/api/");
                HttpResponseMessage response = await client.GetAsync($"?{apiKeys.GetDeceaApiKey()}&{apiKeys.GetDeceaApiPass()}&area=waypoints&rowend=7000");

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    XmlSerializer serializer = new XmlSerializer(typeof(Aisweb));

                    using (StringReader reader = new StringReader(responseBody))
                    {
                        Aisweb aisweb = (Aisweb)serializer.Deserialize(reader);

                        foreach (var item in aisweb.waypoints.item)
                        {
                            ListOfWaypoints.Add(new WaypointModel()
                            {
                                Id = item.id,
                                Ident = item.ident,
                                Latitude = item.latitude,
                                Longitude = item.longitude,
                                Dt = item.dt,
                            });
                        }
                    }
                }

                else
                {
                    return;
                }
            }
        }

        public double GetDistance(int id1, int id2)
        {
            //Calculates the distance between two points provided by the user in nautical miles (aviaton pattern)
            double distance = 0;
            const double pi = 3.141592;
            double firstWaypointLat = 0;
            double firstWaypointLong = 0;
            double secondWaypointLat = 0;
            double secondWaypointLong = 0;

            foreach(var item in ListOfWaypoints)
            {
                if(item.Id == id1)
                {
                    firstWaypointLat =  Convert.ToDouble(item.Latitude);
                    firstWaypointLong = Convert.ToDouble(item.Longitude);
                }

                if(item.Id == id2)
                {
                    secondWaypointLat = Convert.ToDouble(item.Latitude);
                    secondWaypointLong = Convert.ToDouble(item.Longitude);
                }
            }

            firstWaypointLat = firstWaypointLat * (pi / 180.0);
            secondWaypointLat = secondWaypointLat * (pi / 180.0);
            firstWaypointLong = firstWaypointLong * (pi / 180.0);
            secondWaypointLong = secondWaypointLong * (pi / 180.0);


            distance = 3440.07 * Math.Acos(Math.Sin(firstWaypointLat) 
                               * Math.Sin(secondWaypointLat) 
                               + Math.Cos(firstWaypointLat) 
                               * Math.Cos(secondWaypointLat) 
                               * Math.Cos(secondWaypointLong - firstWaypointLong));

            return Math.Ceiling(distance);

        }

    }
}
