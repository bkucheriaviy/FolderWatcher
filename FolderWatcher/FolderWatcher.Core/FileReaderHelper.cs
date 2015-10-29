using System.IO;
using System.Text;
using FolderWatcher.Core.Interfaces.FileReaders;

namespace FolderWatcher.Core
{
    public class FileReaderHelper : IFileReaderHelper
    {
        public string[] ReadText(FileInfo fileInfo)
        {
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
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
    }
}
