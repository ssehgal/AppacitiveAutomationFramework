﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppacitiveAutomationFramework
{
    public interface ILogger
    {
        void Log(string message, int priority = 0);
    }
}
