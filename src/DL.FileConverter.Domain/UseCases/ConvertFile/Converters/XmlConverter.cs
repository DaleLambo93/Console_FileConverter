using CsvHelper;
using DL.FileConverter.Domain.Entities;
using DL.FileConverter.Domain.Extensions;
using DL.FileConverter.Domain.Mappers;
using DL.FileConverter.Domain.Mappers.Maps;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DL.FileConverter.Domain.UseCases.ConvertFile.Converters
{
    public class XmlConverter : IConverter
    {
        private readonly IMapper<XmlFileEntity, CsvFileEntity> _mapper;

        public XmlConverter(IMapper<XmlFileEntity, CsvFileEntity> mapper)
        {
            _mapper = mapper;
        }

        public string Convert(string filePath)
        {
            string output = null;

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<CsvFileMap>();
                var xmlData = _mapper.Map(csv.GetRecords<CsvFileEntity>().FirstOrDefault());

                output = xmlData.SerializeXml();
            }

            return output;
        }
    }
}
