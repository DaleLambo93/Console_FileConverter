namespace DL.FileConverter.Domain.UseCases.ConvertFile.Converters
{
    public interface IConverter
    {
        string Convert(string filePath);
    }
}
