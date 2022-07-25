using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        double numero;

        public Operando() 
        {
            this.numero = 0;
        }

        public Operando(double numero) : this ()
        {
            this.numero = numero;
        }
        public Operando(string numero) : this()
        {
            this.Numero = numero;
        }

        public string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }

        private static double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double validOperator))
            {
                return validOperator;
            }
            return 0;
        }

        private static bool EsBinario(string binario)
        {
            foreach (char c in binario)
            {
                if (c != '0' && c != '1') 
                {
                    return false;
                }
            }
            return true;
        }

        public static string BinarioDecimal(string binario)
        {
            int length = binario.Length - 1;
            double decimalNumber = 0;
            int count = 0;
            if (EsBinario(binario))
            {
                for (int i = length; i >= 0; i--)
                {
                    if (binario[i] == '1')
                    {
                        decimalNumber += Math.Pow(2, count);
                    }
                    count++;
                }
                return decimalNumber.ToString();
            }
            return "Invalid number";
        }

        public static string DecimalBinario(double numero)
        {
            string binaryToReturn = "";
            int absoluteNumber = (int)Math.Abs(numero);
            int rest;

            if (absoluteNumber == 0)
            { 
                binaryToReturn = "0";
            }

            while (absoluteNumber > 0)
            { 
                rest = absoluteNumber % 2;
                absoluteNumber /= 2;
                binaryToReturn = rest + binaryToReturn;
            }
            return binaryToReturn;
        }

        public static string DecimalBinario(string numero)
        {
            if (double.TryParse(numero, out double numberToConvert))
            {
                return DecimalBinario(numberToConvert);
            }
            return "Invalid number.";
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
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            return double.MinValue;
        }
        public static double operator *(Operando n1, Operando n2)
        { 
            return n1.numero * n2.numero;
        }
    }
}
