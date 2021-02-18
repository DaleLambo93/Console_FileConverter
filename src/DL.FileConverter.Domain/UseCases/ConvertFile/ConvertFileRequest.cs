namespace DL.FileConverter.Domain.UseCases.ConvertFile
{
    public class ConvertFileRequest
    {
        public string FilePath { get; set; }
        public string DestinationPath { get; set; }
        public string FileType { get; set; }
    }
}
