using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NombreInvalidoException : Exception
    {

        public NombreInvalidoException() : base("El nombre ingresado es invalido")
        {

        }

        public NombreInvalidoException(Exception e) : base("Nombre ingresado invalido", e)
        {

        }
        public NombreInvalidoException(string message) : base(message)
        {
        }

        public NombreInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
