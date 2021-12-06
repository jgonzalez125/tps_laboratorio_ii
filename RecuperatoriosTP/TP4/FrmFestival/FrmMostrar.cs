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
using Entidades.Excepciones;
using Entidades.Archivos;

namespace FrmFestival
{
    public partial class FrmMostrar : Form
    {
        private Festival festival;
        private Entrada.ETipo tipoEntrada;
        public FrmMostrar(Festival festival, Entrada.ETipo tipoEntrada)
        {
            InitializeComponent();
            this.festival = festival;
            this.tipoEntrada = tipoEntrada;
        }


        private void FrmMostrar_Load(object sender, EventArgs e)
        {
            foreach (Entrada entrada in festival.Entradas)
            {
                switch (this.tipoEntrada)
                {
                    case Entrada.ETipo.Campo:
                        if (entrada is Campo)
                        {
                            this.txtEntradas.AppendText(entrada.ToString() + "\n");
                        }
                        break;
                    case Entrada.ETipo.Platea:
                        if (entrada is Platea)
                        {
                            this.txtEntradas.AppendText(entrada.ToString() + "\n");
                        }
                        break;
                    default:
                        this.txtEntradas.AppendText(entrada.ToString() + "\n");
                        break;
                }
            }
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            JsonManager<Entrada> jsonManager = new JsonManager<Entrada>();
            foreach (Entrada entrada in festival.Entradas)
            {
                switch (this.tipoEntrada)
                {
                    case Entrada.ETipo.Campo:
                        if (entrada is Campo)
                        {
                            try
                            {
                                jsonManager.Guardar(entrada);
                            }
                            catch(ArchivosException)
                            {
                                MessageBox.Show("Error al guardar la entrada campo", "Error", MessageBoxButtons.OK);
                            }
                        }
                        break;
                    case Entrada.ETipo.Platea:
                        try
                        {
                            jsonManager.Guardar(entrada);

                        }
                        catch (ArchivosException)
                        {
                            MessageBox.Show("Error al guardar la entrada platea", "Error", MessageBoxButtons.OK);
                        }
                        break;
                    default:
                        try
                        {
                            jsonManager.Guardar(entrada);
                        }
                        catch (ArchivosException)
                        {
                            MessageBox.Show("Error al guardar la entrada", "Error", MessageBoxButtons.OK);
                        }
                        break;
                }
            }
            MessageBox.Show("Archivo guardado exitosamente", "Info", MessageBoxButtons.OK);
        }




        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
