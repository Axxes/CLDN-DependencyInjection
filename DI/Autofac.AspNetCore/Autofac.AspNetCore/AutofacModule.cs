using Autofac.AspNetCore.Services;
using Microsoft.Extensions.Logging;

namespace Autofac.AspNetCore
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
                .As<IValuesService>()
                .InstancePerLifetimeScope();
        }
    }
}
