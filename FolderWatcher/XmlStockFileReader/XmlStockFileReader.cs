using System.IO;
using System.Threading.Tasks;
using FolderWatcher.Core.Interfaces.FileReaders;
using FolderWatcher.Core.Models;
using XmlStockFileReader.Interfaces;

namespace XmlStockFileReader
{
    public class XmlStockFileReader : IFileReader
    {
        private readonly IXmlStockFileMapper _xmlStockFileMapper;
        private readonly IXmlStockFileReaderHelper _fileHelper;

        public XmlStockFileReader(IXmlStockFileMapper stockFileMapper, IXmlStockFileReaderHelper fileHelper)
        {
            _xmlStockFileMapper = stockFileMapper;
            _fileHelper = fileHelper;
        }

        public bool Match(string filePath)
        {
            return filePath.Trim().ToLower().EndsWith(".xml");
        }

        public async Task<StockFile> ReadFile(string filePath)
        {
            return await Task.Run(() =>
            {
                var values = _fileHelper.ReadXmlFile(filePath);
                return _xmlStockFileMapper.Map(Path.GetFileNameWithoutExtension(filePath), values);
            });
        }
    }
}
