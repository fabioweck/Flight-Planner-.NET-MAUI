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
        }

        public async Task<string> ConvertXml(string waypointSearch)
        {
            string apiKey = "apiKey=1999328818";
            string apiPass = "apiPass=89d22412-1f35-11ee-a2b8-0050569ac2e1";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://aisweb.decea.gov.br/api/");
                HttpResponseMessage response = await client.GetAsync($"?{apiKey}&{apiPass}&area=waypoints&ident={waypointSearch}");

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
                                id = item.id,
                                ident = item.ident,
                                latitude = item.latitude,
                                longitude = item.longitude,
                                dt = item.dt,
                            });
                        }

                        waypoint = $"Item id: {aisweb.waypoints.item[0].ident}";
                        return waypoint;
                    }
                }

                else
                {
                    waypoint = $"Error: {response.StatusCode}";
                    return waypoint;
                }
            }
        }
    }
}
