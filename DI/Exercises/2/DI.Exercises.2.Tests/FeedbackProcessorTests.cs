using DI.Exercises._2.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Moq;
using DI.Exercises.Shared.Models;
using System.Threading;
using DI.Exercises._2.Implementations;

namespace DI.Exercises._2.Tests
{
    public class FeedbackProcessorTests
    {
        private IServiceCollection _serviceCollection;

        [SetUp]
        public void Setup()
        {
            _serviceCollection = new ServiceCollection();

            // Inject dependencies
            _serviceCollection.AddSingleton <IFeedbackProcessor, FeedbackProcessor>();
        }

        [Test]
        public async Task AssertNotifyCalledThreeTimesPerBatch()
        {
            var mr = new MockRepository(MockBehavior.Strict);

            var notifier = mr.Create<INotifier>();
            notifier.Setup(p => p.Notify(It.IsAny<Feedback>()));
            _serviceCollection.AddTransient(_ => notifier.Object);

            var serviceProvider = _serviceCollection.BuildServiceProvider();

            var processor = serviceProvider.GetService<IFeedbackProcessor>();

            await processor.StartAsync(CancellationToken.None);

            processor.Queue.Add(new Feedback());
            processor.Queue.Add(new Feedback());
            processor.Queue.Add(new Feedback());

            await Task.Delay(500);
            notifier.Verify(p => p.Notify(It.IsAny<Feedback>()), Times.Exactly(3));

            processor.Queue.Add(new Feedback());
            processor.Queue.Add(new Feedback());
            processor.Queue.Add(new Feedback());
            await Task.Delay(500);

            notifier.Verify(p => p.Notify(It.IsAny<Feedback>()), Times.Exactly(6));
        }
    }
}