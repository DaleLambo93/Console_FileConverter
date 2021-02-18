using DL.FileConverter.Domain.Ports;
using DL.FileConverter.Gateways.Files;
using DL.FileConverter.Gateways.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DL.FileConverter.Gateways.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGatewayServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddPortServices();
            services.AddServices();
        }

        private static void AddPortServices(this IServiceCollection services)
        {
            services.AddTransient<IFileGateway, FileGateway>();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDirectoryService, DirectoryService>();
        }
    }
}
