
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
            this.SuspendLayout();
            // 
            // nodo1bt
            // 
            this.nodo1bt.Location = new System.Drawing.Point(629, 84);
            this.nodo1bt.Name = "nodo1bt";
            this.nodo1bt.Size = new System.Drawing.Size(88, 40);
            this.nodo1bt.TabIndex = 0;
            this.nodo1bt.Text = "Nodo1";
            this.nodo1bt.UseVisualStyleBackColor = true;
            this.nodo1bt.Click += new System.EventHandler(this.nodo1bt_Click);
            // 
            // nodo2bt
            // 
            this.nodo2bt.Location = new System.Drawing.Point(629, 130);
            this.nodo2bt.Name = "nodo2bt";
            this.nodo2bt.Size = new System.Drawing.Size(88, 40);
            this.nodo2bt.TabIndex = 1;
            this.nodo2bt.Text = "Nodo 2";
            this.nodo2bt.UseVisualStyleBackColor = true;
            this.nodo2bt.Click += new System.EventHandler(this.nodo2bt_Click);
            // 
            // nodo3bt
            // 
            this.nodo3bt.Location = new System.Drawing.Point(629, 176);
            this.nodo3bt.Name = "nodo3bt";
            this.nodo3bt.Size = new System.Drawing.Size(88, 40);
            this.nodo3bt.TabIndex = 2;
            this.nodo3bt.Text = "Nodo 3";
            this.nodo3bt.UseVisualStyleBackColor = true;
            this.nodo3bt.Click += new System.EventHandler(this.nodo3bt_Click);
            // 
            // nodo4bt
            // 
            this.nodo4bt.Location = new System.Drawing.Point(629, 222);
            this.nodo4bt.Name = "nodo4bt";
            this.nodo4bt.Size = new System.Drawing.Size(88, 40);
            this.nodo4bt.TabIndex = 3;
            this.nodo4bt.Text = "Nodo 4";
            this.nodo4bt.UseVisualStyleBackColor = true;
            this.nodo4bt.Click += new System.EventHandler(this.nodo4bt_Click);
            // 
            // nodo5
            // 
            this.nodo5.Location = new System.Drawing.Point(629, 268);
            this.nodo5.Name = "nodo5";
            this.nodo5.Size = new System.Drawing.Size(88, 40);
            this.nodo5.TabIndex = 4;
            this.nodo5.Text = "Nodo 5";
            this.nodo5.UseVisualStyleBackColor = true;
            this.nodo5.Click += new System.EventHandler(this.nodo5_Click);
            // 
            // encendido
            // 
            this.encendido.Location = new System.Drawing.Point(444, 75);
            this.encendido.Name = "encendido";
            this.encendido.Size = new System.Drawing.Size(108, 40);
            this.encendido.TabIndex = 5;
            this.encendido.Text = "Encender ";
            this.encendido.UseVisualStyleBackColor = true;
            this.encendido.Click += new System.EventHandler(this.button1_Click);
            // 
            // enviarbt
            // 
            this.enviarbt.Location = new System.Drawing.Point(462, 130);
            this.enviarbt.Name = "enviarbt";
            this.enviarbt.Size = new System.Drawing.Size(75, 23);
            this.enviarbt.TabIndex = 6;
            this.enviarbt.Text = "enviar";
            this.enviarbt.UseVisualStyleBackColor = true;
            this.enviarbt.Click += new System.EventHandler(this.enviarbt_Click);
            // 
            // ControllerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.enviarbt);
            this.Controls.Add(this.encendido);
            this.Controls.Add(this.nodo5);
            this.Controls.Add(this.nodo4bt);
            this.Controls.Add(this.nodo3bt);
            this.Controls.Add(this.nodo2bt);
            this.Controls.Add(this.nodo1bt);
            this.Name = "ControllerGUI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ControllerGUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nodo1bt;
        private System.Windows.Forms.Button nodo2bt;
        private System.Windows.Forms.Button nodo3bt;
        private System.Windows.Forms.Button nodo4bt;
        private System.Windows.Forms.Button nodo5;
        private System.Windows.Forms.Button encendido;
        private System.Windows.Forms.Button enviarbt;
    }
}

