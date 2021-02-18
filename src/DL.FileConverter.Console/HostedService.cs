using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DL.FileConverter.Console
{
    public class HostedService : BackgroundService
    {
        private readonly ILogger<HostedService> _logger;
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly App _app;

        public HostedService(App app,
            ILogger<HostedService> logger,
            IHostApplicationLifetime applicationLifetime)
        {
            _app = app;
            _logger = logger;
            _applicationLifetime = applicationLifetime;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Background Service is starting.");
            _applicationLifetime.ApplicationStarted.Register(OnStarted);
            _applicationLifetime.ApplicationStopping.Register(OnStopping);
            _applicationLifetime.ApplicationStopped.Register(OnStopped);

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            try
            {
                _logger.LogInformation($"Application has started.");
                _app.Run();
            }
            catch (Exception ex)
            {
                var message = $"Exception Message: {ex.Message}. " +
                    $"InnerException Message: {ex.InnerException?.Message ?? string.Empty}. " +
                    $"StackTrace: {ex.StackTrace}.";

                _logger.LogDebug(message, ex);
            }
            finally
            {
                _applicationLifetime.StopApplication();
            }
        }

        private void OnStopping()
        {
            _logger.LogInformation("Application Stopping.");
        }

        private void OnStopped()
        {
            _logger.LogInformation("Application Stopped.");
        }
    }
}
