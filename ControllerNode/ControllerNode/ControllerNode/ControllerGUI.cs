using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllerNode
{
    public partial class ControllerGUI : Form
    {
        Lista listanodos = new Lista();
        string nodoEliminado = "";
        public ControllerGUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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
            listanodos.Imprimir();
            Raid raid = new Raid(listanodos,nodoEliminado);
            raid.enviarPartes();
        }
    }
}
