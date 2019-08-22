using DI.Exercises.Shared.Models;

namespace DI.Exercises._2.Abstractions
{
    public interface INotifier
    {
        void Notify(Feedback feedbackItem);
    }
}
