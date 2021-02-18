using DL.FileConverter.Domain.Ports;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DL.FileConverter.Domain.UseCases.GetFiles
{
    public class GetFilesUseCase : IUseCase<GetFilesRequest, GetFilesResponse>
    {
        private readonly ILogger<GetFilesUseCase> _logger;
        private readonly IFileGateway _gateway;

        public GetFilesUseCase(ILogger<GetFilesUseCase> logger,
            IFileGateway gateway)
        {
            _logger = logger;
            _gateway = gateway;
        }

        public GetFilesResponse Handle(GetFilesRequest request)
        {
            var filePaths = _gateway.GetFiles(request.InputDirectory, request.InputType);
            _logger.LogInformation($"{filePaths.Count()} files have picked up for Converting[{request.InputType}].");

            return new GetFilesResponse()
            {
                FilePaths = filePaths
            };
        }
    }
}
