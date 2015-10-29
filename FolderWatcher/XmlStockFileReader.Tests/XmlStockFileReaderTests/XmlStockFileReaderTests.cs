using FolderWatcher.Core.Models;
using Moq;
using NUnit.Framework;
using XmlStockFileReader.Interfaces;
using XmlStockFileReader.XmlEntities;

namespace XmlStockFileReader.Tests.XmlStockFileReaderTests
{
    [TestFixture]
    public class XmlStockFileReaderTests
    {
        [Test]
        public void TestMatch()
        {
            //given
            const string filePath = "c:\\d\\d\\test.xml";
            var mapper = Mock.Of<IXmlStockFileMapper>();
            var fileHelper = Mock.Of<IXmlStockFileReaderHelper>();
            var reader = new XmlStockFileReader(mapper, fileHelper);
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
            var mapper = Mock.Of<IXmlStockFileMapper>();
            var fileHelper = Mock.Of<IXmlStockFileReaderHelper>();
            var reader = new XmlStockFileReader(mapper, fileHelper);
            //when
            var result = reader.Match(filePath);
            //then
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestMatchShouldNotMatchOnBadString()
        {
            //given
            const string filePath = "asdasdasda.xml.asdasdasd";
            var mapper = Mock.Of<IXmlStockFileMapper>();
            var fileHelper = Mock.Of<IXmlStockFileReaderHelper>();
            var reader = new XmlStockFileReader(mapper, fileHelper);
            //when
            var result = reader.Match(filePath);
            //then
            Assert.That(result, Is.False);
        }

        [Test]
        public async void TestReadFile()
        {
            //given
            const string filePath = "c:\\d\\d\\test.xml";
            var xmlFile = new XmlStockFile();
            var stockFile = new StockFile();
            var fileHelper = Mock.Of<IXmlStockFileReaderHelper>(h => h.ReadXmlFile(filePath) == xmlFile);
            var mapper = Mock.Of<IXmlStockFileMapper>(m => m.Map("test", xmlFile) == stockFile);
            
            var reader = new XmlStockFileReader(mapper, fileHelper);
            //when
            var result = await reader.ReadFile(filePath);
            //then
            Assert.That(result, Is.SameAs(stockFile));
        }
    }
}
