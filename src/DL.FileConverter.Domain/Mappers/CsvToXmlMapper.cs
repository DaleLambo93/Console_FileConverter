using DL.FileConverter.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DL.FileConverter.Domain.Mappers
{
    public class CsvToXmlMapper : Mapper<XmlFileEntity, CsvFileEntity>
    {
        public CsvToXmlMapper(ILogger<Mapper<XmlFileEntity, CsvFileEntity>> logger) : base(logger)
        {
        }

        public override XmlFileEntity Map(CsvFileEntity item)
        {
            if (!Validate(item))
            {
                return null;
            }

            return new XmlFileEntity()
            {
                Name = item.Name,
                Address = new AddressEntity
                {
                    AddressLine1 = item.AddressLine1,
                    AddressLine2 = item.AddressLine2
                }
            };
        }
    }
}
