using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using Abstractas;

namespace Instanciables
{
    public class Medico : Persona
    {
        private string matricula;
        private EEspecializacion especializacion;

        public Medico() : base("", "")
        {
            
        }
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

        public override string ToString()
        {
            return $"{this.Nombre} {this.Apellido} {this.Matricula}";
        }

        public override bool Guardar()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "Medico.xml";

            bool aux = false;
            using (XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                XmlSerializer serializer = new XmlSerializer(typeof(Medico));
                Medico medico = new Medico();
                medico.Nombre = this.Nombre;
                medico.Apellido = this.Apellido;
                medico.Matricula = this.Matricula;
                serializer.Serialize(writer, medico);
                aux = true;
            }
            return aux;
        }
        public override Paciente Leer()
        {
            XmlTextReader reader = null;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "Paciente.xml";

            try
            {
                using (reader = new XmlTextReader(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Paciente));
                    Paciente datos = (Paciente)serializer.Deserialize(reader);
                    return datos;
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
