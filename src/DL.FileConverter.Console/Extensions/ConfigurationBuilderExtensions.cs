using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DL.FileConverter.Console.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        public static void AddAppSettings(this IConfigurationBuilder configurationBuilder,
            IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                configurationBuilder.AddJsonFile($"appsettings.{env.EnvironmentName.ToLower()}.json", optional: false);
            }
            else
            {
                configurationBuilder.AddJsonFile($"appsettings.json", optional: false);
            }
        }
    }
}
