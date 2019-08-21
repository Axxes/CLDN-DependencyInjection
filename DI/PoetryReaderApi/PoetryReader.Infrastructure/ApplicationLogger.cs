using System;
using log4net;

namespace PoetryReader.Infrastructure
{
    public class ApplicationLogger<T> : Core.ILogger
    {
        private static ILog _logger = LogManager.GetLogger(typeof(T));

        public void LogWarning(string message)
        {
            _logger.Warn(message);
        }

        public void LogException(Exception ex)
        {
            _logger.Error("An error occurred", ex);
        }
    }
}
