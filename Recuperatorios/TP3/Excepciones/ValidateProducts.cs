using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ValidateProducts : Exception
    {
        public ValidateProducts(string message) : base(message)
        {

        }

        public ValidateProducts(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
