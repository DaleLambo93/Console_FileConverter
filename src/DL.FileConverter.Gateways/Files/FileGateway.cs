using DL.FileConverter.Domain.Ports;
using DL.FileConverter.Gateways.Services;
using System.IO;

namespace DL.FileConverter.Gateways.Files
{
    public class FileGateway : IFileGateway
    {
        private readonly IDirectoryService _directoryService;

        public FileGateway(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        public string[] GetFiles(string path, string type)
        {
            if (_directoryService.CheckDirectoryExist(path))
            {
                return Directory.GetFiles(path, $"*{type}");               
            }

            return null;
        }

        public string GetFileName(string path) 
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        public void SaveFile(string destinationPath,
            string fileName,
            string content)
        {
            if (_directoryService.CheckDirectoryExist(destinationPath))
            {
                File.WriteAllText($"{destinationPath}{Path.DirectorySeparatorChar}{fileName}", content);
            }            
        }
    }
}
