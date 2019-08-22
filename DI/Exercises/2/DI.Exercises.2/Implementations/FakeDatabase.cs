using DI.Exercises._2.Abstractions;
using DI.Exercises.Shared.Models;
using System.Collections.Generic;

namespace DI.Exercises._2.Implementations
{
    public class FakeDatabase : IFakeDatabase
    {
        private readonly List<Feedback> _feedbacks;

        public FakeDatabase()
        {
            _feedbacks = new List<Feedback>();
        }

        public IEnumerable<Feedback> Feedbacks => _feedbacks;

        public void Save(Feedback feedback)
        {
            _feedbacks.Add(feedback);
        }
    }
}
