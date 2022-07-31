using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public static class Validation
    {
        public static float ValidatePrice(string number)
        {
            int count = 0;
            float price = 0;
            ValidationDataException excepcion = new ValidationDataException("Error a la hora de ingresar datos.");

            number = number.Replace('.', ',');

            foreach (char c in number)
            {
                if (!char.IsDigit(c))
                {
                    if (c == ',')
                    {
                        count++;
                        if (count > 2)
                        {
                            throw excepcion;
                        }
                    }
                    else
                    {
                        throw excepcion;
                    }
                }
            }

            price = float.Parse(number);

            if (price <= 0 || price > 50000)
            {
                throw excepcion;
            }

            return price;
        }
        public static int ValidateQuantity(string number)
        {
            if (int.TryParse(number, out int validateNumber) && validateNumber >= 0 && validateNumber <= 1000)
            {
                return validateNumber;
            }

            throw new ValidationDataException("Error a la hora de ingresar datos.");
        }
        public static void ValidateDescription(string description)
        {
            if (!string.IsNullOrEmpty(description))
            {
                description = description.ToLower();
                foreach (Product item in Store.listProducts)
                {
                    if (item.Description.ToLower() == description)
                    {
                        throw new ValidateDescriptionException("El producto es existente");
                    }
                }
            }
        }
    }
}
