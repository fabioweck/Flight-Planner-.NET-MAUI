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
        private string filePath;

        public ViewAirportListModel()
        {
            string getFilePath = Assembly.GetExecutingAssembly().Location;
            int index = getFilePath.IndexOf("bin");
            getFilePath = getFilePath.Substring(0, index);
            getFilePath += @"Resources\Files\airport_list.csv";
            filePath = getFilePath;
            Airports = new();
            PopulateList();
        }

        public async Task FetchList()
        {
            KeysModel apiKeys = new();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://aisweb.decea.gov.br/api/");
                HttpResponseMessage response = await client.GetAsync($"?{apiKeys.GetDeceaApiKey()}&{apiKeys.GetDeceaApiPass()}&area=rotaer&rowstart=4993&rowend=500");

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
    }
}
