using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllerNode
{
    public partial class ControllerGUI : Form
    {
        Lista listanodos = new Lista();
        string nodoEliminado = "7";
        UDPHandler handler;
        public static string titulo;
        public ControllerGUI()
        {
            comunicacion();
            InitializeComponent();
            FillComboBox();
            
        }
        public void comunicacion()
        {
            string serverIP = "127.0.0.1";
            int sendPort = 3000;
            int receivePort = 27000;
            handler = new UDPHandler(serverIP, receivePort, sendPort);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnviarSA.Enabled = true;
            nodo1bt.Enabled = true;
            nodo2bt.Enabled = true;
            nodo3bt.Enabled = true;
            nodo4bt.Enabled = true;
            nodo5.Enabled = true;
            enviarbt.Enabled = true;

            listanodos.Insertar(1, 3001);
            listanodos.Insertar(2, 3002);
            listanodos.Insertar(3, 3003);
            listanodos.Insertar(4, 3004);
            listanodos.Insertar(5, 3005);

        }

        private void ControllerGUI_Load(object sender, EventArgs e)
        {

        }

        private void nodo1bt_Click(object sender, EventArgs e)
        {
            listanodos.Extraer(1);
            nodoEliminado = "1";
        }

        private void nodo2bt_Click(object sender, EventArgs e)
        {
            listanodos.Extraer(2);
            nodoEliminado = "2";
        }

        private void nodo3bt_Click(object sender, EventArgs e)
        {
            listanodos.Extraer(3);
            nodoEliminado = "3";
        }

        private void nodo4bt_Click(object sender, EventArgs e)
        {
            listanodos.Extraer(4);
            nodoEliminado = "4";
        }

        private void nodo5_Click(object sender, EventArgs e)
        {
            listanodos.Extraer(5);
            nodoEliminado = "5";
        }

        private void enviarbt_Click(object sender, EventArgs e)
        {
            string titulo = comboLibros.SelectedItem.ToString();
            MessageBox.Show(titulo);

            Division_Archivos da = new Division_Archivos();
            List<string> archivosDivididos = da.SplitFile(@"D:\UCR\UCR 2021\l Semestre\Redes\proyectoRedesRemoto6\IF5000_Proyecto2\ControllerNode\Enviar\" + titulo+".txt", 5, "");
            listanodos.Imprimir();
            Raid raid = new Raid(listanodos, nodoEliminado);
            raid.enviarPartes(archivosDivididos, titulo+".");
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }//fin metodo

        private void FillComboBox() {
            String[] archivos = Directory.GetFiles(@"D:\UCR\UCR 2021\l Semestre\Redes\proyectoRedesRemoto6\IF5000_Proyecto2\ControllerNode\Enviar");
        
            if (archivos != null)
            {
                for (int i = 0; i < archivos.Length; i++)
                {
                    FileInfo fi = new FileInfo(archivos[i]);
                   
                    var nombre = Path.GetFileNameWithoutExtension(fi.Name);//obtener el nombre del libroooooo
                    comboLibros.Items.Add(nombre);
                }//for
            }
            else
            {
                comboLibros.Items.Add("No disponibles");
            }//fin if else

            

        }//metodo que llena el combobox con los libros deseados
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Enviando el "+titulo+" a saSEARCH");
            archivoLibro.Text = titulo;

            Raid raid = new Raid(listanodos, nodoEliminado);
            raid.UnirPartes(titulo);



            HuffmanEncoder.Encode(@"D:\UCR\UCR 2021\l Semestre\Redes\proyectoRedesRemoto6\IF5000_Proyecto2\ControllerNode\LibrosParaSA\" + titulo + ".txt",
            @"D:\UCR\UCR 2021\l Semestre\Redes\proyectoRedesRemoto6\IF5000_Proyecto2\ControllerNode\LibrosComprimidos\" + titulo + ".huff");

            FileStream ifs = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\proyectoRedesRemoto6\IF5000_Proyecto2\ControllerNode\LibrosComprimidos\" + titulo + ".huff", FileMode.Open, FileAccess.Read);
            byte[] sacadoArchivo = new byte[ifs.Length];

            for (int i = 0; i < ifs.Length; i++)
            {
                int ca = ifs.ReadByte();
                sacadoArchivo[i] = Convert.ToByte(ca);
            }


            handler.sendByteUDP(sacadoArchivo);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mensaje = "Hola";
            byte[] sacadoArchivo = Encoding.ASCII.GetBytes(mensaje);

            handler.sendByteUDP(sacadoArchivo);
        }

        private void comboSA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
