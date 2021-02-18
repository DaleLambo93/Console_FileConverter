using DL.FileConverter.Domain.Extensions;
using DL.FileConverter.Gateways.Extensions;
using DL.FileConverter.IntegrationTests.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DL.FileConverter.IntegrationTests.FileConverterApp
{
    public class TestStartup
    {
        public IConfiguration _configuration { get; }

        public TestStartup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTestAppServices(_configuration);
            services.AddDomainServices(_configuration);
            services.AddGatewayServices(_configuration);
        }
    }
}
