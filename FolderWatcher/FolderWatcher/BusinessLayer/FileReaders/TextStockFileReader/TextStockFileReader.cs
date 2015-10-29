using System.IO;
using System.Threading.Tasks;
using FolderWatcher.Core.Interfaces.FileReaders;
using FolderWatcher.Core.Models;

namespace FolderWatcher.FileReaders.TextStockFileReader
{
    public class TextStockFileReader : IFileReader
    {
        private readonly ITextStockFileMapper _textStockFileMapper;
        private readonly IFileReaderHelper _fileHelper;

        public TextStockFileReader(ITextStockFileMapper stockFileMapper, IFileReaderHelper fileHelper)
        {
            _textStockFileMapper = stockFileMapper;
            _fileHelper = fileHelper;
        }

        public bool Match(FileInfo fileInfo)
        {
            return fileInfo.Extension == ".txt";
        }

        public async Task<StockFile> ReadFile(FileInfo fileInfo)
        {
            return await Task.Run(() =>
            {
                var fileContent = _fileHelper.ReadText(fileInfo);
                return _textStockFileMapper.Map(fileInfo.FullName, fileContent);
            });
        }
    }
}
