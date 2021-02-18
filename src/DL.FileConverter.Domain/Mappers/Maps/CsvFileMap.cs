using CsvHelper.Configuration;
using DL.FileConverter.Domain.Entities;
using System.Globalization;

namespace DL.FileConverter.Domain.Mappers.Maps
{
    public sealed class CsvFileMap : ClassMap<CsvFileEntity>
    {
        public CsvFileMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Name).Name("name");
            Map(m => m.AddressLine1).Name("address_line1");
            Map(m => m.AddressLine2).Name("address_line2");
        }
    }
}
