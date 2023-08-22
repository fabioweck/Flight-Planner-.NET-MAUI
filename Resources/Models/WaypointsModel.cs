using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MAUIpractice.Resources.Models
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [XmlRoot("aisweb")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Aisweb
    {

        private aiswebWaypoints waypointsField;

        /// <remarks/>
        public aiswebWaypoints waypoints
        {
            get
            {
                return this.waypointsField;
            }
            set
            {
                this.waypointsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class aiswebWaypoints
    {

        private aiswebWaypointsItem[] itemField;

        private ushort totalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item")]
        public aiswebWaypointsItem[] item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class aiswebWaypointsItem
    {

        private ushort idField;

        private string identField;

        private decimal latitudeField;

        private decimal longitudeField;

        private System.DateTime dtField;

        /// <remarks/>
        public ushort id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string ident
        {
            get
            {
                return this.identField;
            }
            set
            {
                this.identField = value;
            }
        }

        /// <remarks/>
        public decimal latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <remarks/>
        public decimal longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime dt
        {
            get
            {
                return this.dtField;
            }
            set
            {
                this.dtField = value;
            }
        }
    }
}




