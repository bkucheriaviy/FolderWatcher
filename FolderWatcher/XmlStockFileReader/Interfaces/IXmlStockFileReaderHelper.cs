using XmlStockFileReader.XmlEntities;

namespace XmlStockFileReader.Interfaces
{
    public interface IXmlStockFileReaderHelper
    {
        XmlStockFile ReadXmlFile(string path);
    }
}
