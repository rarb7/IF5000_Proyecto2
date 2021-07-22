using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace saSEARCH
{
    /// <summary>Clase que utiliza UDP para comunicarse</summary>
    class UDPHandler
    {
        private int receivePort, sendPort;
        private string serverIP;
        private IPEndPoint sendEndPoint, receiveEndPoint;

        /// <summary>Constructor por defecto <see cref="T:saSEARCH.UDPHandler" /> class.</summary>
        /// <param name="serverIP">The server ip.</param>
        /// <param name="receivePort">The receive port.</param>
        /// <param name="sendPort">The send port.</param>
        public UDPHandler(string serverIP, int receivePort, int sendPort)
        {
            this.serverIP = serverIP;
            this.receivePort = receivePort;
            this.sendPort = sendPort;
            this.sendEndPoint = new IPEndPoint(IPAddress.Parse(this.serverIP), this.sendPort);
            this.receiveEndPoint = new IPEndPoint(IPAddress.Parse(this.serverIP), this.receivePort);
            Thread hilo = new Thread(new ThreadStart(readerUdpClient));
            hilo.Start();
        }

        /// <summary>metodo llamado por un hilo el cual dependiento el mensaje que le llegue al socket realiza una accion</summary>
        void readerUdpClient()
        {
            while (true)
            {
                UdpClient readerClient = new UdpClient(receivePort);
                Console.WriteLine("Awaiting data from server...");

                var remoteEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] bytesReceived = readerClient.Receive(ref remoteEP);

                string utfString = Encoding.UTF8.GetString(bytesReceived, 0, bytesReceived.Length);
                Console.WriteLine(utfString);
                if (utfString == "Hola")
                {
                    Console.WriteLine("La comunicacion es exitosa");
                }
                else
                {
                    FileStream ofs = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesFinal2\IF5000_Proyecto2\saSEARCH\LibrosRecibidosHuffman\"+ Form1.titulo + ".huff", FileMode.Create, FileAccess.Write);
                    ofs.Write(bytesReceived, 0, bytesReceived.Length);
                    Console.WriteLine("Recibiendo Libro");
                    ofs.Close();
                    Thread.Sleep(500);
                    

                    HuffmanDecoder.Decode(@"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesFinal2\IF5000_Proyecto2\saSEARCH\LibrosRecibidosHuffman\" + Form1.titulo + ".huff", @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesFinal2\IF5000_Proyecto2\saSEARCH\LibroRecibido\" + Form1.titulo + ".txt");

                }
                readerClient.Close();
                utfString = "";
            }


        }
        /// <summary>Hilo que envia array de bytes</summary>
        /// <param name="bytes">The bytes.</param>
        public void sendByteUDP(byte[] bytes)
        {
            UdpClient senderClient = new UdpClient();
            senderClient.Connect(this.sendEndPoint);

            Thread t = new Thread(() =>
            {

                senderClient.Send(bytes, bytes.Length);
                Thread.Sleep(1000);

            });
            t.Start();


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


        /// <summary>String To the bytes.</summary>
        /// <param name="text">The text.</param>
        /// <returns>System.Byte[].</returns>
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
