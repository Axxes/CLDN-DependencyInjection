using System;
using DI.Essentials.Abstraction.Classes;

namespace DI.Essentials.Abstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ABSTRACTION Example");
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
            var commerce = new Commerce(new BillingProcessor(),
                new Customer(),
                new Notifier(),
                new Logger());
            commerce.ProcessOrder(orderInfo);

            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();
        }
    }
}