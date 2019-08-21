using Autofac;

namespace DI
{
    public class ProcessorLocator2 : IProcessorLocator2
    {
        public ProcessorLocator2()
        {
            ((IProcessorLocator2)this).CreateScope();
        }

        private ILifetimeScope _Scope = null;
        void IProcessorLocator2.CreateScope()
        {
            _Scope = Program.Container.BeginLifetimeScope();
        }

        T IProcessorLocator2.GetProcessor<T>()
        {
            return _Scope.Resolve<T>();
        }

        void IProcessorLocator2.ReleaseScope()
        {
            _Scope.Dispose();
        }
    }
}
