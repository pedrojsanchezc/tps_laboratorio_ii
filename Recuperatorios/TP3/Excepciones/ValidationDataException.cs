using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ValidationDataException : Exception
    {
        public ValidationDataException(string message) : base(message)
        { 
        
        }
        public ValidationDataException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
