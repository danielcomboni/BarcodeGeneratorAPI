using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarcodeGeneratorAPI.Core.Exceptions
{
    public class ClientFriendlyException : Exception
    {
        public ClientFriendlyException(string message) : base(message)
        {
        }
    }
}
