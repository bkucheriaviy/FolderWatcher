using System;
using System.IO;
using FolderWatcher.Core;
using NUnit.Framework;

namespace FolderWatcher.Tests.Core
{
    [TestFixture]
    public class FileReaderHelperTests
    {
        [Test]
        public void TestReadText()
        {
            //given
            var appPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var testFilePath = appPath + "\\Core\\TestFile\\any.any";

            var helper = new FileReaderHelper();
            var expectedResult = new[] {"line1", "line2line2", "line3line3line3"};
            //when
            var result = helper.ReadText(testFilePath);
            //then
            Assert.That(result.Length, Is.EqualTo(expectedResult.Length));
            Assert.That(result[0],Is.EqualTo(expectedResult[0]));
            Assert.That(result[1], Is.EqualTo(expectedResult[1]));
            Assert.That(result[2], Is.EqualTo(expectedResult[2]));
        }

        [Test]
        public void TestReadTextThrowsExceptionIfFileIsNotFound()
        {
            //given
            const string testFilePath = "Fileis Not Exist";
            var helper = new FileReaderHelper();
            //when
            //then
            Assert.Throws(typeof (FileNotFoundException), () => helper.ReadText(testFilePath));
        }
    }
}
