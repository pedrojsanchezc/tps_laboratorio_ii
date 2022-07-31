using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class FileException : Exception
    {
        public FileException(string message) : base(message)
        { 
        
        }

        public FileException(string message, Exception nerException) : base(message, nerException)
        { 
        
        }
    }
}
