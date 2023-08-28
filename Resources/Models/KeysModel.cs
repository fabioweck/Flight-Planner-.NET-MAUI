using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.Models
{
    public class KeysModel
    {
        private string _redemetApiKey;
        private string _deceaApiKey;
        private string _deceaApiPass;

        public KeysModel()
        {
            _redemetApiKey = "api_key=sJgea8VlPUfxZDd2pH1p3DDw2Vyog6cMNDfres44";
            _deceaApiKey = "apiKey=1999328818";
            _deceaApiPass = "apiPass=89d22412-1f35-11ee-a2b8-0050569ac2e1";
        }

        public string GetRedemetApiKey() { return _redemetApiKey; }

        public string GetDeceaApiKey() { return _deceaApiKey; }

        public string GetDeceaApiPass() { return _deceaApiPass; }
    }
}
