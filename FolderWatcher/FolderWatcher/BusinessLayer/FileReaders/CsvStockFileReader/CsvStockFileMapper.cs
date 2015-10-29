using System.Linq;
using FolderWatcher.Core.Models;
using FolderWatcher.FileReaders.CsvStockFileReader;

namespace FolderWatcher.BusinessLayer.FileReaders.CsvStockFileReader
{
    public class CsvStockFileMapper : ICsvStockFileMapper
    {
        public StockFile Map(string fileName, string[] fileLines)
        {
            var stockData =
                fileLines.SkipWhile(l => l != "Content:")
                    .Skip(1)
                    .Select(i =>
                    {
                        var splittedValues = i.Split(',');
 
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
