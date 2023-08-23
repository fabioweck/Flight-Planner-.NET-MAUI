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
    public partial class Charts
    {

        private aiswebCartas cartasField;

        /// <remarks/>
        public aiswebCartas cartas
        {
            get
            {
                return this.cartasField;
            }
            set
            {
                this.cartasField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class aiswebCartas
    {

        private aiswebCartasItem[] itemField;

        private System.DateTime emendaField;

        private string lastupdateField;

        private byte totalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item")]
        public aiswebCartasItem[] item
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime emenda
        {
            get
            {
                return this.emendaField;
            }
            set
            {
                this.emendaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string lastupdate
        {
            get
            {
                return this.lastupdateField;
            }
            set
            {
                this.lastupdateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte total
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
    public partial class aiswebCartasItem
    {

        private string idField;

        private string especieField;

        private string tipoField;

        private string tipo_descrField;

        private string nomeField;

        private string icaoCodeField;

        private System.DateTime dtField;

        private string linkField;

        private string arquivoField;

        private object kmzField;

        private object avisoField;

        private string icpField;

        private byte peField;

        private object notamField;

        private string tabcodeField;

        private aiswebCartasItemSuplementos suplementosField;

        private System.DateTime dtPublicField;

        private string amdtField;

        private string useField;

        private string id1Field;

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
        public string especie
        {
            get
            {
                return this.especieField;
            }
            set
            {
                this.especieField = value;
            }
        }

        /// <remarks/>
        public string tipo
        {
            get
            {
                return this.tipoField;
            }
            set
            {
                this.tipoField = value;
            }
        }

        /// <remarks/>
        public string tipo_descr
        {
            get
            {
                return this.tipo_descrField;
            }
            set
            {
                this.tipo_descrField = value;
            }
        }

        /// <remarks/>
        public string nome
        {
            get
            {
                return this.nomeField;
            }
            set
            {
                this.nomeField = value;
            }
        }

        /// <remarks/>
        public string IcaoCode
        {
            get
            {
                return this.icaoCodeField;
            }
            set
            {
                this.icaoCodeField = value;
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
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }

        /// <remarks/>
        public string arquivo
        {
            get
            {
                return this.arquivoField;
            }
            set
            {
                this.arquivoField = value;
            }
        }

        /// <remarks/>
        public object kmz
        {
            get
            {
                return this.kmzField;
            }
            set
            {
                this.kmzField = value;
            }
        }

        /// <remarks/>
        public object aviso
        {
            get
            {
                return this.avisoField;
            }
            set
            {
                this.avisoField = value;
            }
        }

        /// <remarks/>
        public string icp
        {
            get
            {
                return this.icpField;
            }
            set
            {
                this.icpField = value;
            }
        }

        /// <remarks/>
        public byte pe
        {
            get
            {
                return this.peField;
            }
            set
            {
                this.peField = value;
            }
        }

        /// <remarks/>
        public object notam
        {
            get
            {
                return this.notamField;
            }
            set
            {
                this.notamField = value;
            }
        }

        /// <remarks/>
        public string tabcode
        {
            get
            {
                return this.tabcodeField;
            }
            set
            {
                this.tabcodeField = value;
            }
        }

        /// <remarks/>
        public aiswebCartasItemSuplementos suplementos
        {
            get
            {
                return this.suplementosField;
            }
            set
            {
                this.suplementosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime dtPublic
        {
            get
            {
                return this.dtPublicField;
            }
            set
            {
                this.dtPublicField = value;
            }
        }

        /// <remarks/>
        public string amdt
        {
            get
            {
                return this.amdtField;
            }
            set
            {
                this.amdtField = value;
            }
        }

        /// <remarks/>
        public string use
        {
            get
            {
                return this.useField;
            }
            set
            {
                this.useField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("id")]
        public string id1
        {
            get
            {
                return this.id1Field;
            }
            set
            {
                this.id1Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class aiswebCartasItemSuplementos
    {

        private byte countField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }
    }


}
