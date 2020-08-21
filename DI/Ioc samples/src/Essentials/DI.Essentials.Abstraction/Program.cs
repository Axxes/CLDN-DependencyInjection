using System;

namespace DI.Essentials.Abstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("COUPLED Example");
            Console.WriteLine();

            var orderInfo = new OrderInfo()
            {
                CustomerName = "Miguel Castro",
                Email = "miguel@dotnetdude.com",
                Product = "Laptop",
                Price = 1200,
                CreditCard = "1234567890"
            };

            var commerce = new Commerce();

            commerce.ProcessOrder(orderInfo);

            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();

            //It's clear higher modules depend on lower modules
            //No abstractions
        }
    }
}