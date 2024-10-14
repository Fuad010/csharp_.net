using System;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class FileLogger
    {
        private readonly string _folderPath;
        private readonly string _fileName;

        public FileLogger(string folderPath, string fileName)
        {
            _folderPath = folderPath;
            _fileName = fileName;

            // Ensure that the folder exists
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
        }

        public async Task LogAsync(string message)
        {
            string filePath = Path.Combine(_folderPath, _fileName);
            await File.AppendAllTextAsync(filePath, message);
        }
    }
}
