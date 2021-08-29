using System.IO;

namespace PdfReader.Services.Interfaces
{
    public interface IWriter
    {
        string WritePdfFile(string filePath);
        string WritePdfFile(Stream stream);
    }
}
