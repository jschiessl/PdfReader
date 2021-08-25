using Microsoft.Extensions.DependencyInjection;
using PdfReader.Services;
using PdfReader.Services.Interfaces;
using System;
using System.IO;

namespace PdfReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
               .AddSingleton<IWriter, Writer>()
          .BuildServiceProvider();

            var writerService = serviceProvider.GetService<IWriter>();

            string[] files = Directory.GetFiles("PdfFiles");

            foreach (var filePath in files)
            {
                var fistFiveLines = writerService.ReadPdfFile(filePath);

                Console.WriteLine(fistFiveLines);
            }
        }
    }
}
