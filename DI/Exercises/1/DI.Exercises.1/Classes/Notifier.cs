using System;

namespace DI.Exercises._1.Classes
{
    public class Notifier
    {
        public void Email(string email, string name, string message)
        {
            Console.WriteLine($"Mail sent to {email} ({name})");
            Console.WriteLine($"Message: {message}");
        }
    }
}
