using PdfReader.Services.Interfaces;
using System;
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
            string formattedText = reader.ReadPdf(filePath);

            string[] splitedText = formattedText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            string[] firstFiveLine = splitedText.Take(5).ToArray();

            return (String.Join(Environment.NewLine, firstFiveLine));
        }
    }
}
