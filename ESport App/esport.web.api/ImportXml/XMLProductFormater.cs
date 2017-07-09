using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportXml
{
    [XmlRoot("Productos")]
    public class XmlProductFormater
    {
        [XmlElement("Producto")]
        public List<XmlProductItemFormater> Products { get; set; }
    }

    
}
