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
      
        static void Main()
        {
            //HuffmanDecoder.Decode(@"D:\UCR\UCR 2021\l Semestre\Redes\pruebaUDP.huff", @"D:\UCR\UCR 2021\l Semestre\Redes\prueba3.txt");
            //UDPSocket s = new UDPSocket();
            //s.Server("127.0.0.1", 27000);






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
            //Raid raid = new Raid();
            //raid.enviarPartes();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ControllerGUI());

            //Application.Exit();
            Lista listanodos = new Lista();
            string nodoEliminado = "1";
            listanodos.Insertar(1, 3001);
            listanodos.Insertar(2, 3002);
            listanodos.Insertar(3, 3003);
            listanodos.Insertar(4, 3004);
            listanodos.Insertar(5, 3005);

            Raid raid = new Raid(listanodos, nodoEliminado);
            raid.UnirPartes("31342_Mi_lucha");
            //Console.ReadKey();

        }
    }
}
