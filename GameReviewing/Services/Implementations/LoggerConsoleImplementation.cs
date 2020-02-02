using GameReviewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Services.Implementations
{
    public class LoggerConsoleImplementation : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void CookSteak()
        {
            Console.WriteLine("cook steak");
        }
    }
}
