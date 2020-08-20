﻿using DI.Core.Classes;
using DI.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DI.Core
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IBillingProcessor, BillingProcessor>()
                .AddTransient<ICustomer, Customer>()
                .AddTransient<INotifier, Notifier>()
                .AddTransient<ILogger, Logger>()
                .AddTransient<Commerce>()
                .BuildServiceProvider();

            Console.WriteLine(".NET Core DI Container Example");
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

            Commerce commerce = serviceProvider.GetService<Commerce>();
            commerce.ProcessOrder(orderInfo);

            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();
        }
    }
}