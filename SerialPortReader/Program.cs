using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortReader
{
    class Program
    {
        public static void Main()
        {
            try
            {
                var config = new Configuration();
                var logger = new Logger(config);

                SerialPort mySerialPort = new SerialPort(config.ComPort);

                mySerialPort.BaudRate = 9600;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;
                mySerialPort.RtsEnable = true;

                //mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                mySerialPort.ReadTimeout = config.TimeOut;
                mySerialPort.WriteTimeout = config.TimeOut;
                mySerialPort.Open();
                mySerialPort.WriteLine("WT");

                var str = mySerialPort.ReadLine();
                logger.WriteLine($"data received: {str}");
                Console.WriteLine("Press any key to continue...");
                Console.WriteLine(str);
                Console.ReadKey();
                mySerialPort.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error! " + ex.Message);
                Console.ReadKey();
            }
        }
        private static void DataReceivedHandler(
                            object sender,
                            SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadLine();
            Console.WriteLine("Data Received:");
            Console.Write(indata);
        }
    }
}
