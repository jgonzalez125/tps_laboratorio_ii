using System;
using System.Collections.Generic;
using Entidades;
using System.Data.SqlClient;
using System.Threading;


namespace EntidadesDAO
{
    public class CampoDAO : IBaseDeDatos<List<Campo>, Campo>
    {
        private string connectionString;
        private SqlConnection conexion;
        private SqlDataReader lector;
        public event BaseDeDatosDelegate EventoBaseDeDatos;
        private SqlCommand comando;

        public CampoDAO()
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

        public List<Campo> Leer()
        {
            List<Campo> entradasCampo = new List<Campo>() { };
           
            this.Comando = new SqlCommand();
            this.Comando.Connection = this.Conexion;
            this.Comando.CommandType = System.Data.CommandType.Text;
            this.Comando.CommandText = "SELECT * FROM Entradas WHERE tipo=0";

            if(this.Conexion.State != System.Data.ConnectionState.Open)
            {
                this.Conexion.Open();
            }

            this.LectorDeDatos = this.Comando.ExecuteReader();
            while (this.LectorDeDatos.Read())
            {
                if (LectorDeDatos["tipo"].ToString() == "0")
                {
                    Campo auxCampo;
                    float.TryParse(LectorDeDatos["costo"].ToString(), out float costo);
                    Campo.EArea area = (Campo.EArea)Enum.Parse(typeof(Campo.EArea), LectorDeDatos["areaCampo"].ToString());
                    auxCampo = new Campo(area, costo, LectorDeDatos["consumicion"].Equals(true), LectorDeDatos["festival"].ToString());
                    entradasCampo.Add(auxCampo);
                }
            }

            if(this.Conexion.State != System.Data.ConnectionState.Closed)
            {
                this.Conexion.Close();
            }
            return entradasCampo;
        }

        public void Guardar(Campo campo)
        {
            this.Comando = new SqlCommand();
            this.Comando.Connection = this.Conexion;
            this.Comando.CommandType = System.Data.CommandType.Text;
            this.Comando.CommandText = "INSERT INTO Entradas values(@costo,@consumicion,@festival,@numeroButaca,@areaCampo, @tipo)";
            if (this.Conexion.State != System.Data.ConnectionState.Open)
            {
                this.Conexion.Open();
            }
            this.Comando.Parameters.AddWithValue("@costo", campo.CostoEntrada);
            this.Comando.Parameters.Add(new SqlParameter("consumicion", campo.TieneConsumicion));
            this.Comando.Parameters.Add(new SqlParameter("festival", campo.NombreFestival));
            this.Comando.Parameters.Add(new SqlParameter("numeroButaca", DBNull.Value));
            this.Comando.Parameters.Add(new SqlParameter("areaCampo", campo.Area.ToString()));
            this.Comando.Parameters.AddWithValue("@tipo", 0);
            int cantidadInsertados = this.comando.ExecuteNonQuery();

            Console.WriteLine(cantidadInsertados);
            if (this.Conexion.State != System.Data.ConnectionState.Closed)
            {
                this.Conexion.Close();
            }
        }

        public void CorrerTask(CancellationToken cancellationToken)
        {
            if (this.EventoBaseDeDatos is not null && !cancellationToken.IsCancellationRequested)
            {
                this.EventoBaseDeDatos.Invoke();
            }
        }

    }
}
