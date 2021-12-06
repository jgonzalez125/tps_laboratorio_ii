using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;


namespace EntidadesDAO
{
    public delegate void BaseDeDatosDelegate();
    public interface IBaseDeDatos<T, U>
    {
        string RutaDeConexion
        {
            get;
            set;
        }
        
        SqlConnection Conexion
        {
            get;
            set;
        }

        SqlDataReader LectorDeDatos
        {
            get;
            set;
        }

        SqlCommand Comando
        {
            get;
            set;
        }
        T Leer();

        void Guardar(U tipo);
        void CorrerTask(CancellationToken token);
    }
}
