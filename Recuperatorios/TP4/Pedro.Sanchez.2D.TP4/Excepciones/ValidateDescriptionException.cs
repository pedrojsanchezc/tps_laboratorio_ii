using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ValidateDescriptionException : Exception
    {
        public ValidateDescriptionException(string message) : base(message)
        {

        }

        public ValidateDescriptionException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
