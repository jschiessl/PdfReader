using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfReader.Services.Interfaces
{
    public interface IWriter
    {
        public string ReadPdfFile(string filePath);
    }
}
