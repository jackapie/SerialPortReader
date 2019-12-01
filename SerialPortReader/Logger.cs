using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortReader
{
    class Logger
    {
        public Logger(Configuration config)
        {
            fullLogging = config.FullLogging;
            filename = "logfile-" + DateTime.Now.Ticks.ToString() + ".txt";
        }

        bool fullLogging;
        string filename;

        public void WriteLine(string line)
        {
            if (fullLogging)
            {
                File.AppendAllText(filename, line + "\r\n");
            }
        }
    }
}
