using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class TurnoInvalidoException : Exception
    {
        public TurnoInvalidoException() : base("El turno no es valido")
        {

        }

        public TurnoInvalidoException(Exception e) : base("El turno no es valido", e)
        {

        }

        public TurnoInvalidoException(string message) : base(message)
        {
        }

        public TurnoInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
