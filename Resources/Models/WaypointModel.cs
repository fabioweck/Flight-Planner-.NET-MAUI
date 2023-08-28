using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.Models
{
    public class WaypointModel
    {
        public ushort Id { get; set; }
        public string Ident { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime Dt { get; set; }
    }
}
