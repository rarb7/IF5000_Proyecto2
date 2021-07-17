using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            string serverIP = "127.0.0.1";
            int sendPort = 3000;
            int receivePort = 27000;
            UDPHandler handler = new UDPHandler(serverIP, receivePort, sendPort);

            string carpeta1 = @"D:\proyecto2redes\IF5000_Proyecto2\Nodo\LibrosNodo1";
            string carpeta2 = @"D:\proyecto2redes\IF5000_Proyecto2\Nodo\LibrosNodo2";
            string carpeta3 = @"D:\proyecto2redes\IF5000_Proyecto2\Nodo\LibrosNodo3";
            //  HuffmanDecoder.Decode(@"D:\saSEARCH\prueba(1).huff", @"D:\ControllerNode\pruebahuff" + ".txt");
            UDPSocket s = new UDPSocket();
            s.Server("127.0.0.1", 27000);
            Process p = new Process();
            string ruta = "a";
            string puerto = "27000";
            string carpeta = carpeta1;
            p.StartInfo.FileName = @"D:\proyecto2redes\IF5000_Proyecto2\Nodo\Nodo\bin\Nodo.exe";
            p.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";

            p.Start();

            Process p2 = new Process();
            ruta = "a";
            puerto = "27000";
            carpeta = carpeta2;
            p2.StartInfo.FileName = @"D:\proyecto2redes\IF5000_Proyecto2\Nodo\Nodo\bin\Nodo.exe";
            p2.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";


            p2.Start();
            Console.ReadKey();
            //https://gist.github.com/darkguy2008/413a6fea3a5b4e67e5e0d96f750088a9
        }
    }
}
