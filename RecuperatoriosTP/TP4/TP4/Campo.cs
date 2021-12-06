using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using Entidades.Excepciones;
using Entidades.Interfaces;

namespace Entidades
{
    public class Campo : Entrada
    {
        private string archivo;
        private EArea area;

        private Campo() : base(0, false, "")
        {
            
        }

        public Campo(Campo campo, float precio) : this(campo.Area, precio, campo.TieneConsumicion, campo.NombreFestival)
        {

        }

        public Campo(EArea area, float precio, bool tieneConsumicion, string nombreFestival) : base(precio, tieneConsumicion, nombreFestival)
        {
            this.area = area;
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

        public EArea Area
        {
            get
            {
                return this.area;
            }
            set
            {
                this.area = value;
            }
        }


        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Costo: {this.CostoEntrada}");
            return sb.ToString();
        }


        /// <summary>
        /// Calculara el costo de la entrada, si el area es VIP, se sumara la mitad del costo base a la entrada
        /// </summary>
        /// <returns>float conteniendo el costo total</returns>
        private float CalcularCosto()
        {
            return this.Area == EArea.VIP ? this.precio + (this.precio * .5f) : this.precio;
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public enum EArea
        {
            Medio,
            VIP,
            Lateral,
            Frente
        }
    }
}
