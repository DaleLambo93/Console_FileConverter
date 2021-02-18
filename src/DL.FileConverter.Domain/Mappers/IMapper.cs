namespace DL.FileConverter.Domain.Mappers
{
    public interface IMapper<out TOut, in TIn>
    {
        TOut Map(TIn item);
    }
}
