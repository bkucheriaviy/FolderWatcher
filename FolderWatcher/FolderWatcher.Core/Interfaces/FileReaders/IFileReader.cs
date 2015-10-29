using System.Threading.Tasks;
using FolderWatcher.Core.Models;

namespace FolderWatcher.Core.Interfaces.FileReaders
{
    public interface IFileReader
    {
        bool Match(string filePath);
        Task<StockFile> ReadFile(string filePath);
    }
}
