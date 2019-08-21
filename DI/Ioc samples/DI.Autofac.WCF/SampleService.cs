using System;
using System.Collections.Generic;
using System.Linq;

namespace DI.WCF
{
    public class SampleService : ISampleService
    {
        IDependency _Dependency;

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
