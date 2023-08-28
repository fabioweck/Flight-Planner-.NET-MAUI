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
        string waypoint;
        public ObservableCollection<WaypointModel> ListOfWaypoints { get; set; }

        public ViewWaypointsModel()
        {
            ListOfWaypoints = new ObservableCollection<WaypointModel>();
            ConvertXml();
        }

        public async Task ConvertXml()
        {
            string apiKey = "apiKey=1999328818";
            string apiPass = "apiPass=89d22412-1f35-11ee-a2b8-0050569ac2e1";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://aisweb.decea.gov.br/api/");
                HttpResponseMessage response = await client.GetAsync($"?{apiKey}&{apiPass}&area=waypoints&rowend=7000");

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

                        waypoint = $"Item id: {aisweb.waypoints.item[0].ident}";

                    }
                }

                else
                {
                    waypoint = $"Error: {response.StatusCode}";
                }
            }
        }

        public double GetDistance(int id1, int id2)
        {
            //Calculates the distance between two points provided by the user in nautical miles (aviaton pattern)
            double distance = 0;
            double pi = Math.PI;
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
            firstWaypointLong = firstWaypointLat * (pi / 180.0);
            secondWaypointLong = secondWaypointLat * (pi / 180.0);

            distance = 3963 * Math.Acos(Math.Sin(firstWaypointLat) * Math.Sin(secondWaypointLat) + Math.Cos(firstWaypointLat) * Math.Cos(secondWaypointLat) * Math.Cos(secondWaypointLong - firstWaypointLong));

            return distance;

        }

    }
}
