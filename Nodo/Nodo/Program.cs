using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Nodo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dentro del Nodo");
            //Console.WriteLine(args.Length);
           // Console.WriteLine(args[0]);
            Console.WriteLine(args[2]);
            string ruta = args[2];
            string carpeta="";
            if (ruta == "1") {
                carpeta = "LibrosNodo1/";
            }
            if (ruta == "2") {
                carpeta = "LibrosNodo2/";
            }
            Console.WriteLine("La ruta de la carpeta es " + carpeta);
            
            string serverIP = "127.0.0.1";
            int sendPort = 27000;
            int receivePort = Convert.ToInt32(args[1]);
           
            UDPHandler handler = new UDPHandler(serverIP, receivePort, sendPort);
            handler.readerUdpClient(carpeta);

            //UDPSocket c = new UDPSocket();
            //c.Client("127.0.0.1", Convert.ToInt32(args[1]));


            //c.Send("HOla");

            //UDPSocket c1 = new UDPSocket();
            //c1.Client("127.0.0.1", 27001);
            //c1.Send("HOla");

            //UDPSocket c2 = new UDPSocket();
            //c2.Client("127.0.0.1", 27002);
            //c2.Send("HOla");

            Console.ReadKey();
        }
    }
}
