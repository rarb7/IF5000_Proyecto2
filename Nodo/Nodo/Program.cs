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
            Console.WriteLine(ruta);
            int nodo = 0;
            string carpeta="";
            if (ruta == "1") {
                carpeta = "LibrosNodo1/";
                nodo = 1;
            }
            if (ruta == "2") {
                carpeta = "LibrosNodo2/";
                nodo = 2;
            }
            if (ruta == "3")
            {
                carpeta = "LibrosNodo3/";
                nodo = 3;
            }
            if (ruta == "4")
            {
                carpeta = "LibrosNodo4/";
                nodo = 4;
            }
            if (ruta == "5")
            {
                carpeta = "LibrosNodo5/";
                nodo = 5;
            }
            Console.WriteLine("La ruta de la carpeta es " + carpeta);
            
            string serverIP = "127.0.0.1";
            int sendPort = 27000;
            int receivePort = Convert.ToInt32(args[1]);
           
            UDPHandler handler = new UDPHandler(serverIP, receivePort, sendPort);
            handler.readerUdpClient(carpeta,nodo);


            //UDPSocket c = new UDPSocket();
            //c.Client("127.0.0.1", Convert.ToInt32(args[1]));


            //c.Send("HOla");

            //UDPSocket c1 = new UDPSocket();
            //c1.Client("127.0.0.1", 27001);
            //c1.Send("HOla");

            //UDPSocket c2 = new UDPSocket();
            //c2.Client("127.0.0.1", 27002);
            //c2.Send("HOla");
           
            
        }
    }
}
