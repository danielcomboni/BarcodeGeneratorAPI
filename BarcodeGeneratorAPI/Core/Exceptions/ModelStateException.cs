using System ;

namespace BarcodeGeneratorAPI.Core.Exceptions
{
    public class ModelStateException : Exception
    {
        public ModelStateException(string message) : base(message)
        {
        }

    }
}
