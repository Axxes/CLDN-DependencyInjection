using PoetryReader.Core;
using StructureMap;

namespace PoetryReader.Infrastructure
{
    public class InfrastructureRegistry : Registry
    {
        public InfrastructureRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.AssemblyContainingType<IPoetryRepository>(); // Core
                    scan.WithDefaultConventions();
                });

            //Because we didn't follow the convention we have to do the following
            For<IPoetryRepository>().Use<InMemoryPoetryRepository>();
            For<ILogger>().Use<ApplicationLogger<IPoetryRepository>>();

        }
    }
}
