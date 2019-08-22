using DI.Exercises._2.Abstractions;
using DI.Exercises._2.Implementations;
using DI.Exercises.Shared.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DI.Exercises._2.Tests
{
    public class Tests
    {
        private IServiceProvider _serviceProvider;

        [SetUp]
        public void Setup()
        {
            var serviceCollection = new ServiceCollection();

            // Inject dependencies
            serviceCollection.AddSingleton<IFeedbackProcessor, FeedbackProcessor>();
            serviceCollection.AddScoped<IFakeDatabase, FakeDatabase>();
            serviceCollection.AddTransient<INotifier, Notifier>();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [Test]
        public async Task Test1()
        {
            Assert.Pass();
        }
    }
}