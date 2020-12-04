using System.ComponentModel.DataAnnotations ;
using ZXing ;

namespace BarcodeGeneratorAPI.ViewModels
{
    public class EncodedViewModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(1391)]
        public string Content { get; set; }
        public BarcodeFormat BarcodeFormat { get; set; }
        public int Height { get ; set ; } = 300 ;
        public int Width { get ; set ; } = 900 ;
        public int Margin { get ; set ; } = 2 ;


    }
}
