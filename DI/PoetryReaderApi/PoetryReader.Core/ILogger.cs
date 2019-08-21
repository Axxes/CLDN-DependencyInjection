using System;

namespace PoetryReader.Core
{
    public interface ILogger
    {
        void LogWarning(string message);
        void LogException(Exception ex);
    }
}
