﻿using System ;

namespace BarcodeGeneratorAPI.Core.Exceptions
{
    public class ClientFriendlyException : Exception
    {
        public ClientFriendlyException(string message) : base(message)
        {
        }
    }
}
