using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;


        /// <summary>
        /// Constructor que inicializa en 0 a numero
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Setter Numero, setea el valor una vez que este validado
        /// </summary>
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string numero)
        {
            this.Numero = numero;
        }
        public static string DecimalBinario(double numero)
        {
            return Convert.ToString((int)numero, 2);
        }
        public static string DecimalBinario(string numero)
        {
            try
            {
                return DecimalBinario(Convert.ToInt32(numero));
            }
            catch (OverflowException)
            {
                return "Limite excedido";
            }
            catch (FormatException)
            {
                return "El valor no es valido";
            }
        }

        public static string BinarioDecimal(string binario)
        {
            if (Operando.EsBinario(binario))
            {
                return Convert.ToInt32(binario, 2).ToString();
            }
            return "Valor Invalido";

        }

        /// <summary>
        /// Metodo que valida que el string ingresado por el usuario sea de 
        /// caracteres numericos
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns> <paramref name="strNumero"/> en formato double si pudo parsear,
        /// caso contrario 0</returns>
        private static double ValidarOperando(string strNumero)
        {
            double.TryParse(strNumero, out double auxNumero);
            return auxNumero;
        }

        private static bool EsBinario(string binario)
        {
            char[] cadena = binario.ToCharArray();
            bool retorno = false;
            for (int i = 0; i < binario.Length; i++)
            {
                 retorno = cadena[i] == '0' || cadena[i] == '1';
            }
            return retorno;
        }

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator /(Operando n1, Operando n2)
        {
            return n2.numero == 0 ? double.MinValue : n1.numero / n2.numero;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
    }
}
