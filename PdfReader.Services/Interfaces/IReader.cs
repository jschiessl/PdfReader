using System.IO;

namespace PdfReader.Services.Interfaces
{
    public interface IReader
    {
        string ReadPdf(string filePath);
        string ReadPdf(Stream fileStream);
    }
}
