
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(540, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Solicitar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // libroBuscar
            // 
            this.libroBuscar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libroBuscar.Location = new System.Drawing.Point(431, 96);
            this.libroBuscar.Name = "libroBuscar";
            this.libroBuscar.Size = new System.Drawing.Size(144, 27);
            this.libroBuscar.TabIndex = 4;
            // 
            // consultaBT
            // 
            this.consultaBT.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultaBT.Location = new System.Drawing.Point(595, 96);
            this.consultaBT.Name = "consultaBT";
            this.consultaBT.Size = new System.Drawing.Size(110, 27);
            this.consultaBT.TabIndex = 5;
            this.consultaBT.Text = "Consultar";
            this.consultaBT.UseVisualStyleBackColor = true;
            this.consultaBT.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboLibros
            // 
            this.comboLibros.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLibros.FormattingEnabled = true;
            this.comboLibros.Location = new System.Drawing.Point(267, 164);
            this.comboLibros.Name = "comboLibros";
            this.comboLibros.Size = new System.Drawing.Size(267, 27);
            this.comboLibros.TabIndex = 6;
            this.comboLibros.SelectedIndexChanged += new System.EventHandler(this.comboLibros_SelectedIndexChanged);
            // 
            // abrirBt
            // 
            this.abrirBt.Enabled = false;
            this.abrirBt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abrirBt.Location = new System.Drawing.Point(335, 207);
            this.abrirBt.Name = "abrirBt";
            this.abrirBt.Size = new System.Drawing.Size(100, 35);
            this.abrirBt.TabIndex = 7;
            this.abrirBt.Text = "Abrir Libro";
            this.abrirBt.UseVisualStyleBackColor = true;
            this.abrirBt.Click += new System.EventHandler(this.abrirBt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Libro(s) Encontrados:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Metadato relacionado al libro que desea buscar: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(324, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 31);
            this.label3.TabIndex = 12;
            this.label3.Text = "saSEARCH";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}

