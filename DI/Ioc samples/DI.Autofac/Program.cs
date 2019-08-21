using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core.Activators.Reflection;
using Autofac.Core;

namespace DI
{
    class Program
    {
        public static IContainer Container;

        static void Main(string[] args)
        {
            bool exit = false;
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
                Console.WriteLine("9 - Constructor finder");
                Console.WriteLine("10 - With parameters");
                Console.WriteLine("11 - With multiple implementations");
                Console.WriteLine("0 - Exit");
                Console.WriteLine();
                Console.Write("Select demo initialization: ");
                string choice = Console.ReadLine();
                if (choice == "0")
                    exit = true;
                else
                {
                    OrderInfo orderInfo = new OrderInfo()
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

                    ContainerBuilder builder = new ContainerBuilder();

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

                            Commerce1 commerce1 = Container.Resolve<Commerce1>();

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

                            Commerce2 commerce2 = Container.Resolve<Commerce2>();

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

                            Commerce3 commerce3 = Container.Resolve<Commerce3>();

                            commerce3.ProcessOrder(orderInfo);
                            #endregion

                            break;
                        case "4":
                            #region lifetime scope & singleton (Commerce4)
                            builder.RegisterType<Commerce4>();
                            builder.RegisterType<BillingProcessor>().As<IBillingProcessor>().InstancePerLifetimeScope();
                            builder.RegisterType<CustomerProcessor>().As<ICustomerProcessor>().InstancePerLifetimeScope();
                            builder.RegisterType<NotificationProcessor>().As<INotificationProcessor>().InstancePerLifetimeScope();
                            builder.RegisterType<LoggingProcessor>().As<ILoggingProcessor>().InstancePerLifetimeScope();
                            builder.RegisterType<ProcessorLocator2>().As<IProcessorLocator2>();
                            builder.RegisterType<SingleTester>().As<ISingleTester>().SingleInstance();

                            Container = builder.Build();

                            using (ILifetimeScope scope = Container.BeginLifetimeScope())
                            {
                                Commerce4 scopedCommerce = scope.Resolve<Commerce4>();
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

                            Commerce5 commerce5 = Container.Resolve<Commerce5>();

                            commerce5.ProcessOrder(orderInfo);
                            #endregion

                            break;
                        case "6":
                            #region module usage (Commerce6)
                            builder.RegisterType<Commerce6>();
                            builder.RegisterModule<ProcessorRegistrationModule>();

                            Container = builder.Build();

                            Commerce6 commerce6 = Container.Resolve<Commerce6>();

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

                            Commerce7 commerce7 = Container.Resolve<Commerce7>();

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
                            Commerce8 commerce8 = Container.Resolve<Commerce8>();

                            commerce8.ProcessOrder(orderInfo);
                            #endregion

                            break;
                        case "9":
                            #region constructor finder (Commerce9)
                            builder.RegisterType<Commerce9>().WithParameters(new List<Autofac.Core.Parameter>() {
                            new NamedParameter("a", 1),
                            new NamedParameter("b", 1),
                            new NamedParameter("c", 1),
                            new NamedParameter("d", 1) });
                            #region fix
                            builder.RegisterType<Commerce9>().WithParameters(new List<Autofac.Core.Parameter>() {
                                new NamedParameter("a", 1),
                                new NamedParameter("b", 1),
                                new NamedParameter("c", 1),
                                new NamedParameter("d", 1) }).FindConstructorsWith(new AwesomeConstructorFinder());
                            #endregion
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Processor"))
                                .As(t => t.GetInterfaces().FirstOrDefault(
                                    i => i.Name == "I" + t.Name));
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.StartsWith("Plugin"))
                                .As<IPostOrderPlugin>();
                            builder.RegisterType<ProcessorLocator>().As<IProcessorLocator>();

                            Container = builder.Build();

                            Commerce9 commerce9 = Container.Resolve<Commerce9>();

                            commerce9.ProcessOrder(orderInfo);
                            #endregion

                            break;
                        case "10":
                            #region With simple parameters (Commerce10)
                            builder.RegisterType<Commerce10>();
                            builder.RegisterType<BillingProcessorWithParameter>()
                           .As<IBillingProcessor>()
                           .WithParameter(new TypedParameter(typeof(string), "349185362278235"));

                            Container = builder.Build();
                            Commerce10 commerce10 = Container.Resolve<Commerce10>();

                            commerce10.ProcessOrder(orderInfo);
                            #endregion
                            break;

                        case "11":
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
                            Commerce11 commerce11 = Container.Resolve<Commerce11>();

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
