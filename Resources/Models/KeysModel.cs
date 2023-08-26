using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.Models
{
    public class KeysModel
    {
        private string redemetApiKey;
        private string deceaApiKey;
        private string deceaApiPass;

        public KeysModel()
        {
            redemetApiKey = "api_key=sJgea8VlPUfxZDd2pH1p3DDw2Vyog6cMNDfres44";
            deceaApiKey = "apiKey=1999328818";
            deceaApiPass = "apiPass=89d22412-1f35-11ee-a2b8-0050569ac2e1";
        }

        public string GetRedemetApiKey() { return redemetApiKey; }

        public string GetDeceaApiKey() { return deceaApiKey; }

        public string GetDeceaApiPass() { return deceaApiPass; }
    }
}
