using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using DI.Core;

namespace DI.Containers.StructureMap
{
    internal static class Program
    {
        static void Main()
        {
            var serviceProvider = new ServiceCollection();

            var container = new Container();
            container.Configure(config =>
            {
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Commerce));
                    _.WithDefaultConventions();
                });

                config.Populate(serviceProvider);
            });

            Console.WriteLine(".NET Core DI Container with StructureMap Example");
            Console.WriteLine();

            var orderInfo = new OrderInfo()
            {
                CustomerName = "Miguel Castro",
                Email = "miguel@dotnetdude.com",
                Product = "Laptop",
                Price = 1200,
                CreditCard = "1234567890"
            };

            Console.WriteLine("Production:");
            Console.WriteLine();

            var commerce = container.GetInstance<Commerce>();
            commerce.ProcessOrder(orderInfo);

            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();
        }
    }
}