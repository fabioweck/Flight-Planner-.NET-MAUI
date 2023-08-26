using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.Models
{

    public class RadarModel
    {
        public bool status { get; set; }
        public int message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string tipo { get; set; }
        public Lat_Lon lat_lon { get; set; }
        public string[] anima { get; set; }
        public Satelite[] satelite { get; set; }
    }

    public class Lat_Lon
    {
        public int id { get; set; }
        public string lon_min { get; set; }
        public string lon_max { get; set; }
        public string lat_min { get; set; }
        public string lat_max { get; set; }
    }

    public class Satelite
    {
        public string data { get; set; }
        public string path { get; set; }
        public int tamanho { get; set; }
    }

}
