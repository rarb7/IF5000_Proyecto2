using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            //HuffmanDecoder.Decode(@"D:\UCR\UCR 2021\l Semestre\Redes\pruebaUDP.huff", @"D:\UCR\UCR 2021\l Semestre\Redes\prueba3.txt");
            //UDPSocket s = new UDPSocket();
            //s.Server("127.0.0.1", 27000);

            //string serverIP = "127.0.0.1";
            //int sendPort = 3000;
            //int receivePort = 27000;
            //UDPHandler handler = new UDPHandler(serverIP, receivePort, sendPort);
            //string carpeta1 = @"D:\UCR\UCR 2021\l Semestre\Redes\Nodo\LibrosNodo1";
            //string carpeta2 = @"D:\UCR\UCR 2021\l Semestre\Redes\Nodo\LibrosNodo2";
            // string carpeta3 = @"D:\UCR\UCR 2021\l Semestre\Redes\Nodo\LibrosNodo3";

            Process p = new Process();
            string ruta = "a";
            string puerto = "3001";
            string carpeta = "1";
            p.StartInfo.FileName = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesRemoto3\IF5000_Proyecto2\Nodo\Nodo\bin\Nodo.exe";
            p.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
            p.Start();

            Process p2 = new Process();
            ruta = "a";
            puerto = "3002";
            carpeta = "2";
            p2.StartInfo.FileName = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesRemoto3\IF5000_Proyecto2\Nodo\Nodo\bin\Nodo.exe";
            p2.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
            p2.Start();

            Process p3 = new Process();
            ruta = "a";
            puerto = "3003";
            carpeta = "3";
            p3.StartInfo.FileName = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesRemoto3\IF5000_Proyecto2\Nodo\Nodo\bin\Nodo.exe";
            p3.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
            p3.Start();

            Process p4 = new Process();
            ruta = "a";
            puerto = "3004";
            carpeta = "4";
            p4.StartInfo.FileName = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesRemoto3\IF5000_Proyecto2\Nodo\Nodo\bin\Nodo.exe";
            p4.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
            p4.Start();

            Process p5 = new Process();
            ruta = "a";
            puerto = "3005";
            carpeta = "5";
            p5.StartInfo.FileName = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesRemoto3\IF5000_Proyecto2\Nodo\Nodo\bin\Nodo.exe";
            p5.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
            p5.Start();



            Thread.Sleep(1000);




            //FileStream ifs = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\Pruebatemporal.tmp", FileMode.Open, FileAccess.Read);
            //byte[] sacadoArchivo = new byte[ifs.Length];

            //for (int i = 0; i < ifs.Length; i++)
            //{
            //    int ca = ifs.ReadByte();
            //    sacadoArchivo[i] = Convert.ToByte(ca);
            //}

            //string serverIP = "127.0.0.1";
            //int sendPort = 3000;
            //int receivePort = 27000;
            //UDPHandler handler = new UDPHandler(serverIP, receivePort, sendPort);
            //handler.sendByteUDP(sacadoArchivo,3001);
            //handler.sendByteUDP(sacadoArchivo, 3002);

            // probando lista circular doblemente enlazada

            //Console.ReadKey();
            Raid raid = new Raid();
            raid.enviarPartes();
            


            Console.ReadKey();
           
        }
    }
}
