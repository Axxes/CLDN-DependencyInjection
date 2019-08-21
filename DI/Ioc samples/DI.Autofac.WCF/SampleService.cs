namespace DI.WCF
{
    public class SampleService : ISampleService
    {
        private readonly IDependency _Dependency;

        public SampleService(IDependency dependency)
        {
            _Dependency = dependency;
        }

        public void PerformOperation()
        {
            _Dependency.ShowToConsole();
        }
    }
}
