namespace DL.FileConverter.Domain.Ports
{
    public interface IFileGateway
    {
        string[] GetFiles(string path, string type);
        string GetFileName(string path);
        void SaveFile(string destinationPath, string fileName, string content);

    }
}
