
namespace FrmFestival
{
    partial class FrmIngresarEntrada
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
            this.cmbFestival = new System.Windows.Forms.ComboBox();
            this.txtNroFilaButaca = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cmbEntrada = new System.Windows.Forms.ComboBox();
            this.radioConsumicion = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregarEntrada = new System.Windows.Forms.Button();
            this.cmbAreaCampo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbFestival
            // 
            this.cmbFestival.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFestival.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbFestival.Location = new System.Drawing.Point(21, 43);
            this.cmbFestival.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFestival.Name = "cmbFestival";
            this.cmbFestival.Size = new System.Drawing.Size(241, 31);
            this.cmbFestival.TabIndex = 2;
            // 
            // txtNroFilaButaca
            // 
            this.txtNroFilaButaca.Enabled = false;
            this.txtNroFilaButaca.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNroFilaButaca.Location = new System.Drawing.Point(21, 245);
            this.txtNroFilaButaca.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroFilaButaca.Name = "txtNroFilaButaca";
            this.txtNroFilaButaca.PlaceholderText = "Nro y Fila butaca";
            this.txtNroFilaButaca.Size = new System.Drawing.Size(241, 30);
            this.txtNroFilaButaca.TabIndex = 5;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(21, 366);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(241, 32);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cmbEntrada
            // 
            this.cmbEntrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntrada.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbEntrada.Location = new System.Drawing.Point(21, 119);
            this.cmbEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.cmbEntrada.Name = "cmbEntrada";
            this.cmbEntrada.Size = new System.Drawing.Size(241, 31);
            this.cmbEntrada.TabIndex = 7;
            this.cmbEntrada.SelectedIndexChanged += new System.EventHandler(this.cmbEntrada_SelectedIndexChanged);
            this.cmbEntrada.SelectedValueChanged += new System.EventHandler(this.cmbTipoEntrada_SelectedValueChanged);
            // 
            // radioConsumicion
            // 
            this.radioConsumicion.AutoSize = true;
            this.radioConsumicion.Location = new System.Drawing.Point(21, 280);
            this.radioConsumicion.Name = "radioConsumicion";
            this.radioConsumicion.Size = new System.Drawing.Size(115, 24);
            this.radioConsumicion.TabIndex = 8;
            this.radioConsumicion.TabStop = true;
            this.radioConsumicion.Text = "Consumicion";
            this.radioConsumicion.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre Festival";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tipo de Entrada";
            // 
            // btnAgregarEntrada
            // 
            this.btnAgregarEntrada.Location = new System.Drawing.Point(21, 319);
            this.btnAgregarEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarEntrada.Name = "btnAgregarEntrada";
            this.btnAgregarEntrada.Size = new System.Drawing.Size(241, 32);
            this.btnAgregarEntrada.TabIndex = 11;
            this.btnAgregarEntrada.Text = "Agregar Entrada";
            this.btnAgregarEntrada.UseVisualStyleBackColor = true;
            this.btnAgregarEntrada.Click += new System.EventHandler(this.btnAgregarEntrada_Click);
            // 
            // cmbAreaCampo
            // 
            this.cmbAreaCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAreaCampo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbAreaCampo.Location = new System.Drawing.Point(21, 191);
            this.cmbAreaCampo.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAreaCampo.Name = "cmbAreaCampo";
            this.cmbAreaCampo.Size = new System.Drawing.Size(241, 31);
            this.cmbAreaCampo.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Area Campo";
            // 
            // FrmIngresarEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 409);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAreaCampo);
            this.Controls.Add(this.btnAgregarEntrada);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioConsumicion);
            this.Controls.Add(this.cmbEntrada);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtNroFilaButaca);
            this.Controls.Add(this.cmbFestival);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmIngresarEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entradas";
            this.Load += new System.EventHandler(this.FrmLlamador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbFestival;
        private System.Windows.Forms.TextBox txtNroFilaButaca;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cmbEntrada;
        private System.Windows.Forms.RadioButton radioConsumicion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregarEntrada;
        private System.Windows.Forms.ComboBox cmbAreaCampo;
        private System.Windows.Forms.Label label3;
    }
}