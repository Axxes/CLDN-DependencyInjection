using DI.Exercises.Shared.Models;
using System.Collections.Generic;

namespace DI.Exercises._2.Abstractions
{
    public interface IFakeDatabase
    {
        IEnumerable<Feedback> Feedbacks { get; }
        void Save(Feedback feedback);
    }
}
