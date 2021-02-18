namespace DL.FileConverter.Domain.UseCases
{
    public interface IUseCase<TIn, TOut>
    {
        TOut Handle(TIn request);
    }
}
