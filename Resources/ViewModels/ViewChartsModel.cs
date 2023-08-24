using MAUIpractice.Resources.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MAUIpractice.Resources.ViewModels
{
    public class ViewChartsModel
    {
        public ObservableCollection<ChartModel> Charts { get; set; }

        public string link;

        public ViewChartsModel() 
        {
            Charts = new();

        }

        public async Task GetCharts(string location)
        {
            Charts.Clear();
            string apiKey = "apiKey=1999328818";
            string apiPass = "apiPass=89d22412-1f35-11ee-a2b8-0050569ac2e1";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://aisweb.decea.gov.br/api/");
                HttpResponseMessage response = await client.GetAsync($"?{apiKey}&{apiPass}&area=cartas&icaoCode={location}");

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    XmlSerializer serializer = new XmlSerializer(typeof(Charts));

                    using (StringReader reader = new StringReader(responseBody))
                    {
                        Charts chartsList = (Charts)serializer.Deserialize(reader);

                        foreach (var item in chartsList.cartas.item)
                        {
                            Charts.Add(new ChartModel()
                            {
                                Id = item.id,
                                Name = item.nome,
                                Description = item.tipo,
                                Link = item.link,
                                Date = item.dt,
                            });
                        }                      
                    }
                }
            }
        }
    }
}
