using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerNode
{
    class Division_Archivos
    {
        // esto va en el main 
        //string mergeFolder;
        //Console.WriteLine("Hello World!");
        //    FileStream fs = new FileStream(@"C:\Users\Raquel\Desktop\I.E\5semestre\Redes\pruebas\B76152.pdf", FileMode.Open, FileAccess.Read);
        //int FileLength = (int)fs.Length / 1024;
        ////string name = Path.GetFileName(txtBrowsFile.Text);
        //List Packets = new List();
        ////la ruta de donde se van a guardar los archivos unidos para enviar el libro al cliente
        //string SaveFileFolder = @"C:\Users\Raquel\Desktop\I.E\5semestre\Redes\pruebas";
        ////SplitFile(@"C:\Users\Raquel\Desktop\I.E\5semestre\Redes\pruebas\splitPDF.txt", 5);
        //MergeFile(@"C:\Users\Raquel\Desktop\I.E\5semestre\Redes\pruebas\txt\");

        public bool SplitFile(string SourceFile, int nNoofFiles, string mergeFolder)
        {
            List<String> Packets = new List<String>();// se cambio a una lista de String
            bool Split = false;
            try
            {
                FileStream fs = new FileStream(SourceFile, FileMode.Open, FileAccess.Read);
                int SizeofEachFile = (int)Math.Ceiling((double)fs.Length / nNoofFiles);

                for (int i = 0; i < nNoofFiles; i++)
                {
                    string baseFileName = Path.GetFileNameWithoutExtension(SourceFile);
                    string Extension = Path.GetExtension(SourceFile);

                    FileStream outputFile = new FileStream(@"C:\Users\Raquel\Desktop\I.E\5semestre\Redes\pruebas\" + "" + baseFileName + "." +
                        i.ToString().PadLeft(5, Convert.ToChar("0")) + Extension + ".tmp", FileMode.Create, FileAccess.Write);

                    mergeFolder = Path.GetDirectoryName(SourceFile);

                    int bytesRead = 0;
                    byte[] buffer = new byte[SizeofEachFile];

                    if ((bytesRead = fs.Read(buffer, 0, SizeofEachFile)) > 0)
                    {
                        outputFile.Write(buffer, 0, bytesRead);

                        string packet = baseFileName + "." + i.ToString().PadLeft(3, Convert.ToChar("0")) + Extension.ToString();
                        Console.WriteLine(packet);
                        Packets.Add(packet);
                    }

                    outputFile.Close();

                }
                fs.Close();
            }
            catch (Exception Ex)
            {
                throw new ArgumentException(Ex.Message);
            }

            return Split;
        }//split files

        bool MergeFile(string inputfoldername1)
        {
            bool Output = false;

            try
            {
                //for con las rutas de los esclavos
                string[] tmpfiles = Directory.GetFiles(inputfoldername1, "*.tmp");

                for (int i = 1; i < tmpfiles.Length; i++)
                {
                    Console.WriteLine(tmpfiles[i].ToString());
                }

                FileStream outPutFile = null;
                string PrevFileName = "";

                foreach (string tempFile in tmpfiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(tempFile);
                    string baseFileName = fileName.Substring(0, fileName.IndexOf(Convert.ToChar(".")));
                    string extension = Path.GetExtension(fileName);

                    if (!PrevFileName.Equals(baseFileName))
                    {
                        if (outPutFile != null)
                        {
                            outPutFile.Flush();
                            outPutFile.Close();
                        }
                        outPutFile = new FileStream(@"C:\Users\Raquel\Desktop\I.E\5semestre\Redes\pruebas\" + "" + baseFileName + extension, FileMode.OpenOrCreate, FileAccess.Write);

                    }

                    int bytesRead = 0;
                    byte[] buffer = new byte[1024];
                    FileStream inputTempFile = new FileStream(tempFile, FileMode.OpenOrCreate, FileAccess.Read);

                    while ((bytesRead = inputTempFile.Read(buffer, 0, 1024)) > 0)
                        outPutFile.Write(buffer, 0, bytesRead);

                    inputTempFile.Close();
                    //File.Delete(tempFile);
                    PrevFileName = baseFileName;

                }

                outPutFile.Close();

            }
            catch
            {

            }

            return Output;



        }


    }
}
