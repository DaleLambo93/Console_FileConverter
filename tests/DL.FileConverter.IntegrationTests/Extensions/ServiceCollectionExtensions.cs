using DL.FileConverter.Console;
using DL.FileConverter.Console.Configuration;
using DL.FileConverter.Console.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace DL.FileConverter.IntegrationTests.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTestAppServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddHostedService<HostedService>();
            services.AddTransient<App>();
            services.Configure<FileConfiguration>(options => configuration.GetSection("FileInfo").Bind(options));
            services.AddMocks();
        }

        private static void AddMocks(this IServiceCollection services)
        {
            var consoleWriterMock = new Mock<IConsoleWriter>();
            services.AddSingleton(consoleWriterMock);
            services.AddSingleton(consoleWriterMock.Object);
        }
    }
}
