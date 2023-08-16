using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.Models
{
    public class WeatherModel
    {
        public bool status { get; set; }
        public int message { get; set; }
        public Data data { get; set; }

        public class Data
        {
            public int current_page { get; set; }
            public Datum[] data { get; set; }
            public string first_page_url { get; set; }
            public int from { get; set; }
            public int last_page { get; set; }
            public string last_page_url { get; set; }
            public object next_page_url { get; set; }
            public string path { get; set; }
            public int per_page { get; set; }
            public object prev_page_url { get; set; }
            public int to { get; set; }
            public int total { get; set; }
        }

        public class Datum
        {
            public string id_localidade { get; set; }
            public string validade_inicial { get; set; }
            public string mens { get; set; }
            public string recebimento { get; set; }
        }
    }
}
