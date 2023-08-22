using MAUIpractice.Resources.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.ViewModels
{
    public class ViewWeatherModel
    {
        public string GetMetar { get; set; }
        public string GetTaf { get; set; }
        public ObservableCollection<MetarTafModel> Weather { get; set; }
        public Command<MetarTafModel> Delete { get; set; }
        public ViewWeatherModel()
        {
            Weather = new ObservableCollection<MetarTafModel>();

            Delete = new Command<MetarTafModel>(data =>
            {
                Weather.Remove(data);
            });
        }
        public async Task AddWeather(string location)
        {
            string apiKey = "api_key=sJgea8VlPUfxZDd2pH1p3DDw2Vyog6cMNDfres44";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api-redemet.decea.mil.br/mensagens/");
                HttpResponseMessage responseMetar = await client.GetAsync($"metar/{location}?{apiKey}");
                try
                {
                    if (responseMetar.IsSuccessStatusCode)
                    {
                        string responseBody = await responseMetar.Content.ReadAsStringAsync();
                        var dataSet = JsonConvert.DeserializeObject<WeatherModel>(responseBody);

                        GetMetar = dataSet?.data.data[0].mens;

                    }

                    else
                    {
                        GetMetar = "API request failed. Status code: " + responseMetar.StatusCode;
                    }
                }
                catch
                {
                    GetMetar = "METAR not found for this location.";
                }
                

                HttpResponseMessage responseTaf = await client.GetAsync($"taf/{location}?{apiKey}");

                try
                {
                    if (responseTaf.IsSuccessStatusCode)
                    {
                        string responseBody = await responseTaf.Content.ReadAsStringAsync();
                        var dataSet = JsonConvert.DeserializeObject<WeatherModel>(responseBody);

                        GetTaf = dataSet?.data.data[0].mens;

                    }

                    else
                    {
                        GetTaf = "API request failed. Status code: " + responseTaf.StatusCode;
                    }
                }

                catch
                { 
                    GetTaf = "TAF not found for this location.";
                }
                
                Weather.Add(new MetarTafModel() { Metar = GetMetar, Taf = GetTaf });
            }

        }

        public void ClearWeather()
        {
            Weather.Clear();
        }
    }
}
