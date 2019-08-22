using DI.Exercises.Shared.Models;
using Microsoft.Extensions.Hosting;
using System.Collections.Concurrent;

namespace DI.Exercises._2.Abstractions
{
    public interface IFeedbackProcessor : IHostedService
    {
        int QueueCount { get; }
        int ProcessedCount { get; }
        BlockingCollection<Feedback> Queue { get; }
    }
}
