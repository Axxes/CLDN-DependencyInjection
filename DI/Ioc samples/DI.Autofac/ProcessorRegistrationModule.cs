using Autofac;
using System.Linq;
using System.Reflection;

namespace DI
{
    public class ProcessorRegistrationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Processor"))
                .As(t => t.GetInterfaces().FirstOrDefault(
                    i => i.Name == "I" + t.Name));
        }
    }
}
