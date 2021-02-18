using System.Xml.Serialization;

namespace DL.FileConverter.Domain.Entities
{
    public class AddressEntity
    {
        [XmlElement(ElementName = "address_line1")]
        public string AddressLine1 { get; set; }
        [XmlElement(ElementName = "address_line2")]
        public string AddressLine2 { get; set; }
    }
}
