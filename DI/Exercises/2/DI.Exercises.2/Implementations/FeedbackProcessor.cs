using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using DI.Exercises._2.Abstractions;
using System;
using DI.Exercises.Shared.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Exercises._2.Implementations
{
    public class FeedbackProcessor : IFeedbackProcessor
    {
        private readonly IServiceProvider _serviceProvider;

        public FeedbackProcessor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            Queue = new BlockingCollection<Feedback>();
        }

        public int QueueCount => Queue.Count;

        public int ProcessedCount => throw new NotImplementedException();

        public BlockingCollection<Feedback> Queue { get; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() => Run(cancellationToken));

            return Task.CompletedTask;
        }

        public void Run(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {

                var items = new Feedback[] {
                    Queue.Take(cancellationToken),
                    Queue.Take(cancellationToken),
                    Queue.Take(cancellationToken)
                };

                //throw new NotImplementedException();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
