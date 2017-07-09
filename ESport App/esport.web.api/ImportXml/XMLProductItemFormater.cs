using System.Xml.Serialization;

namespace ImportXml
{
    public class XmlProductItemFormater
    {
        [XmlAttribute("Nombre")]
        public string ProductName { get; set; }
        [XmlElement("Codigo")]
        public string ProductId { get; set; }
        [XmlElement("Fabricante")]
        public string Factory { get; set; }
        [XmlElement("Precio")]
        public double Price { get; set; }
        [XmlElement("Descripcion")]
        public string Description { get; set; }
        [XmlElement("Stock")]
        public int AvailableStock { get; set; }
        [XmlElement("Categoria")]
        public string CategetoryId { get; set; }

        
    }
}
