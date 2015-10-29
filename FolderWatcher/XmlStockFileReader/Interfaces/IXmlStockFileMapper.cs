using FolderWatcher.Core.Models;
using XmlStockFileReader.XmlEntities;

namespace XmlStockFileReader.Interfaces
{
    public interface IXmlStockFileMapper
    {
        StockFile Map(string fileName, XmlStockFile file);
    }
}