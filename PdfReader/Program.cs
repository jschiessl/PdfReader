using System;
using System.IO;
using BitMiracle.Docotic.Pdf;

namespace PdfReader
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var pdf = new PdfDocument(Path.Combine(Directory.GetCurrentDirectory(), "test.pdf")))
            {
                var options = new PdfTextExtractionOptions
                {
                    SkipInvisibleText = true,
                    WithFormatting = true
                };
                string formattedText = pdf.GetText(options);
                Console.WriteLine(formattedText);
            }
        }
    }
}
