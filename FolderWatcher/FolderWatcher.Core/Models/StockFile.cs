using System.Collections.Generic;

namespace FolderWatcher.Core.Models
{
    public class StockFile
    {
        public string FileName { get; set; }
        public List<StockData> StockData { get; set; }
    }
}
