using DI.Exercises._2.Abstractions;
using DI.Exercises.Shared.Models;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace DI.Exercises._2.Implementations
{
    public class FeedbackProcessor : IFeedbackProcessor
    {
        public int QueueCount => throw new NotImplementedException();

        public int ProcessedCount => throw new NotImplementedException();

        public BlockingCollection<Feedback> Queue => throw new NotImplementedException();

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
