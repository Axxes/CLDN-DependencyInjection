namespace DI
{
    public interface IProcessorLocator
    {
        T GetProcessor<T>();
    }
}