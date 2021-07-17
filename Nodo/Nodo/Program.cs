using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Nodo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dentro del Nodo");
            //Console.WriteLine(args.Length);
            Console.WriteLine(args[0]);
            Console.WriteLine(args[2]);
            UDPSocket c = new UDPSocket();
            c.Client("127.0.0.1", Convert.ToInt32(args[1]));
           
           
            c.Send("HOla");

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
