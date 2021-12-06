using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Entidades;
using EntidadesDAO;

namespace FrmFestival
{
    public partial class FrmIngresarEntrada : Form
    {
        const int PRECIO_CAMPO = 200;
        const int PRECIO_PLATEA = 500;

        private CancellationTokenSource cancellationTokenSource;
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


        /// <summary>
        /// Se encarga de cargar todos los datos preseteados al formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancellationTokenSource.Cancel();
            this.Close();
        }


        /// <summary>
        /// Agrega la entrada a la BDD y a la instancia de festival
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarEntrada_Click(object sender, EventArgs e)
        {
            Task tarea = null;
            if (this.cmbFestival.Text == "" || this.cmbEntrada.Text == "" || 
                (this.cmbEntrada.Text == "Campo" && this.cmbAreaCampo.Text == "") ||
                (this.cmbEntrada.Text == "Platea" && this.txtNroFilaButaca.Text == ""))
            {
                MessageBox.Show("Ingrese todos los campos correspondientes");
            }
            else 
            {
                switch (this.cmbEntrada.Text)
                {
                    case "Campo":
                        Campo campo = new Campo((Campo.EArea)this.cmbAreaCampo.SelectedItem, PRECIO_CAMPO, this.radioConsumicion.Checked, this.festival.Nombre);
                        CampoDAO campoDAO = new CampoDAO();
                        tarea = Task.Run(() => campoDAO.Guardar(campo));

                        this.festival.Entradas.Add(campo);
                        break;
                    case "Platea":
                        Platea platea = new Platea(this.txtNroFilaButaca.Text, PRECIO_PLATEA, radioConsumicion.Checked, this.festival.Nombre);
                        PlateaDAO plateaDAO = new PlateaDAO();
                        tarea = Task.Run(() => plateaDAO.Guardar(platea));

                        this.festival.Entradas.Add(platea);
                        break;
                }
                 MessageBox.Show("Entrada agregada exitosamente");
            }
        }

        private void cmbEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Activa/Desactiva los campos dependiendo de la opcion seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
