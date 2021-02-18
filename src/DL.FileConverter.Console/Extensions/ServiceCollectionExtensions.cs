using DL.FileConverter.Console.Configuration;
using DL.FileConverter.Console.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DL.FileConverter.Console.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddHostedService<HostedService>();
            services.AddTransient<App>();
            services.AddConfigurations(configuration);
            services.AddTransient<IConsoleWriter, ConsoleWriter>();
        }

        private static void AddConfigurations(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<FileConfiguration>(options => configuration.GetSection("FileInfo").Bind(options));
        }
    }
}
