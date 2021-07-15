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
            HuffmanDecoder.Decode(@"D:\saSEARCH\prueba(1).huff", @"D:\ControllerNode\pruebahuff" + ".txt");
            //UDPSocket s = new UDPSocket();
            //s.Server("127.0.0.1", 27000);
            Console.ReadKey();
            //https://gist.github.com/darkguy2008/413a6fea3a5b4e67e5e0d96f750088a9
        }
    }
}
