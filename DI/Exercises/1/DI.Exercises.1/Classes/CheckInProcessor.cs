using DI.Exercises.Shared.Models;

namespace DI.Exercises._1.Classes
{
    public class CheckInProcessor
    {
        private readonly Notifier _notifier;

        public CheckInProcessor()
        {
            _notifier = new Notifier();
        }

        public void ProcessCheckIn(CheckIn checkIn)
        {
            var message = $"Check in done for {checkIn.Trimester} / {checkIn.Year} : {checkIn.Description}";

            _notifier.Email(checkIn.Consultant.Email, checkIn.Consultant.Name, message);
        }
    }
}
