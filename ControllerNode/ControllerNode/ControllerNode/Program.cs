using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllerNode
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            HuffmanDecoder.Decode(@"D:\UCR\UCR 2021\l Semestre\Redes\pruebaUDP.huff", @"D:\UCR\UCR 2021\l Semestre\Redes\prueba3.txt");
            //UDPSocket s = new UDPSocket();
            //s.Server("127.0.0.1", 27000);

            //string serverIP = "127.0.0.1";
            //int sendPort = 3000;
            //int receivePort = 27000;
            //UDPHandler handler = new UDPHandler(serverIP, receivePort, sendPort);

            Console.ReadKey();
            //https://gist.github.com/darkguy2008/413a6fea3a5b4e67e5e0d96f750088a9
        }
    }
}
