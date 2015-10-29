using FolderWatcher.Core.Models;
using FolderWatcher.FileReaders.TextStockFileReader;

namespace FolderWatcher.BusinessLayer.FileReaders.TextStockFileReader
{
    public class TextStockFileMapper : ITextStockFileMapper
    {
        public StockFile Map(string fileName, string fileContent)
        {
            return new StockFile {FileName = fileName, RawContent = fileContent};
        }
    }
}
