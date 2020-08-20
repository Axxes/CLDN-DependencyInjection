using DI.ServiceLocators.Core.Services;
using DI.ServiceLocators.Core.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DI.ServiceLocators.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IBarService, BarService>()
                .AddTransient<IFooService, FooService>()
                .BuildServiceProvider();

            var foo = serviceProvider.GetRequiredService<IFooService>();
            foo.Log("        Print me          ");
        }
    }
}