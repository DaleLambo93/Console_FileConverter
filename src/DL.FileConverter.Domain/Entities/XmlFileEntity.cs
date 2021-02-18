using System.Xml.Serialization;

namespace DL.FileConverter.Domain.Entities
{
    public class XmlFileEntity
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "address")]
        public AddressEntity Address { get; set; }
    }
}
