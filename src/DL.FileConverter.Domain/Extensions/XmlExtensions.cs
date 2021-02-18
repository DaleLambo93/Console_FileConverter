using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DL.FileConverter.Domain.Extensions
{
    public static class XmlExtensions
    {
        public static string SerializeXml<T>(this T dataToSerialize)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces(); 
            ns.Add("", "");
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, dataToSerialize, ns);
                ms.Position = 0;
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }            
        }

        public static T DeserializeXml<T>(this string xmlText)
        {
            var stringReader = new StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stringReader);
        }
    }
}
