using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfReader.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PdfReader.Web.Controllers
{
    public class PdfReaderController : Controller
    {
        private readonly IWriter _writer;

        public PdfReaderController(IWriter writer)
        {
            _writer = writer;
        }

        // You're accepting a new file from the server and read out the contents
        // So far, so good :-)
        // But there are a few issues with handling the uploaded file:
        // * You're creating a local temporary file, and you're not cleaning it up
        //   * So files will pile up over time, as long as the server runs
        // * You expect ../PdfReader/PdfFiles to exist and be writable, so that' an external dependency that you cannot control
        public async Task<IActionResult> GetFirstFiveLines(IFormFile file)
        {
            if (file == null)
            {
                return NotFound("Please select a file");
            }

            try
            {
                var filePath = Path.Combine("..//PdfReader", "PdfFiles", file.FileName);

                if (filePath == null)
                {
                    return NotFound("File not found");
                }

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileSteam);
                }

                string result = _writer.WritePdfFile(file.FileName);
                return View("Index", result);
            }
            catch (Exception)
            {

                return BadRequest("File not found");
            }
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
    }
}
