using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortReader
{
    class Configuration
    {
        public Configuration()
        {
            TimeOut = int.Parse(ConfigurationManager.AppSettings["timeOut"]);
            ComPort = "COM11";
            FullLogging = ConfigurationManager.AppSettings["fullLogging"] == "yes";
        }

        public string ComPort { get; set; }
        public int TimeOut { get; set; }
        public bool FullLogging { get; set; }
    }
}
