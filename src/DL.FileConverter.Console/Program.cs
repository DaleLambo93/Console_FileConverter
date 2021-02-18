using DL.FileConverter.Console.Extensions;
using DL.FileConverter.Domain.Extensions;
using DL.FileConverter.Gateways.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace DL.FileConverter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    configHost.AddEnvironmentVariables();
                })
                .ConfigureAppConfiguration((hostContext, appConfig) =>
                {
                    appConfig.AddAppSettings(hostContext.HostingEnvironment);
                    appConfig.AddEnvironmentVariables();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddAppServices(hostContext.Configuration);
                    services.AddDomainServices(hostContext.Configuration);
                    services.AddGatewayServices(hostContext.Configuration);
                })
                .ConfigureLogging((hostContext, loggingConfig) =>
                {
                    loggingConfig.AddLogging(hostContext.Configuration);
                })
                .UseConsoleLifetime()
                .Build();

            host.Run();
        }
    }
}
