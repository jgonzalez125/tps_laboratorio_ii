using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;


        /// <summary>
        /// Constructor que inicializa en 0 a numero
        /// </summary>
        public Operando() : this(0)
        {
        }

        /// <summary>
        /// Propiedad de escritura Numero, setea el valor una vez que este validado
        /// </summary>
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Constructor que inicializa el valor de <see cref="numero"/> mediante el valor
        /// pasado por parametros
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }


        /// <summary>
        /// Constructor que setea <see cref="numero"/> mediante la propiedad
        /// <see cref="Numero"/>
        /// </summary>
        /// <param name="numero"></param>
        public Operando(string numero)
        {
            this.Numero = numero;
        }

        /// <summary>
        /// Metodo estatico que convierte <paramref name="numero"/> a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns> retorna el numero convertido a binario</returns>
        public static string DecimalBinario(double numero)
        {
            return Convert.ToString((int)numero, 2);
        }


        /// <summary>
        /// Convierte <paramref name="numero"/> a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns> retorna el numero convertido a binario si lo pudo convertir, en caso de:
        /// <see cref="OverflowException"/>: "Limite Excedido"
        /// <see cref="FormatException"/>: "El valor no es valido"</returns>
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
        /// Metodo que convierte <paramref name="binario"/> a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns> retorna el numero convertido a decimal, caso contrario "Valor Invalido"</returns>
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
        /// Metodo de clase que valida que el string pasado por parametros sea 
        /// conformado por solo caracteres binarios
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
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
        /// Sobrecarga del operador + para operar entre 2 objetos de tipo
        /// <see cref="Operando"/>
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>retorna la operacion entre ambos atributos "numero" de los objetos</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador - para operar entre 2 objetos de tipo
        /// <see cref="Operando"/>
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>retorna la operacion entre ambos atributos "numero" de los objetos</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador / para operar entre 2 objetos de tipo
        /// <see cref="Operando"/>
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>retorna la operacion entre ambos atributos "numero" de los objetos</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            return n2.numero == 0 ? double.MinValue : n1.numero / n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador * para operar entre 2 objetos de tipo
        /// <see cref="Operando"/>
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>retorna la operacion entre ambos atributos "numero" de los objetos</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
    }
}