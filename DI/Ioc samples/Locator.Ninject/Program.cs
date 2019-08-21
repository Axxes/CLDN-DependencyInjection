using Ninject;
using System;

namespace Locator.NInject
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel container = new StandardKernel();
            container.Bind<Commerce>().ToSelf();
            container.Bind<IBillingProcessor>().To<BillingProcessor>();
            container.Bind<ICustomer>().To<Customer>();
            container.Bind<INotifier>().To<Notifier>();
            container.Bind<ILogger>().To<Logger>();
            ServiceLocator.SetServiceLocator(() => new NinjectServiceLocator(container));

            Console.WriteLine("NInject service locator Example");
            Console.WriteLine();

            OrderInfo orderInfo = new OrderInfo()
            {
                CustomerName = "Miguel Castro",
                Email = "miguel@dotnetdude.com",
                Product = "Laptop",
                Price = 1200,
                CreditCard = "1234567890"
            };

            Console.WriteLine("Production:");
            Console.WriteLine();

            Commerce commerce = ServiceLocator.Current.GetInstance<Commerce>();
            commerce.ProcessOrder(orderInfo);

            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();
        }
    }
}
