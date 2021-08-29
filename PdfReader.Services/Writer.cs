using PdfReader.Services.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace PdfReader.Services
{
    public class Writer : IWriter
    {
        private readonly IReader reader;

        public Writer(IReader reader)
        {
            this.reader = reader;
        }

        public string WritePdfFile(string filePath)
        {
            string rawText = reader.ReadPdf(filePath);
            return SplitText(rawText);
        }

        public string WritePdfFile(Stream fileStream)
        {
            string rawText = reader.ReadPdf(fileStream);
            return SplitText(rawText);
        }

        private string SplitText(string rawText)
        {
            string[] splittedText = rawText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            string[] firstFiveLines = splittedText.Take(5).ToArray();

            return (String.Join(Environment.NewLine, firstFiveLines));
        }
    }
}
