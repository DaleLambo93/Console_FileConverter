using DL.FileConverter.Domain.Entities;
using DL.FileConverter.Domain.Mappers;
using DL.FileConverter.Domain.UseCases;
using DL.FileConverter.Domain.UseCases.ConvertFile;
using DL.FileConverter.Domain.UseCases.ConvertFile.Converters;
using DL.FileConverter.Domain.UseCases.GetFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DL.FileConverter.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDomainServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddUseCases();
            services.AddFactories();
            services.AddMappers();
        }

        private static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IUseCase<GetFilesRequest, GetFilesResponse>, GetFilesUseCase>();
            services.AddTransient<IUseCase<ConvertFileRequest, ConvertFileResponse>, ConvertFileUseCase>();
        }

        private static void AddFactories(this IServiceCollection services)
        {
            services.AddTransient<IMapperFactory, MapperFactory>();
            services.AddTransient<IConverterFactory, ConverterFactory>();
        }

        private static void AddMappers(this IServiceCollection services)
        {            
            services.AddTransient<IMapper<CsvFileEntity, XmlFileEntity>, XmlToCsvMapper>();
            services.AddTransient<IMapper<XmlFileEntity, CsvFileEntity>, CsvToXmlMapper>();
        }
    }
}
