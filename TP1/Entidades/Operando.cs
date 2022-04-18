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
        private string Numero
        {
            set
            {
                this.numero = ValidarOperador(value);
            }
        }
        public string BinarioDecimal(string numero)
        {
            char[] BinarioDecimal = numero.ToCharArray();
            double potencia = 0;
            double numeroBinario = 0;
            string resultado = "Valor invalido";
            if (EsBinario(numero))
            {
                for (int i = BinarioDecimal.Length - 1; i >= 0; i--)
                {
                    if (BinarioDecimal[i] == '1')
                    {
                        numeroBinario = numeroBinario + Math.Pow(2, potencia);
                    }
                    potencia++;
                }
                resultado = numeroBinario.ToString();
            }

            return resultado;
        }
        public string DecimalBinario(double numero)
        {
            string resultado = "Valor invalido";
            string numeroBinario = "";

            if (numero >= 0)
            {
                int binarioAux = (int)Math.Truncate(numero);

                while (binarioAux > 0)
                {
                    numeroBinario = binarioAux % 2 + numeroBinario;
                    binarioAux = binarioAux / 2;
                }

                return numeroBinario;
            }

            return resultado;
        }
        public string DecimalBinario(string numero)
        {
            string resultado = "Valor invalido";
            double numeroAux;

            if (double.TryParse(numero, out numeroAux))
            {
                string numeroBinario = DecimalBinario(numeroAux);
                return numeroBinario;
            }

            return resultado;
        }
        private static bool EsBinario(string binario)
        {
            char[] binarioArray = binario.ToCharArray();
            bool resultado = false;

            if (!string.IsNullOrEmpty(binario))
            {
                for (int i = 0; i < binarioArray.Length; i++)
                {
                    if (binarioArray[i] == '0' || binarioArray[i] == '1')
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                        break;
                    }
                }
            }

            return resultado;
        }
        public Operando()
        {
            this.numero = 0;
        }
        public Operando(double numero)
        {
            this.numero = numero;
        }
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }
        public static double operator -(Operando num1, Operando num2)
        {
            double resultado = num1.numero - num2.numero;

            return resultado;
        }
        public static double operator *(Operando num1, Operando num2)
        {
            double resultado = num1.numero * num2.numero;

            return resultado;
        }
        public static double operator /(Operando num1, Operando num2)
        {
            double resultado = 0;

            if (num2.numero != 0)
            {
                resultado = num1.numero / num2.numero;
            }

            return resultado;
        }
        public static double operator +(Operando num1, Operando num2)
        {
            double resultado = num1.numero + num2.numero;

            return resultado;
        }
        private double ValidarOperador(string strNumero)
        {
            double numeroValido = 0;

            if (double.TryParse(strNumero, out numeroValido))
            {
                return numeroValido;
            }
            return numeroValido;
        }
    }
}
