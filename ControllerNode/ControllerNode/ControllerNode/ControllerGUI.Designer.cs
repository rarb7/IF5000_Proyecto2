
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.archivoLibro = new System.Windows.Forms.TextBox();
            this.EnviarSA = new System.Windows.Forms.Button();
            this.comboLibros = new System.Windows.Forms.ComboBox();
            this.enviarbt = new System.Windows.Forms.Button();
            this.encendido = new System.Windows.Forms.Button();
            this.nodo5 = new System.Windows.Forms.Button();
            this.nodo4bt = new System.Windows.Forms.Button();
            this.nodo3bt = new System.Windows.Forms.Button();
            this.nodo2bt = new System.Windows.Forms.Button();
            this.nodo1bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 24);
            this.label3.TabIndex = 28;
            this.label3.Text = "ControllerNode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Archivo que se va a enviar al SA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(519, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nodos";
            // 
            // archivoLibro
            // 
            this.archivoLibro.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archivoLibro.Location = new System.Drawing.Point(72, 179);
            this.archivoLibro.Name = "archivoLibro";
            this.archivoLibro.Size = new System.Drawing.Size(182, 27);
            this.archivoLibro.TabIndex = 25;
            // 
            // EnviarSA
            // 
            this.EnviarSA.Enabled = false;
            this.EnviarSA.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnviarSA.Location = new System.Drawing.Point(72, 214);
            this.EnviarSA.Name = "EnviarSA";
            this.EnviarSA.Size = new System.Drawing.Size(182, 43);
            this.EnviarSA.TabIndex = 24;
            this.EnviarSA.Text = "<--- Enviar saSEARCH";
            this.EnviarSA.UseVisualStyleBackColor = true;
            this.EnviarSA.Click += new System.EventHandler(this.EnviarSA_Click);
            // 
            // comboLibros
            // 
            this.comboLibros.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLibros.FormattingEnabled = true;
            this.comboLibros.Location = new System.Drawing.Point(412, 390);
            this.comboLibros.Margin = new System.Windows.Forms.Padding(2);
            this.comboLibros.Name = "comboLibros";
            this.comboLibros.Size = new System.Drawing.Size(165, 25);
            this.comboLibros.TabIndex = 23;
            // 
            // enviarbt
            // 
            this.enviarbt.Enabled = false;
            this.enviarbt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviarbt.Location = new System.Drawing.Point(582, 383);
            this.enviarbt.Name = "enviarbt";
            this.enviarbt.Size = new System.Drawing.Size(75, 33);
            this.enviarbt.TabIndex = 22;
            this.enviarbt.Text = "enviar";
            this.enviarbt.UseVisualStyleBackColor = true;
            this.enviarbt.Click += new System.EventHandler(this.enviarbt_Click_1);
            // 
            // encendido
            // 
            this.encendido.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encendido.Location = new System.Drawing.Point(475, 94);
            this.encendido.Name = "encendido";
            this.encendido.Size = new System.Drawing.Size(147, 40);
            this.encendido.TabIndex = 21;
            this.encendido.Text = "Encender ";
            this.encendido.UseVisualStyleBackColor = true;
            this.encendido.Click += new System.EventHandler(this.encendido_Click);
            // 
            // nodo5
            // 
            this.nodo5.Enabled = false;
            this.nodo5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodo5.Location = new System.Drawing.Point(506, 324);
            this.nodo5.Name = "nodo5";
            this.nodo5.Size = new System.Drawing.Size(88, 40);
            this.nodo5.TabIndex = 20;
            this.nodo5.Text = "Nodo 5";
            this.nodo5.UseVisualStyleBackColor = true;
            this.nodo5.Click += new System.EventHandler(this.nodo5_Click_1);
            // 
            // nodo4bt
            // 
            this.nodo4bt.Enabled = false;
            this.nodo4bt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodo4bt.Location = new System.Drawing.Point(506, 278);
            this.nodo4bt.Name = "nodo4bt";
            this.nodo4bt.Size = new System.Drawing.Size(88, 40);
            this.nodo4bt.TabIndex = 19;
            this.nodo4bt.Text = "Nodo 4";
            this.nodo4bt.UseVisualStyleBackColor = true;
            this.nodo4bt.Click += new System.EventHandler(this.nodo4bt_Click_1);
            // 
            // nodo3bt
            // 
            this.nodo3bt.Enabled = false;
            this.nodo3bt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodo3bt.Location = new System.Drawing.Point(506, 232);
            this.nodo3bt.Name = "nodo3bt";
            this.nodo3bt.Size = new System.Drawing.Size(88, 40);
            this.nodo3bt.TabIndex = 18;
            this.nodo3bt.Text = "Nodo 3";
            this.nodo3bt.UseVisualStyleBackColor = true;
            this.nodo3bt.Click += new System.EventHandler(this.nodo3bt_Click_1);
            // 
            // nodo2bt
            // 
            this.nodo2bt.Enabled = false;
            this.nodo2bt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodo2bt.Location = new System.Drawing.Point(506, 186);
            this.nodo2bt.Name = "nodo2bt";
            this.nodo2bt.Size = new System.Drawing.Size(88, 40);
            this.nodo2bt.TabIndex = 17;
            this.nodo2bt.Text = "Nodo 2";
            this.nodo2bt.UseVisualStyleBackColor = true;
            this.nodo2bt.Click += new System.EventHandler(this.nodo2bt_Click_1);
            // 
            // nodo1bt
            // 
            this.nodo1bt.Enabled = false;
            this.nodo1bt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodo1bt.Location = new System.Drawing.Point(506, 140);
            this.nodo1bt.Name = "nodo1bt";
            this.nodo1bt.Size = new System.Drawing.Size(88, 40);
            this.nodo1bt.TabIndex = 16;
            this.nodo1bt.Text = "Nodo1";
            this.nodo1bt.UseVisualStyleBackColor = true;
            this.nodo1bt.Click += new System.EventHandler(this.nodo1bt_Click_1);
            // 
            // ControllerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox archivoLibro;
        private System.Windows.Forms.Button EnviarSA;
        private System.Windows.Forms.ComboBox comboLibros;
        private System.Windows.Forms.Button enviarbt;
        private System.Windows.Forms.Button encendido;
        private System.Windows.Forms.Button nodo5;
        private System.Windows.Forms.Button nodo4bt;
        private System.Windows.Forms.Button nodo3bt;
        private System.Windows.Forms.Button nodo2bt;
        private System.Windows.Forms.Button nodo1bt;
    }
}

