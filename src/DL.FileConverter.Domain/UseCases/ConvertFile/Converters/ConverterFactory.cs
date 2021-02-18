using DL.FileConverter.Domain.Entities;
using DL.FileConverter.Domain.Entities.Constants;
using DL.FileConverter.Domain.Exceptions;
using DL.FileConverter.Domain.Mappers;

namespace DL.FileConverter.Domain.UseCases.ConvertFile.Converters
{
    public class ConverterFactory : IConverterFactory
    {
        private readonly IMapperFactory _mapperFactory;

        public ConverterFactory(IMapperFactory mapperFactory)
        {
            _mapperFactory = mapperFactory;
        }

        public IConverter Get(string type)
        {
            switch (type.ToLower())
            {
                case FileTypes.Csv:
                    return new CsvConverter(_mapperFactory.Get<CsvFileEntity, XmlFileEntity>());
                case FileTypes.Xml:
                    return new XmlConverter(_mapperFactory.Get<XmlFileEntity, CsvFileEntity>());
                default:
                    throw new ConverterNotFoundException("Unable to find converter.");
            }
        }
    }
}
