using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace saSEARCH
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
                Console.WriteLine($"Received {bytesReceived.Length} bytes from {remoteEP}");
                string utfString = Encoding.UTF8.GetString(bytesReceived, 0, bytesReceived.Length);
                Console.WriteLine(utfString);
            }).Start();
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
