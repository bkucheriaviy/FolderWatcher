using System.Linq;
using FolderWatcher.Core.Models;
using FolderWatcher.FileReaders.TextStockFileReader;

namespace FolderWatcher.BusinessLayer.FileReaders.TextStockFileReader
{
    public class TextStockFileMapper : ITextStockFileMapper
    {
        public StockFile Map(string fileName, string[] fileLines)
        {
            var stockData =
                fileLines.SkipWhile(l => l != "Content:")
                    .Skip(2)
                    .Select(i =>
                    {
                        var splittedValues = i.Split(';');
                        return new StockData
                        {
                            Date = splittedValues[0],
                            Open = splittedValues[1],
                            High = splittedValues[2],
                            Low = splittedValues[3],
                            Close = splittedValues[4],
                            Volume = splittedValues[5]
                        };
                    }).ToList();

            return new StockFile {FileName = fileName, StockData = stockData};
        }
    }
}
