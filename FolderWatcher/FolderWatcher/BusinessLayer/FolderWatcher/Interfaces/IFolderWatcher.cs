using System;
using FolderWatcher.BusinessLayer.FolderWatcher.EventHandlers;

namespace FolderWatcher.BusinessLayer.FolderWatcher.Interfaces
{
    public interface IFolderWatcher
    {
        event FileFoundEventHandler FileFound;
        void StartLookup(TimeSpan lookupFrequency, string folderPath);
    }
}