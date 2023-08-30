using MAUIpractice.Resources.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MAUIpractice.Resources.ViewModels
{
    public class ViewAirportModel
    {
        AirportModel Airport;

        public ViewAirportModel()
        {

        }

        public void Clear()
        {
            Airport = new();
        }

        public async Task<string> ConvertXml(string airportSearch)
        {

            KeysModel apiKeys = new();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://aisweb.decea.gov.br/api/");

                HttpResponseMessage response = await client.GetAsync($"?{apiKeys.GetDeceaApiKey()}&{apiKeys.GetDeceaApiPass()}&area=rotaer&icaoCode={airportSearch}&force=html");

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    responseBody.TrimStart();

                    Airport.SetAirport(responseBody);

                    return Airport.GetAirport();

                }

                else
                {
                    Airport.SetAirport($"Error: {response.StatusCode}");
                    return Airport.GetAirport();
                }
            }
        }
    }
}
