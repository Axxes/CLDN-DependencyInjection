using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;

namespace DI.Containers.Autofac
{
    class Program
    {
        public static IContainer Container;

        private static void Main(string[] args)
        {
            var exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Regular DI usage");
                Console.WriteLine("2 - Specific service locator");
                Console.WriteLine("3 - General service locator");
                Console.WriteLine("4 - Lifetime scope");
                Console.WriteLine("5 - Autowiring");
                Console.WriteLine("6 - Module usage");
                Console.WriteLine("7 - One-to-many");
                Console.WriteLine("8 - Post-construction resolve & Property injection");
                Console.WriteLine("9 - With parameters");
                Console.WriteLine("10 - With multiple implementations");
                Console.WriteLine("0 - Exit");
                Console.WriteLine();
                Console.Write("Select demo initialization: ");
                var choice = Console.ReadLine();
                if (choice == "0")
                    exit = true;
                else
                {
                    var orderInfo = new OrderInfo()
                    {
                        CustomerName = "Miguel Castro",
                        Email = "miguelcastro67@gmail.com",
                        Product = "Laptop",
                        Price = 1200,
                        CreditCard = "1234567890"
                    };

                    Console.WriteLine();
                    Console.WriteLine("Order Processing:");
                    Console.WriteLine();

                    var builder = new ContainerBuilder();

                    switch (choice)
                    {
                        case "1":

                            #region regular container usage

                            builder.RegisterType<Commerce1>();
                            builder.RegisterType<BillingProcessor>().As<IBillingProcessor>();
                            builder.RegisterType<CustomerProcessor>().As<ICustomerProcessor>();
                            builder.RegisterType<NotificationProcessor>().As<INotificationProcessor>();
                            builder.RegisterType<LoggingProcessor>().As<ILoggingProcessor>();

                            Container = builder.Build();

                            var commerce1 = Container.Resolve<Commerce1>();

                            commerce1.ProcessOrder(orderInfo);

                            #endregion

                            break;
                        case "2":

                            #region specific service locator (Commerce2)

                            builder.RegisterType<Commerce2>();
                            builder.RegisterType<BillingProcessor>().As<IBillingProcessor>();
                            builder.RegisterType<CustomerProcessor>().As<ICustomerProcessor>();
                            builder.RegisterType<NotificationProcessor>().As<INotificationProcessor>();
                            builder.RegisterType<LoggingProcessor>().As<ILoggingProcessor>();
                            builder.RegisterType<BillingProcessorLocator>().As<IBillingProcessorLocator>();

                            Container = builder.Build();

                            var commerce2 = Container.Resolve<Commerce2>();

                            commerce2.ProcessOrder(orderInfo);

                            #endregion

                            break;
                        case "3":

                            #region general service locator (Commerce3)

                            builder.RegisterType<Commerce3>();
                            builder.RegisterType<BillingProcessor>().As<IBillingProcessor>();
                            builder.RegisterType<CustomerProcessor>().As<ICustomerProcessor>();
                            builder.RegisterType<NotificationProcessor>().As<INotificationProcessor>();
                            builder.RegisterType<LoggingProcessor>().As<ILoggingProcessor>();
                            builder.RegisterType<ProcessorLocator>().As<IProcessorLocator>();

                            Container = builder.Build();

                            var commerce3 = Container.Resolve<Commerce3>();

                            commerce3.ProcessOrder(orderInfo);

                            #endregion

                            break;
                        case "4":

                            #region lifetime scope & singleton (Commerce4)

                            builder.RegisterType<Commerce4>();
                            builder.RegisterType<BillingProcessor>().As<IBillingProcessor>().InstancePerLifetimeScope();
                            builder.RegisterType<CustomerProcessor>().As<ICustomerProcessor>()
                                .InstancePerLifetimeScope();
                            builder.RegisterType<NotificationProcessor>().As<INotificationProcessor>()
                                .InstancePerLifetimeScope();
                            builder.RegisterType<LoggingProcessor>().As<ILoggingProcessor>().InstancePerLifetimeScope();
                            builder.RegisterType<ProcessorLocator2>().As<IProcessorLocator2>();
                            builder.RegisterType<SingleTester>().As<ISingleTester>().SingleInstance();

                            Container = builder.Build();

                            using (var scope = Container.BeginLifetimeScope())
                            {
                                var scopedCommerce = scope.Resolve<Commerce4>();
                                scopedCommerce.ProcessOrder(orderInfo);
                            }

                            // if dependencies were 'Disposable', they would now be disposed and released
                            // without lifetime scope, the container would hold on to disposable components

                            Console.WriteLine("Press 'Enter' to process again...");
                            Console.ReadLine();

                            #endregion

                            break;
                        case "5":

                            #region assembly scanning (Commerce5)

                            builder.RegisterType<Commerce5>();
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Processor"))
                                .As(t => t.GetInterfaces().FirstOrDefault(
                                    i => i.Name == "I" + t.Name));

                            Container = builder.Build();

                            var commerce5 = Container.Resolve<Commerce5>();

                            commerce5.ProcessOrder(orderInfo);

                            #endregion

                            break;
                        case "6":

                            #region module usage (Commerce6)

                            builder.RegisterType<Commerce6>();
                            builder.RegisterModule<ProcessorRegistrationModule>();

                            Container = builder.Build();

                            var commerce6 = Container.Resolve<Commerce6>();

                            commerce6.ProcessOrder(orderInfo);

                            #endregion

                            break;
                        case "7":

                            #region one-to-many (Commerce7)

                            builder.RegisterType<Commerce7>();
                            builder.RegisterType<BillingProcessor>().As<IBillingProcessor>();
                            builder.RegisterType<CustomerProcessor>().As<ICustomerProcessor>();
                            builder.RegisterType<NotificationProcessor>().As<INotificationProcessor>();
                            builder.RegisterType<LoggingProcessor>().As<ILoggingProcessor>();
                            builder.RegisterType<ProcessorLocator>().As<IProcessorLocator>();
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.StartsWith("Plugin"))
                                .As<IPostOrderPlugin>();

                            Container = builder.Build();

                            var commerce7 = Container.Resolve<Commerce7>();

                            commerce7.ProcessOrder(orderInfo);

                            #endregion

                            break;
                        case "8":

                            #region post-construction resolve & property injection (Commerce8)

                            builder.RegisterType<Commerce8>().PropertiesAutowired();
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Processor"))
                                .As(t => t.GetInterfaces().FirstOrDefault(
                                    i => i.Name == "I" + t.Name));
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.StartsWith("Plugin"))
                                .As<IPostOrderPlugin>();
                            builder.RegisterType<ProcessorLocator>().As<IProcessorLocator>();

                            Container = builder.Build();

                            //Commerce8 commerce8 = new Commerce8();
                            var commerce8 = Container.Resolve<Commerce8>();

                            commerce8.ProcessOrder(orderInfo);

                            #endregion

                            break;
                        case "9":

                            #region With simple parameters (Commerce10)

                            builder.RegisterType<Commerce10>();
                            builder.RegisterType<BillingProcessorWithParameter>()
                                .As<IBillingProcessor>()
                                .WithParameter(new TypedParameter(typeof(string), "349185362278235"));

                            Container = builder.Build();
                            var commerce10 = Container.Resolve<Commerce10>();

                            commerce10.ProcessOrder(orderInfo);

                            #endregion

                            break;

                        case "10":

                            #region With multiple implementations (Commerce11)

                            builder.RegisterType<BillingProcessorWithParameter>()
                                .As<IBillingProcessor>()
                                .WithParameter(new TypedParameter(typeof(string), "349185362278235"))
                                .Keyed<IBillingProcessor>("withParameter");

                            builder.RegisterType<BillingProcessor>()
                                .As<IBillingProcessor>()
                                .Keyed<IBillingProcessor>("default");

                            builder.RegisterType<Commerce11>().WithParameter(
                                new ResolvedParameter(
                                    (pi, ctx) => pi.ParameterType == typeof(IBillingProcessor),
                                    (pi, ctx) => ctx.ResolveKeyed<IBillingProcessor>("default")));

                            Container = builder.Build();
                            var commerce11 = Container.Resolve<Commerce11>();

                            commerce11.ProcessOrder(orderInfo);

                            #endregion

                            break;
                    }

                    Container.Dispose();

                    Console.WriteLine();
                    Console.WriteLine("Press 'Enter' for menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}