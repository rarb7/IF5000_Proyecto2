﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerNode
{
    class Division_Archivos
    {
        
        public List<string> SplitFile(string SourceFile, int nNoofFiles, string mergeFolder)
        {
            List<String> Packets = new List<String>();// se cambio a una lista de String
            bool Split = false;
            string carpeta = @"D:\UCR\UCR 2021\l Semestre\Redes\proyectoRedesRemoto6\IF5000_Proyecto2\Nodo\tmps\";
            try
            {
                FileStream fs = new FileStream(SourceFile, FileMode.Open, FileAccess.Read);
                int SizeofEachFile = (int)Math.Ceiling((double)fs.Length / nNoofFiles);

                for (int i = 0; i < nNoofFiles; i++)
                {
                    string baseFileName = Path.GetFileNameWithoutExtension(SourceFile);
                    string Extension = Path.GetExtension(SourceFile);

                    FileStream outputFile = new FileStream(carpeta + "" + baseFileName + "." +
                        i.ToString().PadLeft(3, Convert.ToChar("0")) + Extension + ".tmp", FileMode.Create, FileAccess.Write);

                

                    int bytesRead = 0;
                    byte[] buffer = new byte[SizeofEachFile];

                    if ((bytesRead = fs.Read(buffer, 0, SizeofEachFile)) > 0)
                    {
                        outputFile.Write(buffer, 0, bytesRead);

                        string packet = baseFileName + "." + i.ToString().PadLeft(3, Convert.ToChar("0")) + Extension.ToString();
                        Console.WriteLine(packet);
                        Packets.Add(carpeta + packet + ".tmp");
                    }

                    outputFile.Close();

                }
                fs.Close();
            }
            catch (Exception Ex)
            {
                throw new ArgumentException(Ex.Message);
            }

            return Packets;
        }//split files


        public void MergeFile(string[] inputfoldername1, string nombre, string ruta)
        {
            string[] tmpfiles = inputfoldername1;

            try
            {
                
                string string1 = File.ReadAllText(tmpfiles[0]);
                string string2 = File.ReadAllText(tmpfiles[1]);
                File.WriteAllText(ruta, string1 + "\n" + string2);

                string string3 = File.ReadAllText(tmpfiles[2]);
                string completo = File.ReadAllText(ruta);

                File.WriteAllText(ruta, completo + "\n" + string3);


                string string4 = File.ReadAllText(tmpfiles[3]);
                completo = File.ReadAllText(ruta);

                File.WriteAllText(ruta, completo + "\n" + string4);


                string string5 = File.ReadAllText(tmpfiles[4]);
                completo = File.ReadAllText(ruta);

                File.WriteAllText(ruta, completo + "\n" + string5);


            }

            catch (Exception e)
            {
                Console.WriteLine("Error general");
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

        }



    }
}
