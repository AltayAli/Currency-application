using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MerkeziBankApp.XMLModel
{
   public class Valute
    {
        [XmlAttribute]
        public string Code { get; set; }
        public string Nominal { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
