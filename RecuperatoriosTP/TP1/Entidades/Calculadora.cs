using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        /// <summary>
        /// Metodo que valida que el operador
        /// recibido sea +, -, / o *.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>+, -, / o * si <paramref name="operador"/> corresponde a estos caracteres,
        /// de lo contrario retorna + </returns>
        private static char ValidarOperador(char operador)
        {
            return operador == '*' ? '*' : 
                   operador == '/' ? '/' : 
                   operador == '-' ? '-' : '+';
        }

        /// <summary>
        /// Metodo que realiza la operacion entre ambos objetos <seealso cref="Operando"/> dependiendo
        /// del operador recibido por parametros
        /// recibido sea +, -, / o *.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>+, -, / o * si <paramref name="operador"/> corresponde a estos caracteres,
        /// de lo contrario retorna + </returns>
        public static double Operar(Operando n1, Operando n2, char operador)
        {

            switch (ValidarOperador(operador))
            {
                case '-':
                    return n1 - n2;
                case '*':
                    return n1 * n2;
                case '/':
                    return n1 / n2;
                default:
                    return n1 + n2;
            }
        }
    }
}
