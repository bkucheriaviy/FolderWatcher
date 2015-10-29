using System.IO;
using FolderWatcher.Core.Interfaces.FileReaders;

namespace FolderWatcher.Core
{
    public class FileReaderHelper : IFileReaderHelper
    {
        public string[] ReadText(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("Target file is not exist", path);

            var fileInfo = new FileInfo(path);

            while (true)
            {
                if (!IsFileLocked(fileInfo))
                {
                    return File.ReadAllLines(fileInfo.FullName);
                }
            }
        }

        private bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return false;
        }
    }
}
