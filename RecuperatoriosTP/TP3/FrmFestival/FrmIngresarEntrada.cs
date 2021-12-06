using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmFestival
{
    public partial class FrmIngresarEntrada : Form
    {
        const int PRECIO_CAMPO = 200;
        const int PRECIO_PLATEA = 500;

        private Festival festival;
        public FrmIngresarEntrada()
        {
            InitializeComponent();
        }

        public FrmIngresarEntrada(Festival festival)
        {
            InitializeComponent();
            this.festival = festival;
        }

        public Festival Festival
        {
            get
            {
                return this.festival;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void FrmLlamador_Load(object sender, EventArgs e)
        {
            // Carga
            cmbAreaCampo.DataSource = Enum.GetValues(typeof(Campo.EArea));
            cmbEntrada.Items.Add("Campo");
            cmbEntrada.Items.Add("Platea");
            cmbFestival.Items.Add(this.festival.Nombre);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnAgregarEntrada_Click(object sender, EventArgs e)
        {
            if (this.cmbFestival.Text == "" || this.cmbEntrada.Text == "" || 
                (this.cmbEntrada.Text == "Campo" && this.cmbAreaCampo.Text == "") ||
                (this.cmbEntrada.Text == "Platea" && this.txtNroFilaButaca.Text == ""))
            {
                MessageBox.Show("Ingrese todos los campos correspondientes");
            }
            else { 
                switch (this.cmbEntrada.Text)
                {
                    case "Campo":
                        this.festival.Entradas.Add(new Campo((Campo.EArea)this.cmbAreaCampo.SelectedItem, PRECIO_CAMPO, this.radioConsumicion.Checked, this.festival.Nombre));
                        break;
                    case "Platea":
                        this.festival.Entradas.Add(new Platea(this.txtNroFilaButaca.Text, PRECIO_PLATEA, radioConsumicion.Checked, this.festival.Nombre));
                        break;
                }
                MessageBox.Show("Entrada agregada exitosamente");
            }
        }

        private void cmbEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbTipoEntrada_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (this.cmbEntrada.Text)
            {
                case "Campo":
                    this.txtNroFilaButaca.Enabled = false;
                    this.cmbAreaCampo.Enabled = true;
                    break;
                case "Platea":
                    this.cmbAreaCampo.Enabled = false;
                    this.txtNroFilaButaca.Enabled = true;

                    break;
            }
        }
    }
}
