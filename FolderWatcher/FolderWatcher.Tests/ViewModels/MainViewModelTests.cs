using System;
using FolderWatcher.BusinessLayer.FolderWatcher.EventHandlers;
using FolderWatcher.BusinessLayer.FolderWatcher.Interfaces;
using FolderWatcher.Core.Models;
using FolderWatcher.ViewModels;
using Moq;
using NUnit.Framework;

namespace FolderWatcher.Tests.ViewModels
{
    [TestFixture]
    public class MainViewModelTests
    {
        [Test]
        public void TestStartLookup()
        {
            //given
            var timespan = TimeSpan.FromSeconds(1);
            var path = "path";
            var watcher = new Mock<IFolderWatcher>();
            var vm = new MainViewModel(watcher.Object);
            //when
            vm.StartLookup(timespan, path);
            //then
            watcher.Verify(w => w.StartLookup(timespan, path), Times.Once());
        }

        [Test]
        public void TestWatcherFileFindEventAddItemIntoObservableCollection()
        {
            //given
            var watcher = new Mock<IFolderWatcher>();
            var file = new StockFile();
            var vm = new MainViewModel(watcher.Object);
            //when
            watcher.Raise(w => w.FileFound += null, new FileFoundEventHandlerArgs {File = file});
            //then
            Assert.That(vm.Files.Count, Is.EqualTo(1));
            Assert.That(vm.Files[0], Is.SameAs(file));
        }
    }
}
