using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.Models
{
    public class AirportModel
    {
        public string Airport { get; set; }

        public AirportModel()
        {
            Airport = string.Empty;
        }

        public void SetAirport(string airport)
        {
            Airport = airport;
        }

        public string GetAirport()
        {
            return Airport;
        }
    }

    
}
