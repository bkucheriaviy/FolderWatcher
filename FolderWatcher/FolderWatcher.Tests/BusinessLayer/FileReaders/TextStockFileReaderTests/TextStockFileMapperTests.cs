using FolderWatcher.BusinessLayer.FileReaders.TextStockFileReader;
using NUnit.Framework;

namespace FolderWatcher.Tests.BusinessLayer.FileReaders.TextStockFileReaderTests
{
    [TestFixture]
   public class TextStockFileMapperTests
    {
        [Test]
        public void TestMapFindsContentSectionAndSkipFirstLine()
        {
            //given
            const string fileName = "FileName";
            var fileLines = new[]
            {
                "Columns:",
                "Date Open High Low Close Volume",
                "Content:",
                "Date;Open;High;Low;Close;Volume",
                "2013-5-20;30.16;30.39;30.02;30.17;1478200",
                "2013-5-17;29.77;30.26;29.77;30.26;2481400"
            };
            var mapper = new TextStockFileMapper();
            //when
            var result = mapper.Map(fileName, fileLines);
            //then
            Assert.That(result.FileName, Is.EqualTo(fileName));
            Assert.That(result.StockData.Count, Is.EqualTo(2));
            Assert.That(result.StockData[0].Date, Is.EqualTo("2013-5-20"));
            Assert.That(result.StockData[0].Open, Is.EqualTo("30.16"));
            Assert.That(result.StockData[0].High, Is.EqualTo("30.39"));
            Assert.That(result.StockData[0].Low, Is.EqualTo("30.02"));
            Assert.That(result.StockData[0].Close, Is.EqualTo("30.17"));
            Assert.That(result.StockData[0].Volume, Is.EqualTo("1478200"));
            Assert.That(result.StockData[1].Date, Is.EqualTo("2013-5-17"));
            Assert.That(result.StockData[1].Open, Is.EqualTo("29.77"));
            Assert.That(result.StockData[1].High, Is.EqualTo("30.26"));
            Assert.That(result.StockData[1].Low, Is.EqualTo("29.77"));
            Assert.That(result.StockData[1].Close, Is.EqualTo("30.26"));
            Assert.That(result.StockData[1].Volume, Is.EqualTo("2481400"));
        }
    }
}
