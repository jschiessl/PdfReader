using BitMiracle.Docotic.Pdf;
using PdfReader.Services.Interfaces;
using System.IO;

namespace PdfReader.Services
{
    public class Reader : IReader
    {
        public string ReadPdf(string filePath)
        {
            using (var pdf = new PdfDocument(Path.Combine("..//PdfReader", "PdfFiles", filePath)))
            {
                var options = new PdfTextExtractionOptions
                {
                    SkipInvisibleText = true,
                    WithFormatting = true
                };

                return pdf.GetText(options);
            }
        }
    }
}
