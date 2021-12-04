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
using Entidades.Archivos;

namespace FrmCentralita
{
    public partial class FrmMenu : Form
    {
        const int PRECIO_CAMPO = 200;
        const int PRECIO_PLATEA = 500;

        private Festival festival;

        public FrmMenu() : this(new Festival("Lollapalooza"))
        {
        }
        public FrmMenu(Festival festival)
        {
            InitializeComponent();
            this.festival = festival;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void btnIngresarEntrada_Click(object sender, EventArgs e)
        {
            FrmIngresarEntrada frmMenu = new FrmIngresarEntrada(this.festival);
            frmMenu.ShowDialog();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            Entrada e1 = new Campo(Campo.EArea.VIP, PRECIO_CAMPO, true, this.festival.Nombre);
            Entrada e2 = new Campo(Campo.EArea.Frente, PRECIO_CAMPO, false, this.festival.Nombre);
            Entrada e3 = new Platea("M-19", PRECIO_PLATEA, false, this.festival.Nombre);
            Entrada e4 = new Platea("M-21", PRECIO_PLATEA, true, this.festival.Nombre);
          
            this.festival.Entradas.Add(e1);
            this.festival.Entradas.Add(e2);
            this.festival.Entradas.Add(e3);
            this.festival.Entradas.Add(e4);
        }

        private void btnEntradasPlatea_Click(object sender, EventArgs e)
        {
            FrmMostrar frmMostrar = new FrmMostrar(this.festival, Entrada.ETipo.Platea);
            frmMostrar.ShowDialog();
        }

        private void btnEntradasCampo_Click(object sender, EventArgs e)
        {
            FrmMostrar frmMostrar = new FrmMostrar(this.festival, Entrada.ETipo.Campo);
            frmMostrar.ShowDialog();
        }

        private void btnEntradasTotales_Click(object sender, EventArgs e)
        {
            FrmMostrar frmMostrar = new FrmMostrar(this.festival, Entrada.ETipo.Total);
            frmMostrar.ShowDialog();
        }

    }
}
