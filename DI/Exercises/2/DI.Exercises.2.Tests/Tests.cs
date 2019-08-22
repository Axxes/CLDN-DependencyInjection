using DI.Exercises._2.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Moq;
using DI.Exercises.Shared.Models;
using System.Threading;

namespace DI.Exercises._2.Tests
{
    public class Tests
    {
        private IServiceCollection _serviceCollection;
        private IServiceProvider _serviceProvider;

        [SetUp]
        public void Setup()
        {
            _serviceCollection = new ServiceCollection();

            // Inject dependencies
            // serviceCollection.AddSingleton<IFeedbackProcessor, ?>();
            // serviceCollection.AddScoped<IFakeDatabase, ?>();
            // serviceCollection.AddTransient<INotifier, ?>();

            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        [Test]
        public async Task Test1()
        {
            var processor = _serviceProvider.GetService<IFeedbackProcessor>();

            var mr = new MockRepository(MockBehavior.Strict);

            var database = mr.Create<IFakeDatabase>();
            database.Setup(p => p.Save(It.IsAny<Feedback>()));
            _serviceCollection.AddScoped(_ => database.Object);

            var notifier = mr.Create<INotifier>();
            notifier.Setup(p => p.Notify(It.IsAny<Feedback>()));
            _serviceCollection.AddTransient(_ => notifier.Object);

            await processor.StartAsync(CancellationToken.None);

            database.Verify(p => p.Save(It.IsAny<Feedback>()), Times.Exactly(3));
            Assert.Pass();
        }
    }
}