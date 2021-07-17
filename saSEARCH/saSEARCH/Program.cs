using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace saSEARCH
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //HuffmanEncoder.Encode(@"D:\UCR\UCR 2021\l Semestre\Redes\Proyecto2_redes\prueba.txt",
            //@"D:\UCR\UCR 2021\l Semestre\Redes\Proyecto2_redes\prueba" + ".huff");
            // HuffmanDecoder.Decode(@"D:\UCR\UCR 2021\l Semestre\Redes\pruebaUDP.huff", @"D:\UCR\UCR 2021\l Semestre\Redes\pruebaUDP.txt");

            FileStream ifs = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\Proyecto2_redes\prueba.huff", FileMode.Open, FileAccess.Read);
            byte[] sacadoArchivo = new byte[ifs.Length];

            for (int i = 0; i < ifs.Length; i++)
            {
                int ca = ifs.ReadByte();
                sacadoArchivo[i] = Convert.ToByte(ca);
            }
            string serverIP = "127.0.0.1";
            int sendPort = 27000;
            int receivePort = 3000;
            UDPHandler handler = new UDPHandler(serverIP, receivePort, sendPort);
            handler.sendByteUDP(sacadoArchivo);


            Console.ReadKey();
        }
    }
}
