using DI.Exercises._2.Abstractions;
using DI.Exercises._2.Implementations;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

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
            serviceCollection.AddTransient<IFakeDatabase, FakeDatabase>();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}