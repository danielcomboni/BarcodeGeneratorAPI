using BarcodeGeneratorAPI.Core.Helpers ;
using ZXing ;

namespace BarcodeGeneratorAPI.Services
{
    public class GeneratorService : IGeneratorService
    {
        /// <summary>
        /// Returns a PDF417 encoded bytes array from a given string
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public byte[] GetBytesArray(string content)
        {
            return BarcodeHelper.GenerateByteArray(content);
        }

        public byte [ ] GetBytesArray ( string content , BarcodeFormat barcodeFormat, int height, int width, int margin)
        {
            return  BarcodeHelper.GenerateByteArray(content, barcodeFormat, height, width, margin);
        }
    }
}