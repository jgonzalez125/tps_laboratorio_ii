using System;
using System.Text;
using Excepciones;
using Abstractas.Interfaces;

namespace Abstractas
{
    public abstract class Persona : IGuardar<Persona>
    {
        string nombre;
        string apellido;
        
        public Persona(string nombre, string apellido)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get
            { 
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        abstract public bool Guardar();
        abstract public Persona Leer();


        private static string ValidarNombreApellido(string a)
        {
            if (string.IsNullOrWhiteSpace(a))
            {
                throw new NombreInvalidoException();
            }
            char[] cadenaCaracteres = a.ToLower().ToCharArray();

            for (int i = 0; i < cadenaCaracteres.Length; i++)
            {
                if ((cadenaCaracteres[i] < 'a' || cadenaCaracteres[i] > 'z') && cadenaCaracteres[i] != ' ')
                {
                    throw new NombreInvalidoException();
                }

            }
            return a;
        }

        public virtual string MostrarDatos() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre Completo: {this.Nombre} {this.Apellido}");

            return sb.ToString();
        }
    }
}
