using System.IO;
using System.Linq;
using System.Xml.Serialization;
using FolderWatcher.Core.Interfaces.FileReaders;
using XmlStockFileReader.Interfaces;
using XmlStockFileReader.XmlEntities;

namespace XmlStockFileReader
{
    public class XmlStockFileReaderHelper : IXmlStockFileReaderHelper
    {
        private readonly IFileReaderHelper _fileReader;

        public XmlStockFileReaderHelper(IFileReaderHelper fileReader)
        {
            _fileReader = fileReader;
        }

        public XmlStockFile ReadXmlFile(string path)
        {
            var fileLines = _fileReader.ReadText(path);
            
            using (var reader = new StringReader(string.Join("",fileLines.Skip(1))))
            {
                var serializer = new XmlSerializer(typeof(XmlStockFile));
                return (XmlStockFile)serializer.Deserialize(reader);
            }
        }
    }
}
