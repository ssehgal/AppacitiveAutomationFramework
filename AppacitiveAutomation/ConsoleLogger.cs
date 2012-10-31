using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppacitiveAutomationFramework
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, int priority = 1)
        {
            if (priority != 0)
                Console.WriteLine(message);
        }
    }
}
