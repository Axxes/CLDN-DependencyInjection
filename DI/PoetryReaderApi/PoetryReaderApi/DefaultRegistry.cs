using PoetryReader.Core;
using StructureMap;

namespace PoetryReader.Api
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(
                scan => {
                    //scan.TheCallingAssembly();
                    scan.AssemblyContainingType<IPoetryRepository>(); // Core
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.WithDefaultConventions();
                    scan.LookForRegistries(); // find and run other registries
                });
        }
    }
}
