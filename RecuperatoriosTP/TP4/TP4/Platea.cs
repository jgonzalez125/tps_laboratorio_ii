using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Entidades
{
    public class Platea : Entrada
    {
        private string numeroFilaButaca;
        private string archivo;

        private Platea() : base(0, false, "")
        {

        }

        public Platea(Platea entrada) : this(entrada.numeroFilaButaca, entrada.CostoEntrada, entrada.TieneConsumicion, entrada.NombreFestival)
        {

        }
        public Platea(string numeroButaca, float precio, bool tieneConsumicion, string nombreFestival) : base(precio, tieneConsumicion, nombreFestival)
        {
            this.numeroFilaButaca = numeroButaca;
        }

        public override float CostoEntrada
        {
            get
            {
                return this.CalcularCosto();
            }
            set
            {
                this.precio = value;
            }
        }

        public string NumeroFilaButaca
        {
            get
            {
                return this.numeroFilaButaca;
            }
            set
            {
                this.numeroFilaButaca = value;
            }
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Costo: {this.CostoEntrada}");
            sb.AppendLine($"Numero butaca: {this.NumeroFilaButaca}");
            return sb.ToString();
        }

        /// <summary>
        /// Calcula el precio dependiendo de si tiene consumicion o no
        /// </summary>
        /// <returns></returns>
        private float CalcularCosto()
        {
               
            return this.TieneConsumicion ? this.precio + 300 : this.precio;
        }

        public override bool Equals(object obj)
        {
            return ((Platea)obj).NumeroFilaButaca == this.NumeroFilaButaca;

        }

        public override string ToString()
        {
            return this.Mostrar();
        }

    }
}
