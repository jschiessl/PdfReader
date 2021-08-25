using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfReader.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var filePath = Path.Combine("..//PdfReader","PdfFiles", file.FileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileSteam);
            }

            string v = _writer.ReadPdfFile(file.FileName);
            return View("Index", v);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
    }
}
