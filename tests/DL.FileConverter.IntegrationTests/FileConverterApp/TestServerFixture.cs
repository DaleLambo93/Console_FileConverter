using DL.FileConverter.Console.Configuration;
using DL.FileConverter.Domain.UseCases;
using DL.FileConverter.Domain.UseCases.ConvertFile;
using DL.FileConverter.Domain.UseCases.GetFiles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using DL.FileConverter.Console.Helpers;
using Moq;

namespace DL.FileConverter.IntegrationTests.FileConverterApp
{
    public class TestServerFixture
    {
        public IOptions<FileConfiguration> Configuration { get; private set; }
        public IUseCase<GetFilesRequest, GetFilesResponse> GetFilesUseCase { get; private set; }
        public IUseCase<ConvertFileRequest, ConvertFileResponse> ConvertFileUseCase { get; private set; }
        public Mock<IConsoleWriter> MockConsoleWriter { get; private set; }

        private readonly TestServer _testServer;
        public TestServerFixture()
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(@"../../../../../src/DL.FileConverter.Console")
                .UseEnvironment("testing")
                .UseStartup<TestStartup>()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile($"appsettings.testing.json", optional: false);
                });

            _testServer = new TestServer(builder);

            Configuration = _testServer.Host.Services.GetService<IOptions<FileConfiguration>>();
            GetFilesUseCase = _testServer.Host.Services.GetService<IUseCase<GetFilesRequest, GetFilesResponse>>();
            ConvertFileUseCase = _testServer.Host.Services.GetService<IUseCase<ConvertFileRequest, ConvertFileResponse>>();
            MockConsoleWriter = _testServer.Host.Services.GetService<Mock<IConsoleWriter>>();

            CreateDirectories(new string[] { $"{Configuration.Value.InputDirectory}",
                $"{Configuration.Value.OutputDirectory}" });
        }

        private void CreateDirectories(string[] directories)
        {
            foreach (var directory in directories)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }
        }
    }
}
