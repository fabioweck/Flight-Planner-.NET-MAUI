using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MAUIpractice.Resources.Models
{

    public class Rootobject
    {
        public Aisweb aisweb { get; set; }
    }

    public class Rotaer
    {
        public string status { get; set; }
        public string dt { get; set; }
        public string AeroCode { get; set; }
        public string ciad { get; set; }
        public Name name { get; set; }
        public City city { get; set; }
        public string uf { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public string latRotaer { get; set; }
        public string lngRotaer { get; set; }
        public string distance { get; set; }
        public Org org { get; set; }
        public string workinghour { get; set; }
        public string type { get; set; }
        public string typeUtil { get; set; }
        public string typeOpr { get; set; }
        public string cat { get; set; }
        public int utc { get; set; }
        public float altM { get; set; }
        public int altFt { get; set; }
        public string fir { get; set; }
        public string jur { get; set; }
        public Lights lights { get; set; }
        public Runways runways { get; set; }
        public Services services { get; set; }
        public Rmk rmk { get; set; }
        public Rmkdistdeclared rmkDistDeclared { get; set; }
        public Compls compls { get; set; }
        public Timesheets timesheets { get; set; }
    }

    public class Name
    {
        public string __cdata { get; set; }
    }

    public class City
    {
        public string __cdata { get; set; }
    }

    public class Org
    {
        public string name { get; set; }
        public string type { get; set; }
        public string military { get; set; }
    }

    public class Lights
    {
        public string[] light { get; set; }
    }

    public class Runways
    {
        public Runway[] runway { get; set; }
    }

    public class Runway
    {
        public string type { get; set; }
        public string ident { get; set; }
        public string surface { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public string surface_c { get; set; }
        public object[] lights { get; set; }
        public Thr[] thr { get; set; }
    }

    public class Thr
    {
        public int ident { get; set; }
        public Lights1 lights { get; set; }
    }

    public class Lights1
    {
        public string[] light { get; set; }
    }

    public class Services
    {
        public Service[] service { get; set; }
    }

    public class Service
    {
        public string fuel { get; set; }
        public string ser { get; set; }
        public Rffs rffs { get; set; }
        public string type { get; set; }
        public string callsign { get; set; }
        public Freqs freqs { get; set; }
        public Org1 org { get; set; }
        public string cat { get; set; }
        public int thr { get; set; }
        public string ident { get; set; }
        public object freq { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string contact { get; set; }
        public string products { get; set; }
        public int selfservice { get; set; }
    }

    public class Rffs
    {
        public int cat { get; set; }
    }

    public class Freqs
    {
        public object freq { get; set; }
    }

    public class Org1
    {
        public string name { get; set; }
        public string type { get; set; }
        public string military { get; set; }
    }

    public class Rmk
    {
        public Rmktext[] rmkText { get; set; }
    }

    public class Rmktext
    {
        public string __cdata { get; set; }
    }

    public class Rmkdistdeclared
    {
        public Rmkdist[] rmkDist { get; set; }
    }

    public class Rmkdist
    {
        public Rwy rwy { get; set; }
        public Tora tora { get; set; }
        public Toda toda { get; set; }
        public Asda asda { get; set; }
        public Lda lda { get; set; }
        public string aux { get; set; }
        public Altgeoidal altGeoidal { get; set; }
        public Lat lat { get; set; }
        public Lng lng { get; set; }
    }

    public class Rwy
    {
        public string __cdata { get; set; }
    }

    public class Tora
    {
        public string __cdata { get; set; }
    }

    public class Toda
    {
        public string __cdata { get; set; }
    }

    public class Asda
    {
        public string __cdata { get; set; }
    }

    public class Lda
    {
        public string __cdata { get; set; }
    }

    public class Altgeoidal
    {
        public string __cdata { get; set; }
    }

    public class Lat
    {
        public string __cdata { get; set; }
    }

    public class Lng
    {
        public string __cdata { get; set; }
    }

    public class Compls
    {
        public Compl[] compl { get; set; }
    }

    public class Compl
    {
        public string __cdata { get; set; }
    }

    public class Timesheets
    {
        public Timesheet timesheet { get; set; }
    }

    public class Timesheet
    {
        public Days days { get; set; }
        public Hours hours { get; set; }
        public int hol { get; set; }
    }

    public class Days
    {
        public string day { get; set; }
    }

    public class Hours
    {
        public string begin { get; set; }
        public string end { get; set; }
    }

}