using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Instanciables;
using Excepciones;
using Archivos;

namespace FrmTurnos
{
    public partial class Form1 : Form
    {
        private Hospital hospital;
        public Form1()
        {
            InitializeComponent();
            this.hospital = new Hospital();
        }

        private void btnAgregarTurno_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(cmbCobertura.Text) ||
                string.IsNullOrWhiteSpace(cmbEspecializacion.Text) ||
                string.IsNullOrWhiteSpace(cmbMedico.Text) ||
                string.IsNullOrWhiteSpace(dateTimeTurno.Text))
            {
                MessageBox.Show($"Debe ingresar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try 
                { 
                    Paciente p = new Paciente(txtNombre.Text, txtApellido.Text, txtDni.Text);
                    Medico m = this.hospital.Medicos.Find((m) => m.Equals(this.cmbMedico.Text));
                    Turno t = new Turno(p, m, dateTimeTurno.Value);
                    this.hospital += t;
                    this.lstUltimosTurnos.Items.Add(t.ToString());
                    this.Refrescar();
                }
                catch (NombreInvalidoException)
                {
                    MessageBox.Show($"El nombre es invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (PacienteInvalidoException)
                {
                    MessageBox.Show($"El paciente es invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (DNIInvalidoException)
                {
                    MessageBox.Show($"El DNI es invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (TurnoInvalidoException)
                {
                    MessageBox.Show($"El turno es invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

       
        private void Refrescar()
        {
            this.txtDni.Clear();
            this.txtNombre.Clear();
            this.txtApellido.Clear();
            this.cmbCobertura.Text = "";
            this.cmbEspecializacion.Text = "";
            this.cmbMedico.Text = "";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool resultado = false;
            Texto archivo = new Texto();
            foreach(Turno t in this.hospital.Turnos)
            {
                
                if (archivo.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "Turnos.txt", t.ToString()))
                {
                    resultado = true;
                }
            }
            if(resultado)
            {
                MessageBox.Show($"Archivo guardado exitosamente", "Exito", MessageBoxButtons.OK);
            }
        }

        private void cmbEspecializacion_SelectedValueChanged(object sender, EventArgs e)
        {
            List<Medico> medicos = Hospital.ListarMedicosPorEspecialidad(this.hospital.Medicos, (Medico.EEspecializacion)cmbEspecializacion.SelectedItem);
            this.cmbMedico.Items.Clear();
            foreach (Medico m in medicos)
            {
                this.cmbMedico.Items.Add($"{m.Nombre} {m.Apellido} {m.Matricula}");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.hospital += new Medico("Facundo", "Conte", "MN1002", Medico.EEspecializacion.Cardiologia);
            this.hospital += new Medico("Santiago", "Danani", "MN1234", Medico.EEspecializacion.Cardiologia);
            this.hospital += new Medico("Luciano", "De Cecco", "MN4515", Medico.EEspecializacion.Cardiologia);
            this.hospital += new Medico("Bruno", "Lima", "MN4515", Medico.EEspecializacion.Dermatologia);
            this.hospital += new Medico("Jan", "Martinez", "MN4516", Medico.EEspecializacion.Endocrinologia);
            this.hospital += new Medico("Matias", "Giraudo", "MN4555", Medico.EEspecializacion.Endocrinologia);
            this.hospital += new Medico("Marcelo", "Mendez", "MN6535", Medico.EEspecializacion.Neurologia);
            this.hospital += new Medico("Alejandro", "Gonzalez", "MN100000", Medico.EEspecializacion.Pediatria);
            this.hospital += new Medico("Alessandro", "Michieletto", "MN5490", Medico.EEspecializacion.Pediatria);
            this.hospital += new Medico("Agustin", "Loser", "MN10200", Medico.EEspecializacion.Traumatologia);
            this.hospital += new Medico("Julio", "Velasco", "MN10220", Medico.EEspecializacion.Gastroenterologia);
            foreach (Medico m in this.hospital.Medicos)
            {
                this.cmbMedico.Items.Add($"{m.Nombre} {m.Apellido} {m.Matricula}");
            }
            this.cmbEspecializacion.Items.Add(Medico.EEspecializacion.Cardiologia);
            this.cmbEspecializacion.Items.Add(Medico.EEspecializacion.Dermatologia);
            this.cmbEspecializacion.Items.Add(Medico.EEspecializacion.Endocrinologia);
            this.cmbEspecializacion.Items.Add(Medico.EEspecializacion.Gastroenterologia);
            this.cmbEspecializacion.Items.Add(Medico.EEspecializacion.Neurologia);
            this.cmbEspecializacion.Items.Add(Medico.EEspecializacion.Pediatria);
            this.cmbEspecializacion.Items.Add(Medico.EEspecializacion.Traumatologia);
            this.cmbCobertura.Items.Add(Paciente.ECobertura.Galeno);
            this.cmbCobertura.Items.Add(Paciente.ECobertura.OSDE);
            this.cmbCobertura.Items.Add(Paciente.ECobertura.Osmecon);
            this.cmbCobertura.Items.Add(Paciente.ECobertura.SwissMedical);
            this.cmbCobertura.Items.Add(Paciente.ECobertura.Particular);
        }
    }
}
