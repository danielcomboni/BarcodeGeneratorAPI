using ZXing ;

namespace BarcodeGeneratorAPI.Services
{
    public interface IGeneratorService
    {
        byte[] GetBytesArray(string content);
        byte [ ] GetBytesArray ( string content , BarcodeFormat barcodeFormat , int height , int width , int margin ) ;
    }
}
