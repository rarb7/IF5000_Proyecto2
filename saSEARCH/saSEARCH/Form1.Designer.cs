
namespace saSEARCH
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.libroBuscar = new System.Windows.Forms.TextBox();
            this.consultaBT = new System.Windows.Forms.Button();
            this.comboLibros = new System.Windows.Forms.ComboBox();
            this.abrirBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // libroBuscar
            // 
            this.libroBuscar.Location = new System.Drawing.Point(121, 89);
            this.libroBuscar.Name = "libroBuscar";
            this.libroBuscar.Size = new System.Drawing.Size(100, 20);
            this.libroBuscar.TabIndex = 4;
            // 
            // consultaBT
            // 
            this.consultaBT.Location = new System.Drawing.Point(228, 85);
            this.consultaBT.Name = "consultaBT";
            this.consultaBT.Size = new System.Drawing.Size(75, 23);
            this.consultaBT.TabIndex = 5;
            this.consultaBT.Text = "Consultar";
            this.consultaBT.UseVisualStyleBackColor = true;
            this.consultaBT.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboLibros
            // 
            this.comboLibros.FormattingEnabled = true;
            this.comboLibros.Location = new System.Drawing.Point(121, 130);
            this.comboLibros.Name = "comboLibros";
            this.comboLibros.Size = new System.Drawing.Size(235, 21);
            this.comboLibros.TabIndex = 6;
            this.comboLibros.SelectedIndexChanged += new System.EventHandler(this.comboLibros_SelectedIndexChanged);
            // 
            // abrirBt
            // 
            this.abrirBt.Enabled = false;
            this.abrirBt.Location = new System.Drawing.Point(121, 177);
            this.abrirBt.Name = "abrirBt";
            this.abrirBt.Size = new System.Drawing.Size(100, 35);
            this.abrirBt.TabIndex = 7;
            this.abrirBt.Text = "Abrir Libro";
            this.abrirBt.UseVisualStyleBackColor = true;
            this.abrirBt.Click += new System.EventHandler(this.abrirBt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.abrirBt);
            this.Controls.Add(this.comboLibros);
            this.Controls.Add(this.consultaBT);
            this.Controls.Add(this.libroBuscar);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "SaSearch";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox libroBuscar;
        private System.Windows.Forms.Button consultaBT;
        private System.Windows.Forms.ComboBox comboLibros;
        private System.Windows.Forms.Button abrirBt;
    }
}

