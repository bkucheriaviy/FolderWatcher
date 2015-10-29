using System.Linq;
using FolderWatcher.Core.Models;
using XmlStockFileReader.Interfaces;
using XmlStockFileReader.XmlEntities;

namespace XmlStockFileReader
{
    public class XmlStockFileMapper : IXmlStockFileMapper
    {
        public StockFile Map(string fileName, XmlStockFile file)
        {
            return new StockFile
            {
                FileName = fileName,
                StockData = file.Values.Select(v => new StockData
                {
                    Date = v.Date,
                    Open = v.Open,
                    High = v.High,
                    Low = v.Low,
                    Close = v.Close,
                    Volume = v.Volume
                }).ToList()
            };
        }
    }
}
