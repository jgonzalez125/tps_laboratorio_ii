using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class DNIInvalidoException : Exception
    {
        public DNIInvalidoException() : base("DNI ingresado invalido")
        {

        }

        public DNIInvalidoException(Exception e) : base("DNI ingresado invalido", e)
        {

        }

        public DNIInvalidoException(string message) : base(message)
        {

        }

        public DNIInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
