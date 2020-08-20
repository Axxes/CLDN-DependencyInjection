using Autofac;
using DI.Containers.Autofac;

namespace DI
{
    public class ProcessorLocator : IProcessorLocator
    {
        T IProcessorLocator.GetProcessor<T>()
        {
            return Program.Container.Resolve<T>();
        }
    }
}