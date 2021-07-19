using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllerNode
{
    class Raid
    {
        Lista lg;
        public Raid() {
            lg = new Lista();
            llenarListaPartes();
            
        }
        public void llenarListaPartes() {
            
            lg.Insertar(1, 3001);
            lg.Insertar(2, 3002);
            lg.Insertar(3, 3003);
            lg.Insertar(4, 3004);
            lg.Insertar(5, 3005);
            //lg.Imprimir();
            //lg.Extraer(2);
            lg.Imprimir();
            //Console.WriteLine("El nodo 2 esta en el puerto " + lg.ExtraerPuerto(5) + " extraido del nodo");
            //lg.Imprimir();
            //int[] puertos=lg.RecorrerLIsta();
            //for (int i = 0; i < puertos.Length; i++)
            //{

            //    Console.WriteLine("Puerto: "+puertos[i]);

            //}



        }

        public void enviarPartes() {

            

            string serverIP = "127.0.0.1";
            int sendPort = 3000;
            int receivePort = 27000;
            UDPHandler handler = new UDPHandler(serverIP, receivePort, sendPort);
            
            //Parte 1
            FileStream ifs = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\prueba1.txt", FileMode.Open, FileAccess.Read);
            byte[] sacadoArchivo1 = new byte[ifs.Length];

            for (int i = 0; i < ifs.Length; i++)
            {
                int ca = ifs.ReadByte();
                sacadoArchivo1[i] = Convert.ToByte(ca);
            }
            
            
            

            //Parte 2
            FileStream ifs1 = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\prueba2.txt", FileMode.Open, FileAccess.Read);
            byte[] sacadoArchivo2 = new byte[ifs1.Length];

            for (int i = 0; i < ifs1.Length; i++)
            {
                int ca = ifs1.ReadByte();
                sacadoArchivo2[i] = Convert.ToByte(ca);
            }

            
            
            
            //Parte 3
            FileStream ifs2 = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\prueba3.txt", FileMode.Open, FileAccess.Read);
            byte[] sacadoArchivo3 = new byte[ifs2.Length];

            for (int i = 0; i < ifs2.Length; i++)
            {
                int ca = ifs2.ReadByte();
                sacadoArchivo3[i] = Convert.ToByte(ca);
            }

            
            
            
            //Parte 4
            FileStream ifs3 = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\prueba4.txt", FileMode.Open, FileAccess.Read);
            byte[] sacadoArchivo4= new byte[ifs3.Length];

            for (int i = 0; i < ifs3.Length; i++)
            {
                int ca = ifs3.ReadByte();
                sacadoArchivo4[i] = Convert.ToByte(ca);
            }

            
            
            
            //Parte 5
            FileStream ifs4 = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\prueba5.txt", FileMode.Open, FileAccess.Read);
            byte[] sacadoArchivo5 = new byte[ifs4.Length];

            for (int i = 0; i < ifs4.Length; i++)
            {
                int ca = ifs4.ReadByte();
                sacadoArchivo5[i] = Convert.ToByte(ca);
            }





            handler.sendByteUDP(sacadoArchivo1, lg.ExtraerPuerto(1));
            handler.sendByteUDP(sacadoArchivo2, lg.ExtraerPuerto(2));
            handler.sendByteUDP(sacadoArchivo3, lg.ExtraerPuerto(3));
            handler.sendByteUDP(sacadoArchivo4, lg.ExtraerPuerto(4));
            handler.sendByteUDP(sacadoArchivo5, lg.ExtraerPuerto(5));

            Thread.Sleep(1000);
            Process p = new Process();
            string ruta = "a";
            string puerto = "3001";
            string carpeta = "5";
            
            p.StartInfo.FileName = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesRemoto3\IF5000_Proyecto2\Nodo\Nodo\bin\Nodo.exe";
            p.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
            p.Start();

            Process p2 = new Process();
            ruta = "a";
            puerto = "3002";
            carpeta = "1";
            p2.StartInfo.FileName = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesRemoto3\IF5000_Proyecto2\Nodo\Nodo\bin\Nodo.exe";
            p2.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
            p2.Start();

            Process p3 = new Process();
            ruta = "a";
            puerto = "3003";
            carpeta = "2";
            p3.StartInfo.FileName = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesRemoto3\IF5000_Proyecto2\Nodo\Nodo\bin\Nodo.exe";
            p3.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
            p3.Start();

            Process p4 = new Process();
            ruta = "a";
            puerto = "3004";
            carpeta = "3";
            p4.StartInfo.FileName = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesRemoto3\IF5000_Proyecto2\Nodo\Nodo\bin\Nodo.exe";
            p4.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
            p4.Start();

            Process p5 = new Process();
            ruta = "a";
            puerto = "3005";
            carpeta = "4";
            p5.StartInfo.FileName = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesRemoto3\IF5000_Proyecto2\Nodo\Nodo\bin\Nodo.exe";
            p5.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
            p5.Start();



            Thread.Sleep(1000);

            handler.sendByteUDP(sacadoArchivo1, lg.ExtraerPuerto(2));
            handler.sendByteUDP(sacadoArchivo2, lg.ExtraerPuerto(3));
            handler.sendByteUDP(sacadoArchivo3, lg.ExtraerPuerto(4));
            handler.sendByteUDP(sacadoArchivo4, lg.ExtraerPuerto(5));
            handler.sendByteUDP(sacadoArchivo5, lg.ExtraerPuerto(1));
            /*
            handler.sendByteUDP(sacadoArchivo, lg.ExtraerPuerto(1));
            handler.sendByteUDP(sacadoArchivo1, lg.ExtraerPuerto(2));
            handler.sendByteUDP(sacadoArchivo2, lg.ExtraerPuerto(3));
            handler.sendByteUDP(sacadoArchivo3, lg.ExtraerPuerto(4));
            handler.sendByteUDP(sacadoArchivo4, lg.ExtraerPuerto(5));
            */
            ifs.Close();
            ifs1.Close();
            ifs2.Close();
            ifs3.Close();
            ifs4.Close();





        }
    }
}
