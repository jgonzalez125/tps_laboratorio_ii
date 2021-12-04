using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Entidades.Interfaces;
using Entidades.Excepciones;

namespace Entidades
{
    public class Festival 
    {
        private List<Entrada> listaDeEntradas;
        private string nombreFestival;
        private string archivo;

        public Festival(string nombreFestival) : this()
        {
            this.nombreFestival = nombreFestival;
        }

        public Festival()
        {
            this.listaDeEntradas = new List<Entrada>() { };
        }

        public float GananciaPorCampo
        {
            get
            {
                return this.CalcularGanancia(Entrada.ETipo.Campo);
            }
        }

        public string RutaDeArchivo
        {
            get
            {
                return this.archivo;
            }
            set
            {
                this.archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + value + ".txt";
            }
        }

        public float GananciaPorPlatea
        {
            get
            {
                return this.CalcularGanancia(Entrada.ETipo.Platea);
            }
        }

        public float GananciaPorTotal
        {
            get
            {
                return this.CalcularGanancia(Entrada.ETipo.Total);
            }
        }

        public List<Entrada> Entradas
        {
            get
            {
                return this.listaDeEntradas;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombreFestival;
            }
        }

        /// <summary>
        /// El método Mostrar expondrá el nombre del festival, la ganancia total, ganancia por entradas de campo
        /// y platea y la cantidad de entradas vendidas
        /// </summary>
        /// <returns></returns>
        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Razon Social: {this.nombreFestival}");
            sb.AppendLine($"Ganancia por Campo: {this.GananciaPorCampo}");
            sb.AppendLine($"Ganancia por Platea: {this.GananciaPorPlatea}");
            sb.AppendLine($"Ganancia por Total: {this.GananciaPorTotal}");
            sb.AppendLine($"Cantidad de entradas vendidas: {this.Entradas.Count}");
         
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        /// <summary>
        /// Este método recibe un Enumerado <seealso cref="Entrada.ETipo"/> y retornará 
        /// el valor de lo recaudado, según el criterio elegido(ganancias por las entradas del tipo Campo,
        /// Platea o del Total según corresponda).
        /// </summary>
        /// <returns> float conteniendo la ganancia </returns>
        private float CalcularGanancia(Entrada.ETipo tipo)
        {
            float ganancia = 0;
            foreach (Entrada l in this.listaDeEntradas)
            {
                switch (tipo)
                {
                    case Entrada.ETipo.Campo:
                        if (l is Campo)
                        {
                            ganancia += l.CostoEntrada;
                        }
                        break;
                    case Entrada.ETipo.Platea:
                        if (l is Platea)
                        {
                            ganancia += l.CostoEntrada;
                        }
                        break;
                    default:
                        ganancia += l.CostoEntrada;
                        break;
                }
            }
            return ganancia;
        }

        private void AgregarEntrada(Entrada entrada)
        {
            this.Entradas.Add(entrada);
        }


        public static bool operator ==(Festival c, Entrada entrada)
        {
            foreach(Entrada l in c.Entradas)
            {
                if (entrada == l)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Festival c, Entrada entrada)
        {
            return !(c == entrada);
        }

        public static Festival operator +(Festival c, Entrada entrada)
        {
            if(c != entrada)
            {
                c.AgregarEntrada(entrada);
            }
            else
            {
                throw new FestivalException("Esta entrada ya existe", "Festival", "+");
            }

            return c;
        }
    }
}
