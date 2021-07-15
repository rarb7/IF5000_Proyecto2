using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace saSEARCH
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            HuffmanEncoder.Encode(@"D:\UCR\UCR 2021\l Semestre\Redes\Proyecto2_redes\prueba.txt",
                @"D:\UCR\UCR 2021\l Semestre\Redes\Proyecto2_redes\prueba" + ".huff");


            // UDPSocket c = new UDPSocket();
            //c.Client("127.0.0.1", 27000);

            // c.Send(huffman.StringFinal);// arreglar fallo en guardar el primer hf


            //guardar el hf
            //c.Send(Encoding.Default.GetString(huffman.encodedBitArray));
            Console.ReadKey();
        }
    }
}
