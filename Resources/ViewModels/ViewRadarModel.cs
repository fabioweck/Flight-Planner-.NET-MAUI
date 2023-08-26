using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUIpractice.Resources.Models;

namespace MAUIpractice.Resources.ViewModels
{
    public class ViewRadarModel
    {
        public string RadarLink { get; set; }
        public string RadarDate { get; set; }

        public ViewRadarModel()
        {
            RadarLink = string.Empty;
            RadarDate = string.Empty;
        }


        public async Task GetRadarLink()
        {
            KeysModel apiKey = new();

            string type = "realcada";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api-redemet.decea.mil.br/produtos/satelite/");

                HttpResponseMessage responseRadar = await client.GetAsync($"{type}?{apiKey.GetRedemetApiKey()}");

                try
                {
                    if (responseRadar.IsSuccessStatusCode)
                    {
                        string responseBody = await responseRadar.Content.ReadAsStringAsync();
                        var dataSet = JsonConvert.DeserializeObject<RadarModel>(responseBody);

                        RadarLink = dataSet?.data.satelite[0].path;
                        RadarDate = dataSet?.data.satelite[0].data;

                    }

                    else
                    {
                        RadarLink = "API request failed. Status code: " + responseRadar.StatusCode;
                    }
                }
                catch
                {
                    RadarLink = "METAR not found for this location.";
                }
            }
        }

        public string GetLink()
        {
            return RadarLink;
        }

        public string GetDate()
        {
            return RadarDate;
        }
    }
}

    
