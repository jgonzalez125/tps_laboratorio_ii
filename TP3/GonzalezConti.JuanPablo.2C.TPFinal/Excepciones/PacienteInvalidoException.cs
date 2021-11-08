using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class PacienteInvalidoException : Exception
    {
        public PacienteInvalidoException() : base("El paciente ingresado no es valido")
        {

        }

        public PacienteInvalidoException(Exception e) : base("El paciente ingresado no es valido", e)
        {

        }

        public PacienteInvalidoException(string message) : base(message)
        {
        }

        public PacienteInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
