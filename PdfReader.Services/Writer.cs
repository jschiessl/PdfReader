using BitMiracle.Docotic.Pdf;
using PdfReader.Services.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace PdfReader.Services
{
    public class Writer : IWriter
    {
        public string ReadPdfFile(string filePath)
        {
            using (var pdf = new PdfDocument(Path.Combine("..//PdfReader", "PdfFiles", filePath)))
            {
                var options = new PdfTextExtractionOptions
                {
                    SkipInvisibleText = true,
                    WithFormatting = true
                };
                string formattedText = pdf.GetText(options);

                //var lineQuery = from line in formattedText.Split("\n")
                //                let trimmedLine = line.Trim()
                //                where !string.IsNullOrWhiteSpace(trimmedLine)
                //                select trimmedLine;

                //string[] firstFiveLines = lineQuery.Take(5).ToArray();

                //Console.WriteLine(lineQuery);

                string[] splitedText = formattedText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

                string[] firstFiveLine = splitedText.Take(5).ToArray();

                return (String.Join(Environment.NewLine, firstFiveLine));
            }
        }
    }
}
