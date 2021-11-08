using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ArchivosException : Exception
    {
        private string nombreClase;
        private string nombreMetodo;

        public string NombreClase
        {
            get
            {
                return this.nombreClase;
            }
        }
        public string NombreMetodo
        {
            get
            {
                return this.nombreMetodo;
            }
        }

        public ArchivosException(Exception innerException) : base("No se pudo abrir el archivo", innerException)
        {

        }
        public ArchivosException(string message, string nombreClase, string nombreMetodo) : this(message, nombreClase, nombreMetodo, null)
        {
        }

        protected ArchivosException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ArchivosException(string message, string nombreClase, string nombreMetodo, Exception innerException) : base(message, innerException)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }
    }
}
