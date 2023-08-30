using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

    public partial class AirportListModel
    {

        private aiswebRotaer rotaerField;

        /// <remarks/>
        public aiswebRotaer rotaer
        {
            get
            {
                return this.rotaerField;
            }
            set
            {
                this.rotaerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class aiswebRotaer
    {

        private aiswebRotaerItem[] itemField;

        private int pagesizeField;

        private ushort totalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item")]
        public aiswebRotaerItem[] item
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
        public int pagesize
        {
            get
            {
                return this.pagesizeField;
            }
            set
            {
                this.pagesizeField = value;
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
    public partial class aiswebRotaerItem
    {

        private string idField;

        private string typeField;

        private string aeroCodeField;

        private string ciadField;

        private string nameField;

        private string cityField;

        private string ufField;

        private decimal lngField;

        private decimal latField;

        private System.DateTime dtField;

        private ushort ciad_idField;

        /// <remarks/>
        public string id
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
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string AeroCode
        {
            get
            {
                return this.aeroCodeField;
            }
            set
            {
                this.aeroCodeField = value;
            }
        }

        /// <remarks/>
        public string ciad
        {
            get
            {
                return this.ciadField;
            }
            set
            {
                this.ciadField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string city
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string uf
        {
            get
            {
                return this.ufField;
            }
            set
            {
                this.ufField = value;
            }
        }

        /// <remarks/>
        public decimal lng
        {
            get
            {
                return this.lngField;
            }
            set
            {
                this.lngField = value;
            }
        }

        /// <remarks/>
        public decimal lat
        {
            get
            {
                return this.latField;
            }
            set
            {
                this.latField = value;
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort ciad_id
        {
            get
            {
                return this.ciad_idField;
            }
            set
            {
                this.ciad_idField = value;
            }
        }
    }


}
