using CsvHelper;
using DL.FileConverter.Domain.Entities;
using DL.FileConverter.Domain.Extensions;
using DL.FileConverter.Domain.Mappers;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace DL.FileConverter.Domain.UseCases.ConvertFile.Converters
{
    public class CsvConverter : IConverter
    {
        private readonly IMapper<CsvFileEntity, XmlFileEntity> _mapper;

        public  CsvConverter(IMapper<CsvFileEntity, XmlFileEntity> mapper)
        {
            _mapper = mapper;
        }

        public string Convert(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            StringWriter sw = new StringWriter();
            XmlTextWriter xtw = new XmlTextWriter(sw);
            xmlDoc.WriteTo(xtw);

            var xmlFile = sw.ToString().DeserializeXml<XmlFileEntity>();
            var csvFile = _mapper.Map(xmlFile);

            return ModelToCsv(csvFile);
        }

        private string ModelToCsv(CsvFileEntity csvFile)
        {
            using var mem = new MemoryStream();
            using var writer = new StreamWriter(mem);
            using var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture);

            csvWriter.WriteField("name");
            csvWriter.WriteField("address_line1");
            csvWriter.WriteField("address_line2");
            csvWriter.NextRecord();
            csvWriter.WriteField(csvFile.Name);
            csvWriter.WriteField(csvFile.AddressLine1);
            csvWriter.WriteField(csvFile.AddressLine2);
            csvWriter.NextRecord();

            writer.Flush();
            return Encoding.UTF8.GetString(mem.ToArray());
        }
    }
}
