using DL.FileConverter.Domain.Ports;
using DL.FileConverter.Domain.UseCases.ConvertFile.Converters;
using Microsoft.Extensions.Logging;

namespace DL.FileConverter.Domain.UseCases.ConvertFile
{
    public class ConvertFileUseCase : IUseCase<ConvertFileRequest, ConvertFileResponse>
    {
        private readonly ILogger<ConvertFileUseCase> _logger;
        private readonly IConverterFactory _factory;
        private readonly IFileGateway _gateway;
        public ConvertFileUseCase(ILogger<ConvertFileUseCase> logger, 
            IConverterFactory factory,
            IFileGateway gateway)
        {
            _logger = logger;
            _factory = factory;
            _gateway = gateway;
        }

        public ConvertFileResponse Handle(ConvertFileRequest request)
        {
            var converter = _factory.Get(request.FileType);
            string content = converter.Convert(request.FilePath);
            _logger.LogInformation($"File converted for type {request.FileType}.");

            string fileName = $"{_gateway.GetFileName(request.FilePath)}{request.FileType}";
            _gateway.SaveFile(request.DestinationPath,
                fileName,
                content);
            _logger.LogInformation($"File Saved {fileName}.");

            return new ConvertFileResponse()
            {
                StringContent = content
            };
        }
    }
}
