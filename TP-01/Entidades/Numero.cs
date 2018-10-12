using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double _numero;

        private string SetNumero
        {
            set { this._numero = ValidarNumero(value); }
        }

        private double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double parsedNumero))
                return parsedNumero;
            else
                return 0;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1._numero + n2._numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1._numero / n2._numero;
        }

        public static string DecimalBinario(double numero)       //Convierte un número de decimal a binario
        {
            string retorno = "";
            int i;
            if (numero > 0)
            {
                for (i = 0; ; i++)
                {
                    if ((Math.Pow(2, i)) > numero)
                        break;
                }
                for (int j = i - 1; j >= 0; j--)
                {
                    if (numero >= Math.Pow(2, j))
                    {
                        retorno += 1;
                        numero -= Math.Pow(2, j);
                    }
                    else
                        retorno += 0;
                }
            }
            else
                retorno += 0;
            return retorno;
        }
        
        public static string DecimalBinario(string numero)
        {
            double retorno = 0;
            for (int i = 0; i < numero.Length; i++)
            {
                if (numero[i] == '-' || numero[i] == ',' || numero == "Valor inválido.")
                    return "Valor inválido.";
            }
            retorno = double.Parse(numero);
            return DecimalBinario(retorno);
        }
        
        public static string BinarioDecimal(string binario)       //Convierte un número binario a decimal
        {
            double retorno = 0;
            int lenght = binario.Length;
            int potencia = lenght - 1;
            for (int i = 0; i < lenght; i++)
            {
                if (binario[i] == '1')
                {
                    retorno += Math.Pow(2, potencia);
                }
                potencia--;
            }
            return retorno.ToString("#,0");
        }

        public Numero() :this(0)
        {

        }

        public Numero(double numero) :this(numero.ToString())
        {
            
        }
        
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
    }
}
