using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarcodeGeneratorAPI.Core.Exceptions
{
    public class ModelStateException : Exception
    {
        public ModelStateException(string message) : base(message)
        {
        }

    }
}
