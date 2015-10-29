using System;
using System.Collections.Generic;
using System.IO;
using FolderWatcher.BusinessLayer.FolderWatcher.EventHandlers;
using FolderWatcher.BusinessLayer.FolderWatcher.Interfaces;
using FolderWatcher.Core.Interfaces.FileReaders;

namespace FolderWatcher.BusinessLayer.FolderWatcher
{
    public class FolderWatcher : IFolderWatcher
    {
        private readonly IEnumerable<IFileReader> _fileReaders;
        private FileSystemWatcher _fileSystemWatcher;

        public event FileFoundEventHandler FileFound;

        public FolderWatcher(IEnumerable<IFileReader> fileReaders)
        {
            _fileReaders = fileReaders;
        }

        public void StartLookup(TimeSpan lookupFrequency, string directoryPath)
        {
            _fileSystemWatcher = new FileSystemWatcher();
            _fileSystemWatcher.Created += OnCreated;
            _fileSystemWatcher.Path = directoryPath;
            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        private async void OnCreated(object sender, FileSystemEventArgs e)
        {
            var filePath = e.FullPath;
            foreach (var reader in _fileReaders)
            {
                if (reader.Match(filePath))
                {
                    FileFound(this, new FileFoundEventHandlerArgs {File = await reader.ReadFile(filePath)});
                    break;
                }
            }
        }
    }
}
