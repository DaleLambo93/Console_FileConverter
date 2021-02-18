namespace DL.FileConverter.Domain.Mappers
{
    public interface IMapperFactory
    {
        IMapper<TOut, TIn> Get<TOut, TIn>();
    }
}
