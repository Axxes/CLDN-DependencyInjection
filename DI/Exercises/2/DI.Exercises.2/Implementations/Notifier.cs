using DI.Exercises._2.Abstractions;
using DI.Exercises.Shared.Models;
using System;

namespace DI.Exercises._2.Implementations
{
    public class Notifier : INotifier
    {
        private readonly IFakeDatabase _fakeDatabase;

        public void Notify(Feedback feedbackItem)
        {
            _fakeDatabase.Save(feedbackItem);
            Console.WriteLine($"[NOTIFIER {GetHashCode()}]: Saved item {feedbackItem.Id} using {_fakeDatabase.GetHashCode()}");
        }
    }
}
