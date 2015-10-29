using FolderWatcher.Core.Models;

namespace FolderWatcher.FileReaders.CsvStockFileReader
{
    public interface ICsvStockFileMapper
    {
        StockFile Map(string fileName, string[] fileLines);
    }
}