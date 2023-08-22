using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.Models
{
    public class WaypointModel
    {
        public ushort id { get; set; }
        public string ident { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public DateTime dt { get; set; }
    }
}
