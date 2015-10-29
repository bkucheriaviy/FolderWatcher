using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolderWatcher.Core.Interfaces.FileReaders;
using FolderWatcher.FileReaders.TextStockFileReader;
using Moq;
using NUnit.Framework;

namespace FolderWatcher.Tests.BusinessLayer.FileReaders
{
    [TestFixture]
    public class TextStockFileReaderTests
    {
        [Test]
        public void Test()
        {
            //given
            var mapper = Mock.Of<IStockFileMapper>();
            var fileHelper = Mock.Of<IFileReaderHelper>();
            var reader = new TextStockFileReader(mapper, fileHelper);
            //when
            var fileInfo = new FileInfo();
            reader.Match()
            //then
        }
    }
}
