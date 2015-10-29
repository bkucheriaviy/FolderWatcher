using FolderWatcher.Core.Interfaces.FileReaders;
using FolderWatcher.Core.Models;
using FolderWatcher.FileReaders.TextStockFileReader;
using Moq;
using NUnit.Framework;

namespace FolderWatcher.Tests.BusinessLayer.FileReaders.TextStockFileReaderTests
{
    [TestFixture]
    public class TextStockFileReaderTests
    {
        [Test]
        public void TestMatch()
        {
            //given
            const string filePath = "c:\\d\\d\\test.txt";
            var mapper = Mock.Of<ITextStockFileMapper>();
            var fileHelper = Mock.Of<IFileReaderHelper>();
            var reader = new TextStockFileReader(mapper, fileHelper);
            //when
            var result = reader.Match(filePath);
            //then
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestMatchShouldNotMatch()
        {
            //given
            const string filePath = "c:\\d\\d\\test.csv";
            var mapper = Mock.Of<ITextStockFileMapper>();
            var fileHelper = Mock.Of<IFileReaderHelper>();
            var reader = new TextStockFileReader(mapper, fileHelper);
            //when
            var result = reader.Match(filePath);
            //then
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestMatchShouldNotMatchOnBadString()
        {
            //given
            const string filePath = "asdasdasda.csv.asdasdasd";
            var mapper = Mock.Of<ITextStockFileMapper>();
            var fileHelper = Mock.Of<IFileReaderHelper>();
            var reader = new TextStockFileReader(mapper, fileHelper);
            //when
            var result = reader.Match(filePath);
            //then
            Assert.That(result, Is.False);
        }

        [Test]
        public async void TestReadFile()
        {
            //given
            const string filePath = "c:\\d\\d\\test.txt";
            var fileLines = new[] {""};
            var stockFile = new StockFile();
            var fileHelper = Mock.Of<IFileReaderHelper>(h => h.ReadText(filePath) == fileLines);
            var mapper = Mock.Of<ITextStockFileMapper>(m => m.Map("test", fileLines) == stockFile);
            
            var reader = new TextStockFileReader(mapper, fileHelper);
            //when
            var result = await reader.ReadFile(filePath);
            //then
            Assert.That(result, Is.SameAs(stockFile));
        }
    }
}
