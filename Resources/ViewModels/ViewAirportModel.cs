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
        string airport;

        public ViewAirportModel()
        {

        }

        public void Clear()
        {
            airport = string.Empty;
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

                    airport = responseBody;

                    //#region Start

                    //XmlSerializer serializer = new(typeof(Rotaer));

                    //XmlReaderSettings settings = new XmlReaderSettings();
                    //settings.Async = true;
                    //settings.IgnoreWhitespace = true;
                    //XmlReader reader = XmlReader.Create(responseBody, settings);

                    //Rotaer rotaer;

                    //rotaer = (Rotaer)serializer.Deserialize(reader);

                    //airport = $"Item id: {rotaer.AeroCode}";
                    //return airport;

                    //#region End

                    //string[] nodes = { "name", "city", "fir"};

                    //XmlReaderSettings settings = new XmlReaderSettings();
                    //settings.Async = true;
                    //settings.IgnoreWhitespace = true;

                    //using (XmlReader reader = XmlReader.Create(responseBody, settings))
                    //{
                    //    await reader.ReadAsync();

                    //    while (await reader.ReadAsync())
                    //    {

                    //        if(reader.NodeType == XmlNodeType.EndElement)
                    //        {
                    //            continue;
                    //        }

                    //        if (reader.NodeType == XmlNodeType.Element && reader.HasAttributes)
                    //        {
                    //            airport += reader.GetAttribute("descr");
                    //        }    

                    //        airport += $"{reader.Value}\n";


                    //        //foreach(string item in nodes)
                    //        //{
                    //        //    if (reader.NodeType == XmlNodeType.Element && reader.Name == item)
                    //        //    {
                    //        //        reader.Read();
                    //        //        airport += $"{reader.Value} ";
                    //        //        break;
                    //        //    }
                    //        //}

                    //    }
                    //}

                    return airport;

                }

                else
                {
                    airport = $"Error: {response.StatusCode}";
                    return airport;
                }
            }
        }
    }
}
