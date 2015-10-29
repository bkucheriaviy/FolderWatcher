﻿using System;
using FolderWatcher.Core.Interfaces.FileReaders;
using Moq;
using NUnit.Framework;

namespace FolderWatcher.Tests.BusinessLayer.FolderWatcherTests
{
    [TestFixture]
    public class FolderWatcherTests
    {
        [Test]
        public void Test()
        {
            //given
            var reader1 = Mock.Of<IFileReader>(r => r.Match(It.IsAny<string>()));
            var reader2 = Mock.Of<IFileReader>();
            var readers = new[] {reader1, reader2};
            var watcher = new FolderWatcher.BusinessLayer.FolderWatcher.FolderWatcher(readers);
            //when
            watcher.StartLookup(TimeSpan.FromSeconds(5), "path");
            //then
            watcher.
        }
    }
}
