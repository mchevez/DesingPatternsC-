using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesingPattern.Singleton
{
    public class Log
    {
        private static readonly Log _instance = new Log();
        private Log() { }
        public static Log Instance {  get => _instance; }

        private string _path = "log.txt";
        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
