
using System.Net.Mime;
using BarcodeGeneratorAPI.Core.Exceptions ;
using BarcodeGeneratorAPI.Services ;
using BarcodeGeneratorAPI.ViewModels ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BarcodeGeneratorAPI.Controllers
{
    [ApiController]
    [Route("api/encode")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class EncodeController : Controller
    {
        private readonly IGeneratorService _generatorService;

        public EncodeController(IGeneratorService generatorService)
        {
            _generatorService = generatorService;
        }

        /// <summary>
        /// Encode data to PDF417 format
        /// </summary>
        /// <param name="data"></param>
        /// <returns>PDF417 encoded image</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MediaTypeNames.Image))]
        public IActionResult PostContent([FromBody] EncodedViewModel data)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelStateException("Missing required information");
            }

            byte[] result = _generatorService.GetBytesArray(data.Content, data.BarcodeFormat, data.Height, data.Width, data.Margin);
            return File(result, MediaTypeNames.Application.Octet, "encoded.png");
        }
    }
}