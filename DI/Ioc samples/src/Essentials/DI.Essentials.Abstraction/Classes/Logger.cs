using System;

namespace DI.Essentials.Abstraction.Classes
{
    public class Logger
    {
        public void Log(string message)
        {
            // log message to log file
            Console.WriteLine(string.Format("Log entry @ {0}: {1}", DateTime.Now, message));
            Console.WriteLine();
        }
    }
}
