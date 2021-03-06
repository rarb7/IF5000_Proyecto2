using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nodo
{
    /// <summary>Clase que se comunica mediante el protocolo UDP</summary>
    class UDPHandler
    {
        private int receivePort, sendPort;
        private string serverIP;
        private IPEndPoint sendEndPoint, receiveEndPoint;

        public UDPHandler(string serverIP, int receivePort, int sendPort)
        {
            this.serverIP = serverIP;
            this.receivePort = receivePort;
            this.sendPort = sendPort;
            this.sendEndPoint = new IPEndPoint(IPAddress.Parse(this.serverIP), this.sendPort);
            this.receiveEndPoint = new IPEndPoint(IPAddress.Parse(this.serverIP), this.receivePort);
          
        }

        /// <summary>Se crea un hilo el cual guarda la parte del archivo en su carpeta correspondiente.</summary>
        /// <param name="ruta">The ruta.</param>
        /// <param name="nodo">The nodo.</param>
        /// <param name="nombreArchivo">The nombre archivo.</param>
        public void readerUdpClient(string ruta,int nodo,string nombreArchivo)
        {

            Thread listener = new Thread(() =>
              {
                  
                      UdpClient readerClient = new UdpClient(receivePort);

                      Console.WriteLine("Awaiting data from server...");
                      var remoteEP = new IPEndPoint(IPAddress.Any, 0);

                      byte[] bytesReceived = readerClient.Receive(ref remoteEP);

                      string utfString = Encoding.UTF8.GetString(bytesReceived, 0, bytesReceived.Length);
                 
                 
                      FileStream ofs = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedes2Final\IF5000_Proyecto2\Nodo\" + ruta + nombreArchivo + ".txt", FileMode.Create, FileAccess.Write);
                     
                      ofs.Write(bytesReceived, 0, bytesReceived.Length);
                      
                      ofs.Close();
                  
                  



              });
            listener.Start();
            
            
            
            
        }

        public void senderUdpClient(string sendString)
        {
            UdpClient senderClient = new UdpClient();
            senderClient.Connect(this.sendEndPoint);
            if (String.IsNullOrEmpty(sendString))
                Console.WriteLine("Esta vacio");
            else
            {
                byte[] bytes = toBytes(sendString);
                Thread t = new Thread(() =>
                {
                    while (true)
                    {
                        senderClient.Send(bytes, bytes.Length);
                        Thread.Sleep(1000);
                    }
                });
                t.Start();
            }
           
        }
        public void sendByteUDP(byte[] bytes)
        {
            UdpClient senderClient = new UdpClient();
            senderClient.Connect(this.sendEndPoint);
            
                Thread t = new Thread(() =>
                {
                    while (true)
                    {
                        senderClient.Send(bytes, bytes.Length);
                        Thread.Sleep(1000);
                    }
                });
                t.Start();
        }

        public byte[] toBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public string fromBytes(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
