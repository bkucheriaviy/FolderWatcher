using System.Linq;
using FolderWatcher.Core.Interfaces.FileReaders;
using Moq;
using NUnit.Framework;
using XmlStockFileReader.XmlEntities;

namespace XmlStockFileReader.Tests.XmlStockFileReaderTests
{
    [TestFixture]
    public class XmlStockFileReaderHelperTests
    {
        [Test]
        public void TestReadText()
        {
            //given
            const string testFilePath = "filePath";
            var fileLines = new[]
            {
                "Content:",
                "<?xml version=\"1.0\" encoding=\"utf-8\" ?>",
                "<values>",
                "<value date=\"2013-5-20\" open=\"30.16\" high=\"30.39\" low=\"30.02\" close=\"30.17\" volume=\"1478200\" />",
                "</values>"
            };
            var fileReader = Mock.Of<IFileReaderHelper>(r => r.ReadText(testFilePath) == fileLines);
            var helper = new XmlStockFileReaderHelper(fileReader);
            var expectedResult = new XmlStockFile
            {
                Values = new[]
                {
                    new StockValue
                    {
                        Date = "2013-5-20",
                        Open = "30.16",
                        High = "30.39",
                        Low = "30.02",
                        Close = "30.17",
                        Volume = "1478200"

                    }
                }
            };
            //when
            var result = helper.ReadXmlFile(testFilePath);
            //then
            Assert.That(result.Values.Count(), Is.EqualTo(1));
            Assert.That(result.Values[0].Date, Is.EqualTo(expectedResult.Values[0].Date));
            Assert.That(result.Values[0].Open, Is.EqualTo(expectedResult.Values[0].Open));
            Assert.That(result.Values[0].High, Is.EqualTo(expectedResult.Values[0].High));
            Assert.That(result.Values[0].Low, Is.EqualTo(expectedResult.Values[0].Low));
            Assert.That(result.Values[0].Close, Is.EqualTo(expectedResult.Values[0].Close));
            Assert.That(result.Values[0].Volume, Is.EqualTo(expectedResult.Values[0].Volume));
        }
    }
}
