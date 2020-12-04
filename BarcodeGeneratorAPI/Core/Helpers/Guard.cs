using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarcodeGeneratorAPI.Core.Exceptions ;

namespace BarcodeGeneratorAPI.Core.Helpers
{
    public static class Guard
    {
        public static void ThrowIfNullOrEmpty(string argumentValue, string message)
        {
            if (string.IsNullOrWhiteSpace(argumentValue)) throw new ClientFriendlyException(message);
        }
    }
}
