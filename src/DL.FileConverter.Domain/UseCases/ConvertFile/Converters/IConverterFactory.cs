namespace DL.FileConverter.Domain.UseCases.ConvertFile.Converters
{
    public interface IConverterFactory
    {
        IConverter Get(string type);
    }
}
