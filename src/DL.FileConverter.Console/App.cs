using DL.FileConverter.Console.Configuration;
using DL.FileConverter.Console.Helpers;
using DL.FileConverter.Domain.UseCases;
using DL.FileConverter.Domain.UseCases.ConvertFile;
using DL.FileConverter.Domain.UseCases.GetFiles;
using Microsoft.Extensions.Options;
using System.Linq;


namespace DL.FileConverter.Console
{
    public class App
    {
        private readonly FileConfiguration _configuration;
        private readonly IUseCase<GetFilesRequest, GetFilesResponse> _getFilesUseCase;
        private readonly IUseCase<ConvertFileRequest, ConvertFileResponse> _convertFileUseCase;
        private readonly IConsoleWriter _consoleWriter;

        public App(IOptions<FileConfiguration> configuration,
            IUseCase<GetFilesRequest, GetFilesResponse> getFilesUseCase,
            IUseCase<ConvertFileRequest, ConvertFileResponse> convertFileUseCase,
            IConsoleWriter consoleWriter)
        {
            _configuration = configuration.Value;
            _getFilesUseCase = getFilesUseCase;
            _convertFileUseCase = convertFileUseCase;
            _consoleWriter = consoleWriter;
        }

        public void Run()
        {
            var getFilesResponse = _getFilesUseCase.Handle(new GetFilesRequest() 
            {
                InputDirectory = _configuration.InputDirectory,
                InputType = _configuration.InputFileExtension    
            });

            if (getFilesResponse.FilePaths.Any())
            {
                foreach(var filePath in getFilesResponse.FilePaths)
                {            
                    var convertFileResponse = _convertFileUseCase.Handle(new ConvertFileRequest()
                    {
                        FilePath = filePath,
                        FileType = _configuration.OutputFileExtension,
                        DestinationPath = _configuration.OutputDirectory
                    });
                    _consoleWriter.WriteLine(convertFileResponse.StringContent);
                }
            }
        }
    }
}
