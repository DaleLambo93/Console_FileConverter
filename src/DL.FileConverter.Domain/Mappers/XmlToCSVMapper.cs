using DL.FileConverter.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DL.FileConverter.Domain.Mappers
{
    public class XmlToCsvMapper : Mapper<CsvFileEntity, XmlFileEntity>
    {
        public XmlToCsvMapper(ILogger<Mapper<CsvFileEntity, XmlFileEntity>> logger) : base(logger)
        {
        }

        public override CsvFileEntity Map(XmlFileEntity item)
        {
            if (!Validate(item))
            {
                return null;
            }

            return new CsvFileEntity()
            {
                Name = item.Name,
                AddressLine1 = item.Address.AddressLine1,
                AddressLine2 = item.Address.AddressLine2
            };
        }
    }
}
