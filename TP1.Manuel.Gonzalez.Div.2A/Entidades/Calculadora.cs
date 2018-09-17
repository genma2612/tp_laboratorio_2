using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region Métodos
        private static string ValidarOperador(string operador)
        {
            if (operador != "-" && operador != "*" && operador != "/")
                operador = "+";
            return operador;
        }

        public double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado;
            switch (ValidarOperador(operador))
            {
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                default:
                    resultado = num1 + num2;
                    break;
            }
            return resultado;
        }
        #endregion
    }
}
