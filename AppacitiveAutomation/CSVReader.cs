using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AppacitiveAutomationFramework
{
    // naah
    internal class CSVCache
    {
        private Dictionary<string, Dictionary<string, string>> _cache = new Dictionary<string, Dictionary<string, string>>();

        public Dictionary<string, string> Get(string fileName)
        {
            if (_cache.ContainsKey(fileName)) return _cache[fileName];
            return null;
        }

        public void Set(string fileName, Dictionary<string, string> data)
        {
            _cache[fileName] = data;
        }
    }


    internal class CSVReader
    {
        private Dictionary<string, string> _data = new Dictionary<string, string>();

        private CSVCache _cache = new CSVCache();
        
        private CSVReader() { }
        
        public CSVReader(string fileName)
        {
            var csvreader = new CSVReader();
            
            string t = System.Reflection.Assembly.GetExecutingAssembly().Location;
            t = AppDomain.CurrentDomain.BaseDirectory + @"\Controls\";
            string solutionDirectory = System.IO.Path.GetDirectoryName(t);
            // var basePath = solutionDirectory + @"\..\..\Controls\";
            var basePath = System.IO.Path.GetFullPath("..//..//..//Controls//");
            if (!Directory.Exists(basePath))
                throw new Exception("Failed to find directory: " + basePath + "!");

            if (!File.Exists(basePath + fileName))
                throw new Exception("Failed to find file: " + basePath + fileName + "!");

            var reader = new StreamReader(File.OpenRead(basePath + fileName));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                _data.Add(values[0].Trim(), values[1].Trim());
            }
        }

        /// <summary>
        /// Pass the name of the control in the .csv file. Returns the value if key is 
        /// found, else an exception is thrown.
        /// </summary>
        /// <param name="controlName">The name of the control</param>
        /// <returns>The value from .csv file.</returns>
        public string this[string controlName]
        {
            get
            {
                if (_data.ContainsKey(controlName)) 
                    return _data[controlName]; 
                else 
                    throw new Exception("Could not find key: " + controlName);
            }
        }
    }
}
