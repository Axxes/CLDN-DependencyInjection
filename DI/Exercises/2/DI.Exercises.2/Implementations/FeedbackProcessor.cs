using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using DI.Exercises._2.Abstractions;
using System;
using DI.Exercises.Shared.Models;

namespace DI.Exercises._2.Implementations
{
    public class FeedbackProcessor : IFeedbackProcessor
    {
        public FeedbackProcessor()
        {
            Queue = new BlockingCollection<Feedback>();
        }

        public int QueueCount => Queue.Count;

        public int ProcessedCount => throw new NotImplementedException();

        public BlockingCollection<Feedback> Queue { get; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var item1 = Queue.Take(cancellationToken);
            var item2 = Queue.Take(cancellationToken);
            var item3 = Queue.Take(cancellationToken);

            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
