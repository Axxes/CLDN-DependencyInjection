using System;
using DI.Essentials.PoorMansContainer.Classes;
using DI.Essentials.PoorMansContainer.DIContainer;
using DI.Essentials.PoorMansContainer.Interfaces;

namespace DI.Essentials.PoorMansContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            container.Register<IBillingProcessor, BillingProcessor>();
            container.Register<ICustomer, Customer>();
            container.Register<INotifier, Notifier>();
            container.Register<ILogger, Logger>();

            Console.WriteLine("Poor-Man's DI Container Example");
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

            var commerce = container.CreateType<ICommerce>();
            commerce.ProcessOrder(orderInfo);

            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();

            //OK now we have dependency inversion, something else pushes our dependencies in the higher modules
            //But this is not the most optimized code, we don't want to reinvent the wheel
        }
    }
}