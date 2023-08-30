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
        public string Name { get; set; }
        public string City { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public AirportModel()
        {
            Airport = string.Empty;
            Latitude = 0;
            Longitude = 0;
        }

        public void SetAirport(string airport)
        {
            Airport = airport;
        }

        public string GetAirport()
        {
            return Airport;
        }

        public string GetAirportDetails()
        {
            return $"{Name} - {City}";
        }
    }

    
}
