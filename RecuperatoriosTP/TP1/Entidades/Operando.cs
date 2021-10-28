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
        /// Constructor que inicializa en 0 a numero reutilizando 
        /// el constructor que toma valor por parametro
        /// </summary>
        public Operando() : this(0)
        {
            new Calculadora();
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

        /// <summary>
        /// Constructor que asigna el valor de <paramref name="numero"/>
        /// a la propiedad <see cref="numero"/>
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor que asigna el valor de <paramref name="numero"/>
        /// utilizando <see cref="Numero"/>
        /// </summary>
        /// <param name="numero"></param>
        public Operando(string numero) 
        {
            this.Numero = numero;
        }


        /// <summary>
        /// Metodo que convierte <param name="numero"></param> a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            return Convert.ToString((int)numero, 2);
        }

        /// <summary>
        /// Metodo que convierte <param name="numero"></param> a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>el numero convertido a binario si pudo convertir, si hay <see cref="OverflowException"/> retorna "Limite excedido"
        /// y si hay <see cref="FormatException"/> retorna "El valor no es valido"</returns>
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


        /// <summary>
        /// Metodo que convierte <param name="numero"></param> a decimal
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>el valor convertido a decimal, si no lo puede convertir, retorna "Valor Invalido"</returns>
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


        /// <summary>
        /// Metodo que valida que <param name="numero"></param> sea un numero binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>true si es binario, false si no</returns>
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

        /// <summary>
        /// sobrecarga del operador + para realizar operacion aritmetica entre 
        /// dos objetos de tipo <see cref="Operando"/>
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna la suma entre las propiedades <seealso cref="numero"/> de los objetos</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }


        /// <summary>
        /// sobrecarga del operador - para realizar operacion aritmetica entre 
        /// dos objetos de tipo <see cref="Operando"/>
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna la resta entre las propiedades <seealso cref="numero"/> de los objetos</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }


        /// <summary>
        /// sobrecarga del operador / para realizar operacion aritmetica entre 
        /// dos objetos de tipo <see cref="Operando"/>
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Si <paramref name="n2"/> es 0, retorna <see cref="double.MinValue"/>, sino la division entre los dos numeros <seealso cref="numero"/> de los objetos</returns>

        public static double operator /(Operando n1, Operando n2)
        {
            return n2.numero == 0 ? double.MinValue : n1.numero / n2.numero;
        }


        /// <summary>
        /// sobrecarga del operador * para realizar operacion aritmetica entre 
        /// dos objetos de tipo <see cref="Operando"/>
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna la multiplicacion entre las propiedades <seealso cref="numero"/> de los objetos</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
    }
}
