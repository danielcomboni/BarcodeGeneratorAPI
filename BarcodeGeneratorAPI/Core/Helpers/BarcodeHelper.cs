using System;
using System.Collections.Generic;
using System.Drawing ;
using System.Drawing.Imaging ;
using System.IO ;
using System.Linq;
using System.Threading.Tasks;
using BarcodeGeneratorAPI.Core.Exceptions ;
using ZXing ;
using ZXing.Common ;

namespace BarcodeGeneratorAPI.Core.Helpers
{
    public class BarcodeHelper
    {
        /// <summary>
        /// Generates a PDF417 encoded byte array of a string
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static byte[] GenerateByteArray(string content)
        {
            Guard.ThrowIfNullOrEmpty(content, "Please enter a valid string");

            var height = 300;
            var width = 900;
            var margin = 2;
            var pdf417Writer = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.PDF_417,
                Options = new EncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = margin,
                    PureBarcode = true,
                    GS1Format = true
                }
            };

            var pixelData = pdf417Writer.Write(content);

            using var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb);
            using var ms = new MemoryStream();
            // lock the data area for fast access
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
            try
            {
                // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image
                System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
                    pixelData.Pixels.Length);
            }
            catch
            {
                throw new ClientFriendlyException($"Failed to generate barcode");
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }

            bitmap.Save(ms, ImageFormat.Png);

            return ms.ToArray();
        }

        public static byte[] GenerateByteArray(string content, BarcodeFormat barcodeFormat, int height, int width, int margin)
        {
            Guard.ThrowIfNullOrEmpty(content, "Please enter a valid string");

            //var height = 300;
            //var width = 900;
            //var margin = 2;
            var pdf417Writer = new BarcodeWriterPixelData
            {
                Format = barcodeFormat,
                Options = new EncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = margin,
                    PureBarcode = true,
                    GS1Format = true
                }
            };

            var pixelData = pdf417Writer.Write(content);

            using var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb);
            using var ms = new MemoryStream();
            // lock the data area for fast access
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
            try
            {
                // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image
                System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
                    pixelData.Pixels.Length);
            }
            catch
            {
                throw new ClientFriendlyException($"Failed to generate barcode");
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }

            bitmap.Save(ms, ImageFormat.Png);

            return ms.ToArray();
        }

    }
}
