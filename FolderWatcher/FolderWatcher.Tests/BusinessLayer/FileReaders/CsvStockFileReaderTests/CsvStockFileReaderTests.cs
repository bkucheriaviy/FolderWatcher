using FolderWatcher.Core.Interfaces.FileReaders;
using FolderWatcher.Core.Models;
using FolderWatcher.FileReaders.CsvStockFileReader;
using Moq;
using NUnit.Framework;

namespace FolderWatcher.Tests.BusinessLayer.FileReaders.CsvStockFileReaderTests
{
    [TestFixture]
    public class CsvStockFileReaderTests
    {
        [Test]
        public void TestMatch()
        {
            //given
            const string filePath = "c:\\d\\d\\test.csv";
            var mapper = Mock.Of<ICsvStockFileMapper>();
            var fileHelper = Mock.Of<IFileReaderHelper>();
            var reader = new CsvStockFileReader(mapper, fileHelper);
            //when
            var result = reader.Match(filePath);
            //then
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestMatchShouldNotMatch()
        {
            //given
            const string filePath = "c:\\d\\d\\test.txt";
            var mapper = Mock.Of<ICsvStockFileMapper>();
            var fileHelper = Mock.Of<IFileReaderHelper>();
            var reader = new CsvStockFileReader(mapper, fileHelper);
            //when
            var result = reader.Match(filePath);
            //then
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestMatchShouldNotMatchOnBadString()
        {
            //given
            const string filePath = "asdasdasda.txt.asdasdasd";
            var mapper = Mock.Of<ICsvStockFileMapper>();
            var fileHelper = Mock.Of<IFileReaderHelper>();
            var reader = new CsvStockFileReader(mapper, fileHelper);
            //when
            var result = reader.Match(filePath);
            //then
            Assert.That(result, Is.False);
        }

        [Test]
        public async void TestReadFile()
        {
            //given
            const string filePath = "c:\\d\\d\\test.csv";
            var fileLines = new[] {""};
            var stockFile = new StockFile();
            var fileHelper = Mock.Of<IFileReaderHelper>(h => h.ReadText(filePath) == fileLines);
            var mapper = Mock.Of<ICsvStockFileMapper>(m => m.Map("test", fileLines) == stockFile);
            
            var reader = new CsvStockFileReader(mapper, fileHelper);
            //when
            var result = await reader.ReadFile(filePath);
            //then
            Assert.That(result, Is.SameAs(stockFile));
        }
    }
}
