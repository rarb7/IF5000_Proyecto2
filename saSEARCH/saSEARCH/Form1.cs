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
    /// <summary>Clase correspondiente al GUI saSEARCH.
    /// Implements the <see cref="System.Windows.Forms.Form" /></summary>
    public partial class Form1 : Form
    {
        UDPHandler handler;
        public static string titulo;
        /// <summary>Initializa los componentes y la comunicacion con ControllerNode <see cref="T:saSEARCH.Form1" /> class.</summary>
        public Form1()
        {
            string serverIP = "127.0.0.1";
            int sendPort = 27000;
            int receivePort = 3000;
            handler = new UDPHandler(serverIP, receivePort, sendPort);
            InitializeComponent();
        }

        /// <summary>Selecciona el libro que se desea visualizar.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            
            string mensaje = "Buscar,"+comboLibros.SelectedValue.ToString();
            
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



        /// <summary>Se comunica con la base de datos para saber que libros hay deacuerdo al metadato insertado.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>Abre el libro que fue mandado por ControllerNode.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void abrirBt_Click(object sender, EventArgs e)
        {
            
           
            Process p = new Process();
            p.StartInfo.FileName = @"D:\UCR\UCR 2021\l Semestre\Redes\ProyectoRedes2Final\IF5000_Proyecto2\saSEARCH\LibroRecibido\"+titulo+".txt";
            p.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
