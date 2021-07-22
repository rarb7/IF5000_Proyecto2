
namespace ControllerNode
{
    partial class ControllerGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nodo1bt = new System.Windows.Forms.Button();
            this.nodo2bt = new System.Windows.Forms.Button();
            this.nodo3bt = new System.Windows.Forms.Button();
            this.nodo4bt = new System.Windows.Forms.Button();
            this.nodo5 = new System.Windows.Forms.Button();
            this.encendido = new System.Windows.Forms.Button();
            this.enviarbt = new System.Windows.Forms.Button();
            this.comboLibros = new System.Windows.Forms.ComboBox();
            this.EnviarSA = new System.Windows.Forms.Button();
            this.archivoLibro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nodo1bt
            // 
            this.nodo1bt.Enabled = false;
            this.nodo1bt.Location = new System.Drawing.Point(454, 81);
            this.nodo1bt.Name = "nodo1bt";
            this.nodo1bt.Size = new System.Drawing.Size(88, 40);
            this.nodo1bt.TabIndex = 0;
            this.nodo1bt.Text = "Nodo1";
            this.nodo1bt.UseVisualStyleBackColor = true;
            this.nodo1bt.Click += new System.EventHandler(this.nodo1bt_Click);
            // 
            // nodo2bt
            // 
            this.nodo2bt.Enabled = false;
            this.nodo2bt.Location = new System.Drawing.Point(454, 127);
            this.nodo2bt.Name = "nodo2bt";
            this.nodo2bt.Size = new System.Drawing.Size(88, 40);
            this.nodo2bt.TabIndex = 1;
            this.nodo2bt.Text = "Nodo 2";
            this.nodo2bt.UseVisualStyleBackColor = true;
            this.nodo2bt.Click += new System.EventHandler(this.nodo2bt_Click);
            // 
            // nodo3bt
            // 
            this.nodo3bt.Enabled = false;
            this.nodo3bt.Location = new System.Drawing.Point(454, 173);
            this.nodo3bt.Name = "nodo3bt";
            this.nodo3bt.Size = new System.Drawing.Size(88, 40);
            this.nodo3bt.TabIndex = 2;
            this.nodo3bt.Text = "Nodo 3";
            this.nodo3bt.UseVisualStyleBackColor = true;
            this.nodo3bt.Click += new System.EventHandler(this.nodo3bt_Click);
            // 
            // nodo4bt
            // 
            this.nodo4bt.Enabled = false;
            this.nodo4bt.Location = new System.Drawing.Point(454, 219);
            this.nodo4bt.Name = "nodo4bt";
            this.nodo4bt.Size = new System.Drawing.Size(88, 40);
            this.nodo4bt.TabIndex = 3;
            this.nodo4bt.Text = "Nodo 4";
            this.nodo4bt.UseVisualStyleBackColor = true;
            this.nodo4bt.Click += new System.EventHandler(this.nodo4bt_Click);
            // 
            // nodo5
            // 
            this.nodo5.Enabled = false;
            this.nodo5.Location = new System.Drawing.Point(454, 265);
            this.nodo5.Name = "nodo5";
            this.nodo5.Size = new System.Drawing.Size(88, 40);
            this.nodo5.TabIndex = 4;
            this.nodo5.Text = "Nodo 5";
            this.nodo5.UseVisualStyleBackColor = true;
            this.nodo5.Click += new System.EventHandler(this.nodo5_Click);
            // 
            // encendido
            // 
            this.encendido.Location = new System.Drawing.Point(423, 35);
            this.encendido.Name = "encendido";
            this.encendido.Size = new System.Drawing.Size(160, 40);
            this.encendido.TabIndex = 5;
            this.encendido.Text = "Encender ";
            this.encendido.UseVisualStyleBackColor = true;
            this.encendido.Click += new System.EventHandler(this.button1_Click);
            // 
            // enviarbt
            // 
            this.enviarbt.Enabled = false;
            this.enviarbt.Location = new System.Drawing.Point(530, 324);
            this.enviarbt.Name = "enviarbt";
            this.enviarbt.Size = new System.Drawing.Size(75, 33);
            this.enviarbt.TabIndex = 6;
            this.enviarbt.Text = "enviar";
            this.enviarbt.UseVisualStyleBackColor = true;
            this.enviarbt.Click += new System.EventHandler(this.enviarbt_Click);
            // 
            // comboLibros
            // 
            this.comboLibros.FormattingEnabled = true;
            this.comboLibros.Location = new System.Drawing.Point(360, 331);
            this.comboLibros.Margin = new System.Windows.Forms.Padding(2);
            this.comboLibros.Name = "comboLibros";
            this.comboLibros.Size = new System.Drawing.Size(165, 21);
            this.comboLibros.TabIndex = 7;
            this.comboLibros.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // EnviarSA
            // 
            this.EnviarSA.Enabled = false;
            this.EnviarSA.Location = new System.Drawing.Point(20, 81);
            this.EnviarSA.Name = "EnviarSA";
            this.EnviarSA.Size = new System.Drawing.Size(182, 58);
            this.EnviarSA.TabIndex = 9;
            this.EnviarSA.Text = "<--- Enviar saSEARCH";
            this.EnviarSA.UseVisualStyleBackColor = true;
            this.EnviarSA.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // archivoLibro
            // 
            this.archivoLibro.Location = new System.Drawing.Point(20, 46);
            this.archivoLibro.Name = "archivoLibro";
            this.archivoLibro.Size = new System.Drawing.Size(182, 20);
            this.archivoLibro.TabIndex = 12;
            // 
            // ControllerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.archivoLibro);
            this.Controls.Add(this.EnviarSA);
            this.Controls.Add(this.comboLibros);
            this.Controls.Add(this.enviarbt);
            this.Controls.Add(this.encendido);
            this.Controls.Add(this.nodo5);
            this.Controls.Add(this.nodo4bt);
            this.Controls.Add(this.nodo3bt);
            this.Controls.Add(this.nodo2bt);
            this.Controls.Add(this.nodo1bt);
            this.Name = "ControllerGUI";
            this.Text = "ControllerNode";
            this.Load += new System.EventHandler(this.ControllerGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nodo1bt;
        private System.Windows.Forms.Button nodo2bt;
        private System.Windows.Forms.Button nodo3bt;
        private System.Windows.Forms.Button nodo4bt;
        private System.Windows.Forms.Button nodo5;
        private System.Windows.Forms.Button encendido;
        private System.Windows.Forms.Button enviarbt;
        private System.Windows.Forms.ComboBox comboLibros;
        private System.Windows.Forms.Button EnviarSA;
        private System.Windows.Forms.TextBox archivoLibro;
    }
}

