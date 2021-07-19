using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControllerNode
{
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
           //this.readerUdpClient();
           // this.senderUdpClient();
        }

        void readerUdpClient()
        {
            new Thread(() => {
                UdpClient readerClient = new UdpClient(receivePort);
                Console.WriteLine("Awaiting data from server...");
                var remoteEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] bytesReceived = readerClient.Receive(ref remoteEP);

                string utfString = Encoding.UTF8.GetString(bytesReceived, 0, bytesReceived.Length);
                Console.WriteLine(utfString);
                //byte[] bytes = Encoding.ASCII.GetBytes(utfString);
                FileStream ofs = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\pruebaUDP.huff", FileMode.Create, FileAccess.Write);
                ofs.Write(bytesReceived,0 ,bytesReceived.Length);
                //foreach (byte b in bytesReceived)
                //{
                //    ofs.WriteByte(b);
                //}

            }).Start();
        }

        void senderUdpClient()
        {
            UdpClient senderClient = new UdpClient();
            senderClient.Connect(this.sendEndPoint);
            string sendString = "1;2;3";
            byte[] bytes = toBytes(sendString);
            Thread t = new Thread(() => {
                while (true)
                {
                    senderClient.Send(bytes, bytes.Length);
                    Thread.Sleep(1000);
                }
            });
            t.Start();
        }
        public void sendNodo(int puerto)
        {
            this.sendEndPoint = new IPEndPoint(IPAddress.Parse(this.serverIP), puerto);
            UdpClient senderClient = new UdpClient();
            senderClient.Connect(this.sendEndPoint);
            string sendString = "HOla nodo"+puerto;
            byte[] bytes = toBytes(sendString);
            senderClient.Send(bytes, bytes.Length);
            senderClient.Close();
              
        }
        public void sendByteUDP(byte[] bytes,int puerto)
        {
            Console.WriteLine("Se esta enviando el archivo");
            this.sendEndPoint = new IPEndPoint(IPAddress.Parse(this.serverIP), puerto);
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
