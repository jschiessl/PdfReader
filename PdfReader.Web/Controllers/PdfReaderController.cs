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
