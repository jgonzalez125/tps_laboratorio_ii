
namespace FrmFestival
{
    partial class FrmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIngresarEntrada = new System.Windows.Forms.Button();
            this.btnEntradasTotales = new System.Windows.Forms.Button();
            this.btnEntradasCampo = new System.Windows.Forms.Button();
            this.btnEntradasPlatea = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIngresarEntrada
            // 
            this.btnIngresarEntrada.Location = new System.Drawing.Point(10, 10);
            this.btnIngresarEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.btnIngresarEntrada.Name = "btnIngresarEntrada";
            this.btnIngresarEntrada.Size = new System.Drawing.Size(392, 67);
            this.btnIngresarEntrada.TabIndex = 0;
            this.btnIngresarEntrada.Text = "Ingresar Entrada";
            this.btnIngresarEntrada.UseVisualStyleBackColor = true;
            this.btnIngresarEntrada.Click += new System.EventHandler(this.btnIngresarEntrada_Click);
            // 
            // btnEntradasTotales
            // 
            this.btnEntradasTotales.Location = new System.Drawing.Point(10, 94);
            this.btnEntradasTotales.Margin = new System.Windows.Forms.Padding(2);
            this.btnEntradasTotales.Name = "btnEntradasTotales";
            this.btnEntradasTotales.Size = new System.Drawing.Size(392, 67);
            this.btnEntradasTotales.TabIndex = 1;
            this.btnEntradasTotales.Text = "Mostrar todas las entradas";
            this.btnEntradasTotales.UseVisualStyleBackColor = true;
            this.btnEntradasTotales.Click += new System.EventHandler(this.btnEntradasTotales_Click);
            // 
            // btnEntradasCampo
            // 
            this.btnEntradasCampo.Location = new System.Drawing.Point(10, 180);
            this.btnEntradasCampo.Margin = new System.Windows.Forms.Padding(2);
            this.btnEntradasCampo.Name = "btnEntradasCampo";
            this.btnEntradasCampo.Size = new System.Drawing.Size(392, 67);
            this.btnEntradasCampo.TabIndex = 2;
            this.btnEntradasCampo.Text = "Mostrar entradas de Campo";
            this.btnEntradasCampo.UseVisualStyleBackColor = true;
            this.btnEntradasCampo.Click += new System.EventHandler(this.btnEntradasCampo_Click);
            // 
            // btnEntradasPlatea
            // 
            this.btnEntradasPlatea.Location = new System.Drawing.Point(11, 265);
            this.btnEntradasPlatea.Margin = new System.Windows.Forms.Padding(2);
            this.btnEntradasPlatea.Name = "btnEntradasPlatea";
            this.btnEntradasPlatea.Size = new System.Drawing.Size(392, 67);
            this.btnEntradasPlatea.TabIndex = 3;
            this.btnEntradasPlatea.Text = "Mostrar entradas de Platea";
            this.btnEntradasPlatea.UseVisualStyleBackColor = true;
            this.btnEntradasPlatea.Click += new System.EventHandler(this.btnEntradasPlatea_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(11, 349);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(392, 67);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 430);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEntradasPlatea);
            this.Controls.Add(this.btnEntradasCampo);
            this.Controls.Add(this.btnEntradasTotales);
            this.Controls.Add(this.btnIngresarEntrada);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de venta de entradas";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIngresarEntrada;
        private System.Windows.Forms.Button btnEntradasTotales;
        private System.Windows.Forms.Button btnEntradasCampo;
        private System.Windows.Forms.Button btnEntradasPlatea;
        private System.Windows.Forms.Button btnSalir;
    }
}

