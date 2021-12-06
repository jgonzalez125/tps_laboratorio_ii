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
    public partial class FrmMenu : Form
    {
        const int PRECIO_CAMPO = 200;
        const int PRECIO_PLATEA = 500;

        private Festival festival;
        private PlateaDAO plateaDAO;
        private CampoDAO campoDAO;
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;

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
        }

        private void btnEntradasPlatea_Click(object sender, EventArgs e)
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancellationToken = this.cancellationTokenSource.Token;
            this.plateaDAO = new PlateaDAO();
            this.plateaDAO.EventoBaseDeDatos += this.SetPlateas;

            this.plateaDAO.CorrerTask(this.cancellationToken);

            FrmMostrar frmMostrar = new FrmMostrar(this.festival, Entrada.ETipo.Platea);
            frmMostrar.ShowDialog();
        }

        private void btnEntradasCampo_Click(object sender, EventArgs e)
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancellationToken = this.cancellationTokenSource.Token;
            this.campoDAO = new CampoDAO();
            this.campoDAO.EventoBaseDeDatos += this.SetCampo;

            this.campoDAO.CorrerTask(this.cancellationToken);

            FrmMostrar frmMostrar = new FrmMostrar(this.festival, Entrada.ETipo.Campo);
            frmMostrar.ShowDialog();
        }

        private void btnEntradasTotales_Click(object sender, EventArgs e)
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancellationToken = this.cancellationTokenSource.Token;
            this.plateaDAO = new PlateaDAO();
            this.plateaDAO.EventoBaseDeDatos += this.SetPlateas;
            this.campoDAO = new CampoDAO();
            this.campoDAO.EventoBaseDeDatos += this.SetCampo;

            this.campoDAO.CorrerTask(this.cancellationToken);

            this.plateaDAO.CorrerTask(this.cancellationToken);

            FrmMostrar frmMostrar = new FrmMostrar(this.festival, Entrada.ETipo.Total);
            frmMostrar.ShowDialog();
        }

        private void SetPlateas()
        {
            Task<List<Platea>> tarea = Task<List<Platea>>.Factory.StartNew(() => this.plateaDAO.Leer());

            foreach (Entrada e in tarea.Result)
            {
                this.festival.Entradas.Add(e);
            }
        }

        private void SetCampo()
        {
            Task<List<Campo>> tarea = Task<List<Campo>>.Factory.StartNew(() => this.campoDAO.Leer());

            foreach (Entrada e in tarea.Result)
            {
                this.festival.Entradas.Add(e);
            }
        }
    }
}
