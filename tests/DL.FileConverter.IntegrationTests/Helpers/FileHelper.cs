using System.IO;
using System.Text;
using System.Xml.Linq;

namespace DL.FileConverter.IntegrationTests.Helpers
{
    public static class FileHelper
    {
        public static void CreateCsvFile(string name,
            string address1,
            string address2,
            string filePath)
        {
            if (Directory.Exists(filePath))
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("name,address_line1,address_line2\r\n");
                stringBuilder.Append($"{name},{address1},{address2}\r\n");

                File.WriteAllText($"{filePath}//File{name}.csv", stringBuilder.ToString());
            }
        }

        public static void CreateIncorrectFile(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("Test,\r\n");
                stringBuilder.Append($"Test1, \r\n");

                File.WriteAllText(filePath, stringBuilder.ToString());
            }
        }

        public static string XmlFileReader(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            var xDocument = XDocument.Load(filePath);
            return xDocument.ToString();
        }
    }
}
