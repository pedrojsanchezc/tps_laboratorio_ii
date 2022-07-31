using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ValidateStrings : Exception
    {
        public ValidateStrings(string message) : base(message)
        {

        }

        public ValidateStrings(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
