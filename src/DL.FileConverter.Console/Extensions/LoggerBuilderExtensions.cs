using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DL.FileConverter.Console.Extensions
{
    public static class LoggerBuilderExtensions
    {
        public static void AddLogging(this ILoggingBuilder loggingBuilder,
            IConfiguration configuration)
        {
            loggingBuilder.AddConsole();
            loggingBuilder.AddDebug();

            loggingBuilder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
            loggingBuilder.AddFilter("Microsoft.EntityFrameworkCore.Infastructure", LogLevel.Warning);
        }
    }
}
