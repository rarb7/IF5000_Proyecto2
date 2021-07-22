﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            Thread hilo = new Thread(new ThreadStart(readerUdpClient));
            hilo.Start();
        }

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
                
                string[] words = utfString.Split(',');
                if (words[0]=="Buscar")
                {
                    Console.WriteLine("La comunicacion es exitosa");
                    Console.WriteLine("------->"+words[1]);
                    SqlConnection sqlConnection = SQLmanager.GetSQLConnection();
                    Console.WriteLine(sqlConnection.ConnectionString);
                    string consulta = "select top 1 ARCHIVO from tb_ARCHIVO_Libro where libro_id=" + words[1];
                    sqlConnection.Open();

                    SqlCommand cmd = new SqlCommand(consulta, sqlConnection);
                    cmd.CommandText = consulta;
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        ControllerGUI.titulo=(rd["ARCHIVO"].ToString());
                    }





                }
                else
                {
                    FileStream ofs = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\pruebaUDPCOntroller.huff", FileMode.Create, FileAccess.Write);
                    ofs.Write(bytesReceived, 0, bytesReceived.Length);
                    Console.WriteLine("Esta esuchando");

                }
                readerClient.Close();
                utfString = "";
            }


        }
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

       
       
        public void sendByteUDP(byte[] bytes,int puerto)
        {
           
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
