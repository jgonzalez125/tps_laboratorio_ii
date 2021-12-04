using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instanciables
{
    public class Turno
    {
        private Paciente paciente;
        private Paciente medico;
        private DateTime fecha;

        public Turno(Paciente paciente, Paciente medico, DateTime fecha)
        {
            this.paciente = paciente;
            this.medico = medico;
            this.fecha = fecha;
        }

        public Paciente Paciente
        {
            get
            {
                return this.paciente;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
        }

        public static bool operator ==(Turno turno, Turno turno2)
        {
            return turno.fecha == turno2.fecha && turno.medico == turno2.medico && turno.paciente == turno2.paciente;
        }

        public static bool operator !=(Turno turno, Turno turno2)
        {
            return !(turno == turno2);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Turno:");
            sb.AppendLine($"{this.Fecha}");
            sb.AppendLine(this.Paciente.MostrarDatos());
            return sb.ToString();
        }
    }
}
