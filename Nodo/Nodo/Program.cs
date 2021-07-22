using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Nodo
{
    /// <summary>Clase del Nodo</summary>
    class Program
    {
        /// <summary>Cuando se ejecuta se debe pasar por argumentos la carpeta a la que corresponde ,la ruta y el puerto </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {


            Console.WriteLine("Dentro del Nodo");
            string nombreArchivo = args[0];
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
            int sendPort = 27001;
            int receivePort = Convert.ToInt32(args[1]);
           
            UDPHandler handler = new UDPHandler(serverIP, receivePort, sendPort);
            Console.WriteLine("El nombre del archivo es --------------------"+ nombreArchivo);
            handler.readerUdpClient(carpeta,nodo,nombreArchivo);

           
            
        }
    }
}
