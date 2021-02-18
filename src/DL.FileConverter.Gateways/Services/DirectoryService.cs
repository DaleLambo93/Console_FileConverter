using System.IO;

namespace DL.FileConverter.Gateways.Services
{
    public class DirectoryService : IDirectoryService
    {
        public bool CheckDirectoryExist(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                return true;
            }

            return false;
        }
    }
}
