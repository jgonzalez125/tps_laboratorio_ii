using System;
using System.Collections.Generic;
using Entidades;
using System.Data.SqlClient;
using System.Threading;


namespace EntidadesDAO
{
    public class PlateaDAO : IBaseDeDatos<List<Platea>, Platea>
    {
        
        private string connectionString;
        private SqlConnection conexion;
        private SqlDataReader lector;
        private SqlCommand comando;
        public event BaseDeDatosDelegate EventoBaseDeDatos;

        public PlateaDAO()
        {
            this.connectionString = @"Data Source=.\SQLEXPRESS01;Database=master;Integrated Security=True";
            this.conexion = new SqlConnection(this.connectionString);
        }

        public string RutaDeConexion
        {
            get
            {
                return this.connectionString;
            }
            set
            {
                this.connectionString = value;
            }
        }


        public SqlConnection Conexion
        {
            get
            {
                return this.conexion;
            }
            set
            {
                this.conexion = value;
            }
        }

        public SqlDataReader LectorDeDatos
        {
            get
            {
                return this.lector;
            }
            set
            {
                this.lector = value;
            }
        }

        public SqlCommand Comando
        {
            get
            {
                return this.comando;
            }
            set
            {
                this.comando = value;
            }
        }

        /// <summary>
        /// Obtiene las entradas de tipo platea correspondientes
        /// </summary>
        /// <returns></returns>
        public List<Platea> Leer()
        {
            List<Platea> entradasPlatea = new List<Platea>() { };

            this.Comando = new SqlCommand();
            this.Comando.Connection = this.Conexion;
            this.Comando.CommandType = System.Data.CommandType.Text;
            this.Comando.CommandText = "SELECT * FROM Entradas WHERE tipo=1";

            if (this.Conexion.State != System.Data.ConnectionState.Open)
            {
                this.Conexion.Open();
            }

            this.LectorDeDatos = this.Comando.ExecuteReader();
            while (this.LectorDeDatos.Read())
            {
                if (LectorDeDatos["tipo"].ToString() == "1")
                {
                    Platea auxPlatea;
                    float.TryParse(LectorDeDatos["costo"].ToString(), out float costo);
                    auxPlatea = new Platea(LectorDeDatos["numeroButaca"].ToString(), costo, LectorDeDatos["numeroButaca"].Equals(true), LectorDeDatos["festival"].ToString());
                    entradasPlatea.Add(auxPlatea);
                }
            }

            if (this.Conexion.State != System.Data.ConnectionState.Closed)
            {
                this.Conexion.Close();
            }
            return entradasPlatea;
        }

        /// <summary>
        /// Guarda la platea en base de datos con la query correspondiente
        /// </summary>
        /// <param name="platea"></param>
        public void Guardar(Platea platea)
        {
            this.Comando = new SqlCommand();
            this.Comando.Connection = this.Conexion;
            this.Comando.CommandType = System.Data.CommandType.Text;
            this.Comando.CommandText = "INSERT INTO Entradas values(@costo,@consumicion,@festival,@numeroButaca,@areaCampo, @tipo)";
            if (this.Conexion.State != System.Data.ConnectionState.Open)
            {
                this.Conexion.Open();
            }
            this.Comando.Parameters.AddWithValue("@costo", platea.CostoEntrada);
            this.Comando.Parameters.Add(new SqlParameter("consumicion", platea.TieneConsumicion));
            this.Comando.Parameters.Add(new SqlParameter("festival", platea.NombreFestival));
            this.Comando.Parameters.Add(new SqlParameter("numeroButaca", platea.NumeroFilaButaca));
            this.Comando.Parameters.Add(new SqlParameter("areaCampo", DBNull.Value));
            this.Comando.Parameters.AddWithValue("@tipo", 1);
            int cantidadInsertados = this.comando.ExecuteNonQuery();

            Console.WriteLine(cantidadInsertados);
            if (this.Conexion.State != System.Data.ConnectionState.Closed)
            {
                this.Conexion.Close();
            }
        }

        /// <summary>
        /// Invoca al evento
        /// </summary>
        /// <param name="cancellationToken"></param>
        public void CorrerTask(CancellationToken cancellationToken)
        {
            if(this.EventoBaseDeDatos is not null && !cancellationToken.IsCancellationRequested) 
            { 
                this.EventoBaseDeDatos.Invoke();
            }
        }
    }
}
