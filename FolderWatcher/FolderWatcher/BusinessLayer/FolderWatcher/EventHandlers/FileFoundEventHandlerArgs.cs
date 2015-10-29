using System;
using FolderWatcher.Core.Models;

namespace FolderWatcher.BusinessLayer.FolderWatcher.EventHandlers
{
    public class FileFoundEventHandlerArgs : EventArgs
    {
        public StockFile File { get; set; }
    }
}