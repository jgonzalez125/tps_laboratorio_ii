using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractas;

namespace Instanciables
{
    public class Medico : Persona
    {
        private string matricula;
        private EEspecializacion especializacion;

        public Medico(string nombre, string apellido, string matricula, EEspecializacion especializacion) 
            : base(nombre, apellido)
        {
            this.matricula = matricula;
            this.especializacion = especializacion;
        }

        public string Matricula
        {
            get
            {
                return this.matricula;
            }
            set
            {
                this.matricula = value;
            }
        }

        public override bool Equals(object obj)
        {
            return $"{this.Nombre} {this.Apellido} {this.Matricula}" == (string)obj;
        }

        public EEspecializacion Especializacion
        {
            get
            {
                return this.especializacion;
            }
            set
            {
                this.especializacion = value;
            }
        }
        public enum EEspecializacion
        {
            Cardiologia,
            Neurologia,
            Traumatologia,
            Pediatria,
            Gastroenterologia,
            Endocrinologia,
            Dermatologia
        }

        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Medico:");
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"Matricula: {this.Matricula}");
            sb.AppendLine($"Especializacion: {this.Especializacion}");
            return sb.ToString();
        }

    }
}
