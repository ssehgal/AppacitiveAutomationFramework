using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppacitiveAutomationFramework
{
    internal class UIControlSet
    {
        private CSVReader _reader;

        public UIControlSet(string controlSetName)
        {
            _reader = new CSVReader(controlSetName + ".csv");
        }

        public string this[string key]
        {
            get
            {
                return _reader[key];
            }
        }

    }
}
