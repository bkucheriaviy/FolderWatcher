using System.IO;

namespace FolderWatcher.Core.Interfaces.FileReaders
{
    public interface IFileReaderHelper
    {
        string[] ReadText(FileInfo fileInfo);
    }
}