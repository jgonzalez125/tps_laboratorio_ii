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
using Archivos;

namespace FrmHospital
{
    public partial class FrmTurnos : Form
    {
        private Hospital hospital;

        public FrmTurnos()
        {
            this.hospital = new Hospital();
            InitializeComponent();
        }

        private void FrmTurnos_Load(object sender, EventArgs e)
        {
            this.hospital.Medicos.Add(new Medico("Juan", "Perez", "MN2345", Medico.EEspecializacion.Cardiologia));
            Xml<Medico> xmlMedicos = new Xml<Medico>();
            xmlMedicos.Guardar("medicos.xml", new Medico("Juan", "Perez", "MN2345", Medico.EEspecializacion.Cardiologia));
        }
    }
}
