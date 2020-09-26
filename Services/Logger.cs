using System;

namespace StateMachineDemo.Services
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"LOG: {message}");
        }
    }
}
