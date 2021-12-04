using System;
using System.Text;
using Entidades.Interfaces;
using System.Collections.Generic;

namespace Entidades
{
    [Serializable]
    abstract public class Entrada 
    {
        protected float precio;
        private bool tieneConsumicion;
        private string nombreFestival;

        public Entrada() : this(0, true, "")
        {

        }
        public Entrada(float precio, bool tieneConsumicion, string nombreFestival)
        {
            this.precio = precio;
            this.tieneConsumicion = tieneConsumicion;
            this.nombreFestival = nombreFestival;
        }

        public bool TieneConsumicion
        {
            get
            {
                return this.tieneConsumicion;
            }
            set
            {
                this.tieneConsumicion = value;
            }
        }

        public string NombreFestival
        {
            get
            {
                return this.nombreFestival;
            }
            set
            {
                this.nombreFestival = value;
            }
        }

        abstract public float CostoEntrada { get; set; }

        public enum ETipo
        {
            Campo,
            Platea,
            Total
        }

        /// <summary>
        /// Mostrar mostrara los datos de la Clase base utilizando StringBuilder
        /// </summary>
        /// <returns></returns>
        protected virtual string Mostrar()
        {
            string consumicion = this.TieneConsumicion ? "si" : "no";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre festival: {this.NombreFestival}");
            sb.AppendLine($"Tiene consumicion: {consumicion}");
            return sb.ToString();
        }

        public static bool operator ==(Entrada e1, Entrada e2)
        {
            return e1.Equals(e2);
        }

        public static bool operator !=(Entrada e1, Entrada e2)
        {
            return !(e1 == e2);
        }
    }
}
