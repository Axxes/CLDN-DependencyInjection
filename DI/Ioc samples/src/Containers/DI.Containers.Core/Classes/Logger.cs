using DI.Core.Interfaces;
using System;

namespace DI.Core.Classes
{
    public class Logger : ILogger
    {
        void ILogger.Log(string message)
        {
            // log message to log file
            Console.WriteLine(string.Format("Log entry @ {0}: {1}", DateTime.Now, message));
            Console.WriteLine();
        }
    }
}