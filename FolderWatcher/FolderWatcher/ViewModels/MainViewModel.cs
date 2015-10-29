using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using FolderWatcher.BusinessLayer.FolderWatcher.Interfaces;
using FolderWatcher.Core.Models;

namespace FolderWatcher.ViewModels
{
    public interface IMainViewModel
    {
        ObservableCollection<StockFile> Files { get; set; }
        void StartLookup(TimeSpan lookupFrequency, string lookupFolder);
    }

    public class MainViewModel : IMainViewModel
    {
        private readonly IFolderWatcher _folderWatcher;
        private readonly Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;

        public ObservableCollection<StockFile> Files{get; set; }

        public MainViewModel(IFolderWatcher folderWatcher)
        {
            Files = new ObservableCollection<StockFile>();
            _folderWatcher = folderWatcher;
            _folderWatcher.FileFound += (e, args) => _dispatcher.Invoke(() => Files.Add(args.File));

        }

        public void StartLookup(TimeSpan lookupFrequency, string lookupFolderPath)
        {
            _folderWatcher.StartLookup(lookupFrequency, lookupFolderPath);
        }
    }
}
