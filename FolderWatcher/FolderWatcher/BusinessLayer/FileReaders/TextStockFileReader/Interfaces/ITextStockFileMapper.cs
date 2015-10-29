using FolderWatcher.Core.Models;

namespace FolderWatcher.FileReaders.TextStockFileReader
{
    public interface ITextStockFileMapper
    {
        StockFile Map(string fileName, string[] fileLines);
    }
}