using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MerkeziBankApp.XMLModel
{
    public class ValCurs
    {
        [XmlAttribute]
        public string Date { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Description { get; set; }

        [XmlElement]
        public ValType[] ValType { get; set; }
    }
}
