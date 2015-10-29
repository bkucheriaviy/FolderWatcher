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

        public bool Match(string filePath)
        {
            return filePath.Trim().ToLower().EndsWith(".txt");
        }

        public async Task<StockFile> ReadFile(string filePath)
        {
            return await Task.Run(() =>
            {
                var fileContent = _fileHelper.ReadText(filePath);
                return _textStockFileMapper.Map(Path.GetFileNameWithoutExtension(filePath), fileContent);
            });
        }
    }
}
