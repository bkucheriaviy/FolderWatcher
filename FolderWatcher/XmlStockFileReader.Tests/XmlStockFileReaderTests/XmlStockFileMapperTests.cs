using NUnit.Framework;
using XmlStockFileReader.XmlEntities;

namespace XmlStockFileReader.Tests.XmlStockFileReaderTests
{
    [TestFixture]
   public class XmlStockFileMapperTests
    {
        [Test]
        public void TestMapFindsContentSectionAndSkipFirstLine()
        {
            //given
            const string fileName = "FileName";
            var xmlFile = new XmlStockFile
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
            var mapper = new XmlStockFileMapper();
            //when
            var result = mapper.Map(fileName, xmlFile);
            //then
            Assert.That(result.FileName, Is.EqualTo(fileName));
            Assert.That(result.StockData.Count, Is.EqualTo(1));
            Assert.That(result.StockData[0].Date, Is.EqualTo(xmlFile.Values[0].Date));
            Assert.That(result.StockData[0].Open, Is.EqualTo(xmlFile.Values[0].Open));
            Assert.That(result.StockData[0].High, Is.EqualTo(xmlFile.Values[0].High));
            Assert.That(result.StockData[0].Low, Is.EqualTo(xmlFile.Values[0].Low));
            Assert.That(result.StockData[0].Close, Is.EqualTo(xmlFile.Values[0].Close));
            Assert.That(result.StockData[0].Volume, Is.EqualTo(xmlFile.Values[0].Volume));
        }
    }
}
