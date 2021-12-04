using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Instanciables
{
    public class Hospital
    {
        private List<Paciente> pacientes;
        private List<Medico> medicos;
        private List<Turno> turnos;

        public Hospital()
        {
            this.pacientes = new List<Paciente>();
            this.medicos = new List<Medico>();
            this.turnos = new List<Turno>();
        }

        public List<Medico> Medicos
        {
            get
            {
                return this.medicos;
            }

        }

        public List<Turno> Turnos
        {
            get
            {
                return this.turnos;
            }
            set
            {
                this.turnos = value;
            }
        }

        public string MostrarPacientes(List<Paciente> pacientes)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Paciente p in pacientes)
            {
               sb.AppendLine(p.MostrarDatos());
            }
            return sb.ToString();
        }

        public string MostrarMedicos(List<Medico> medicos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Medico m in medicos)
            {
                sb.AppendLine(m.MostrarDatos());
            }
            return sb.ToString();
        }

        public static Hospital operator +(Hospital hospital, Turno turno)
        {
            List<Turno> turnosHospital = hospital.turnos;
            foreach(Turno t in turnosHospital)
            {
                if(t == turno)
                {
                    throw new TurnoInvalidoException("El turno es invalido");
                }
            }
            hospital.turnos.Add(turno);
            return hospital;
        }

        public static bool operator ==(Hospital hospital, Paciente paciente)
        {
            foreach(Paciente p in hospital.pacientes)
            {
                if(p == paciente)
                {
                    throw new PacienteInvalidoException();
                }
            }
            return true;
        }

        public static bool operator !=(Hospital hospital, Paciente paciente)
        {
            return !(hospital == paciente);
        }

        public static Hospital operator +(Hospital hospital, Paciente paciente)
        {
            List<Paciente> pacientes = hospital.pacientes;
            foreach (Paciente p in pacientes)
            {
                if (p == paciente)
                {
                    throw new PacienteInvalidoException();
                }
            }
            hospital.pacientes.Add(paciente);
            return hospital;
        }

        public static Hospital operator +(Hospital hospital, Medico medico)
        {
            List<Medico> medicos = hospital.medicos;
            foreach (Medico m in medicos)
            {
                if (m == medico)
                {
                    throw new TurnoInvalidoException("El medico es invalido");
                }
            }
            hospital.medicos.Add(medico);
            return hospital;
        }

        public static List<Medico> ListarMedicosPorEspecialidad(List<Medico> medicos, Medico.EEspecializacion especializacion)
        {
            
            return medicos.FindAll((m) => m.Especializacion == especializacion);
        }
    }
}
