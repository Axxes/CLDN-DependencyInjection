using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Service locator Example");
            Console.WriteLine();


            ServiceLocator.SetInstance<IBillingProcessor>(new BillingProcessor());
            ServiceLocator.SetInstance<ICustomer>(new Customer());
            ServiceLocator.SetInstance<INotifier>(new Notifier());
            ServiceLocator.SetInstance<ILogger>(new Logger());

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

            Commerce commerce = new Commerce(ServiceLocator.GetInstance<IBillingProcessor>(), ServiceLocator.GetInstance<ICustomer>(), ServiceLocator.GetInstance<INotifier>(), ServiceLocator.GetInstance<ILogger>());
            commerce.ProcessOrder(orderInfo);

            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();
        }
    }
}
