using MAUIpractice.Resources.Models;
using Microsoft.Maui.Devices.Sensors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.ViewModels
{
    public class ViewSigwxModel
    {

        public SigwxModel Sigwx;

        public ViewSigwxModel()
        {
            Sigwx = new();
        }

        public async Task GetSigwxLink()
        {

            KeysModel apiKey = new();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api-redemet.decea.mil.br/produtos/");
                HttpResponseMessage responseSigwx = await client.GetAsync($"sigwx?{apiKey.GetRedemetApiKey()}");

                try
                {
                    if (responseSigwx.IsSuccessStatusCode)
                    {
                        string responseBody = await responseSigwx.Content.ReadAsStringAsync();
                        responseBody.Trim();
                        Sigwx.Link = responseBody;

                    }

                    else
                    {
                        Sigwx.Link = "API request failed. Status code: " + responseSigwx.StatusCode;
                    }
                }
                catch (Exception ex)
                {
                    Sigwx.Link = "Sigwx not found " + ex;
                }
            }
        }

        public string GetLink()
        {
            return Sigwx.Link;
        }
    }
}
