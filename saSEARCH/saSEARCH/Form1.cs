using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saSEARCH
{
    public partial class Form1 : Form
    {
        UDPHandler handler;
        public static string titulo;
        public Form1()
        {
            string serverIP = "127.0.0.1";
            int sendPort = 27000;
            int receivePort = 3000;
            handler = new UDPHandler(serverIP, receivePort, sendPort);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string mensaje = "Buscar,"+comboLibros.SelectedValue.ToString();
            Console.WriteLine(mensaje+" ********");
            byte[] sacadoArchivo = Encoding.ASCII.GetBytes(mensaje);

            

            DataRowView oDataRowView = comboLibros.SelectedItem as DataRowView;
            string sValue = string.Empty;

            if (oDataRowView != null)
            {
                sValue = oDataRowView.Row["TITULO_LIBRO"] as string;
            }
            
            MessageBox.Show(sValue);
            titulo = sValue;
            handler.sendByteUDP(sacadoArchivo);
            abrirBt.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream ifs = new FileStream(@"D:\UCR\UCR 2021\l Semestre\Redes\pruebaUDP.huff", FileMode.Open, FileAccess.Read);
            byte[] sacadoArchivo = new byte[ifs.Length];

            handler.sendByteUDP(sacadoArchivo);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection = SQLManager.GetSQLConnection();
            Console.WriteLine(sqlConnection.ConnectionString);
            string consulta = "EXEC SP_BUSCAR_LIBRO " + libroBuscar.Text;
            sqlConnection.Open();

            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, sqlConnection);
            DataTable table = new DataTable();
            try
            {
                adaptador.Fill(table);
                comboLibros.DisplayMember = "TITULO_LIBRO";
                comboLibros.ValueMember = "Libro.LIBRO_ID";
                comboLibros.DataSource = table;
                
            }
            catch { 
            
            }

        }

        private void comboLibros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void abrirBt_Click(object sender, EventArgs e)
        {
            
           
            Process p = new Process();
            p.StartInfo.FileName = @"D:\UCR\UCR 2021\l Semestre\Redes\proyectoRedesRemoto6\IF5000_Proyecto2\saSEARCH\LibroRecibido\"+titulo+".txt";
            p.Start();
        }
    }
}
