using System;
using System.Text;
using Abstractas;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Instanciables
{
    public class Paciente : Persona
    {
        private string dni;
        private ECobertura coberturaMedica;
        
        public Paciente() : base("", "")
        {

        }

        public Paciente(string nombre, string apellido, string dni, ECobertura coberturaMedica) 
            : base(nombre, apellido)
        {
            this.Dni = dni;
            this.CoberturaMedica = coberturaMedica;
        }

        public Paciente(string nombre, string apellido, string dni)
            : this(nombre, apellido, dni, ECobertura.Particular)
        {

        }

        public string Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(value).ToString();
            }
        }

        public ECobertura CoberturaMedica
        {
            get
            {
                return this.coberturaMedica;
            }
            set
            {
                this.coberturaMedica = value;
            }
        }

        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Paciente:");
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"DNI: {this.Dni}");
            sb.AppendLine($"Cobertura: {this.CoberturaMedica}");
            return sb.ToString();
        }

        private int ValidarDni(string dni)
        {
            int.TryParse(dni, out int dniParseado);
            if (dniParseado >= 1000000 && dniParseado <= 99999999)
            {
                return dniParseado;
            }
            else
            {
                throw new DNIInvalidoException();
            }
        }

        public static bool operator ==(Paciente p1, Paciente p2)
        {
            return p1.dni == p2.dni;
        }

        public static bool operator !=(Paciente p1, Paciente p2)
        {
            return !(p1 == p2);
        }

        public enum ECobertura
        {
            OSDE,
            Galeno,
            SwissMedical,
            Osmecon,
            Particular
        }

        public override bool Guardar()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "Paciente.xml";
            bool aux = false;
            using (XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                XmlSerializer serializer = new XmlSerializer(typeof(Paciente));
                Paciente paciente = new Paciente();
                paciente.Nombre = this.Nombre;
                paciente.Apellido = this.Apellido;
                paciente.CoberturaMedica = this.CoberturaMedica;
                paciente.Dni = this.Dni;
                serializer.Serialize(writer, paciente);
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
