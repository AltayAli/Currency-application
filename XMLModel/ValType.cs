using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MerkeziBankApp.XMLModel
{
    public class ValType
    {
        [XmlAttribute]
        public string Type { get; set; }
        [XmlElement]
        public Valute[] Valute { get; set; }
    }
}
