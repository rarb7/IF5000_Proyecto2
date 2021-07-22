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
    /// <summary>Esta es la clase que se implementa el RAID</summary>
    class Raid
    {
        Lista lg;
        string carpetaEliminada;
        private string rutaNodo=@"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesFinal2\IF5000_Proyecto2\Nodo\Nodo\bin\Nodo.exe";
        public Raid(Lista nuevaLista,string eliminado) {
            lg = nuevaLista;
            carpetaEliminada = eliminado;
            
        }


        /// <summary>Enviar las partes a cada nodo</summary>
        /// <param name="archivos">The archivos.</param>
        /// <param name="nombre">The nombre.</param>
        public void enviarPartes(List<string> archivos, string nombre) {

            string ruta = "";
            string puerto = "";
            string carpeta = "";
            

            string serverIP = "127.0.0.1";
            int sendPort = 2999;
            int receivePort = 27001;

            UDPHandler handler = new UDPHandler(serverIP, receivePort, sendPort);
            
            //Parte 1
            FileStream ifs1 = new FileStream(archivos[0], FileMode.Open, FileAccess.Read);
            byte[] sacadoArchivo1 = new byte[ifs1.Length];

            for (int i = 0; i < ifs1.Length; i++)//Enviando partes a todos los nodos
            {
                int ca = ifs1.ReadByte();
                sacadoArchivo1[i] = Convert.ToByte(ca);
            }
            Thread.Sleep(1000);



            //Parte 2
            FileStream ifs2 = new FileStream(archivos[1], FileMode.Open, FileAccess.Read);
            byte[] sacadoArchivo2 = new byte[ifs1.Length];

            for (int i = 0; i < ifs2.Length; i++)
            {
                int ca = ifs2.ReadByte();
                sacadoArchivo2[i] = Convert.ToByte(ca);
            }

            
            
            
            //Parte 3
            FileStream ifs3 = new FileStream(archivos[2], FileMode.Open, FileAccess.Read);
            byte[] sacadoArchivo3 = new byte[ifs3.Length];

            for (int i = 0; i < ifs3.Length; i++)
            {
                int ca = ifs3.ReadByte();
                sacadoArchivo3[i] = Convert.ToByte(ca);
            }

            
            
            
            //Parte 4
            FileStream ifs4 = new FileStream(archivos[3], FileMode.Open, FileAccess.Read);
            byte[] sacadoArchivo4= new byte[ifs4.Length];

            for (int i = 0; i < ifs4.Length; i++)
            {
                int ca = ifs4.ReadByte();
                sacadoArchivo4[i] = Convert.ToByte(ca);
            }

            
            
            
            //Parte 5
            FileStream ifs5 = new FileStream(archivos[4], FileMode.Open, FileAccess.Read);
            byte[] sacadoArchivo5 = new byte[ifs5.Length];

            for (int i = 0; i < ifs5.Length; i++)
            {
                int ca = ifs5.ReadByte();
                sacadoArchivo5[i] = Convert.ToByte(ca);
            }



            if (lg.Existe(3001))
            {
                Console.WriteLine("exite el nodo 1");
                Process pp1 = new Process();
                ruta = nombre + "1";
                puerto = "3001";
                carpeta = "1";
                pp1.StartInfo.FileName = rutaNodo;
                pp1.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
                pp1.Start();
                
            }
            else {
                Console.WriteLine("NO existe");
            }
            ruta = "";
            puerto = "";
            carpeta = "";
            if (lg.Existe(3002))
            {
                Console.WriteLine("exite el nodo 2");
                Process pp2 = new Process();
                ruta = nombre+"2";
                puerto = "3002";
                carpeta = "2";
                pp2.StartInfo.FileName = rutaNodo;
                pp2.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
                pp2.Start();
              
            }
            ruta = "";
            puerto = "";
            carpeta = "";
            if (lg.Existe(3003))
            {
                Console.WriteLine("exite el nodo 3");
                Process pp3 = new Process();
                ruta = nombre+"3";
                puerto = "3003";
                carpeta = "3";
                pp3.StartInfo.FileName = rutaNodo;
                pp3.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
                pp3.Start();
                
            }
            ruta = "";
            puerto = "";
            carpeta = "";
            if (lg.Existe(3004))
            {
                Console.WriteLine("exite el nodo 4");
                Process pp4 = new Process();
                ruta = nombre+"4";
                puerto = "3004";
                carpeta = "4";
                pp4.StartInfo.FileName = rutaNodo;
                pp4.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
                pp4.Start();
                
            }
            ruta = "";
            puerto = "";
            carpeta = "";
            if (lg.Existe(3005))
            {
                Console.WriteLine("exite el nodo 5");
                Process pp5 = new Process();
                ruta = nombre+"5";
                puerto = "3005";
                carpeta = "5";
                pp5.StartInfo.FileName = rutaNodo;
                pp5.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
                pp5.Start();
               
            }
            ruta = "";
            puerto = "";
            carpeta = "";
            try {
                handler.sendByteUDP(sacadoArchivo1, 3001);
                handler.sendByteUDP(sacadoArchivo2,3002);
                handler.sendByteUDP(sacadoArchivo3, 3003);
                handler.sendByteUDP(sacadoArchivo4, 3004);
                handler.sendByteUDP(sacadoArchivo5, 3005);
            } catch { 
            }



            Thread.Sleep(1000);
           
            
            ruta = nombre+"1";
            puerto = "3001";
            carpeta = "5";
            if (carpetaEliminada!=carpeta) {
                Process p = new Process();
                p.StartInfo.FileName = rutaNodo;
                p.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
                p.Start();
            }
            
            

           
            ruta = nombre+"2";
            puerto = "3002";
            carpeta = "1";
            if (carpetaEliminada != carpeta)
            {
                Process p2 = new Process();
                p2.StartInfo.FileName = rutaNodo;
                p2.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
                p2.Start();
            }


            
            ruta = nombre+"3";
            puerto = "3003";
            carpeta = "2";
            if (carpetaEliminada != carpeta)
            {
                Process p3 = new Process();
                p3.StartInfo.FileName = rutaNodo;
                p3.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
                p3.Start();

            }

            
            ruta = nombre+"4";
            puerto = "3004";
            carpeta = "3";
            if (carpetaEliminada != carpeta)
            {
                Process p4 = new Process();
                p4.StartInfo.FileName = rutaNodo;
                p4.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
                p4.Start();
            }

            
            ruta = nombre+"5";
            puerto = "3005";
            carpeta = "4";
            if (carpetaEliminada != carpeta)
            {
                Process p5 = new Process();
                p5.StartInfo.FileName = rutaNodo;
                p5.StartInfo.Arguments = " " + ruta + " " + puerto + " " + carpeta + " ";
                p5.Start();
            }

            Thread.Sleep(1000);
            try
            {
                
                    handler.sendByteUDP(sacadoArchivo1, 3005);
                
                    handler.sendByteUDP(sacadoArchivo2, 3001);
                
                    handler.sendByteUDP(sacadoArchivo3, 3002);
                
                    handler.sendByteUDP(sacadoArchivo4, 3003);
                
                    handler.sendByteUDP(sacadoArchivo5, 3004);
                
            }
            catch
            {

            }

            ifs1.Close();
            ifs2.Close();
            ifs3.Close();
            ifs4.Close();
            ifs5.Close();
        }//enviar archivos

        /// <summary>Une las partes del archivo que son .tmp en un nuevo txt</summary>
        /// <param name="nombreLibro">The nombre libro.</param>
        public void UnirPartes(string nombreLibro)
        {

            string[] rutas = { "A", "B", "C", "A", "B" };
            for (int i = 0; i < 5; i++)
            {
                //Console.WriteLine(i);
                if (int.Parse(carpetaEliminada) == 1)
                {
                    rutas[i] = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesFinal2\IF5000_Proyecto2\Nodo\LibrosNodo" + 5 + "\\" + nombreLibro + "." + 1 + ".txt";
                    Console.WriteLine(i);
                    carpetaEliminada = "7";
                }
                else if (Int32.Parse(carpetaEliminada) == (i + 1) && (i + 1) != 1)
                {

                    rutas[i] = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesFinal2/IF5000_Proyecto2\Nodo\LibrosNodo" + i + "\\" + nombreLibro + "." + (i + 1) + ".txt";
                    Console.WriteLine(i - 1);
                    Console.WriteLine("entro ala carpeta eliminada: " + i);
                }
                else
                {
                    rutas[i] = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesFinal2\IF5000_Proyecto2\Nodo\LibrosNodo" + (i + 1) + "\\" + nombreLibro + "." + (i + 1) + ".txt";
                    Console.WriteLine("entro ala carpeta eliminada: " + i);
                    Console.WriteLine(i);
                }


            }//for que recorre si hay un nodo apagado o no para la recuperacion

            FileStream ofs = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesFinal2\IF5000_Proyecto2\ControllerNode\LibrosParaSA\" + nombreLibro + ".txt", FileMode.Create, FileAccess.Write);
            ofs.Close();
            string ruta = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedesFinal2\IF5000_Proyecto2\ControllerNode\LibrosParaSA\" + nombreLibro + ".txt";
            Division_Archivos da = new Division_Archivos();
            if (rutas != null)
            {
                da.MergeFile(rutas, nombreLibro, ruta);
            }
            


        }//unirPartes

    }
}
