using System;
using System.IO;

namespace DuplicatesFinder
{
    /// <summary>
    /// Helper class which is used for faster acces to a list of files with the FileInfo objects.
    /// It is serializable.
    /// </summary>
    [Serializable]
    public class FileSizeInfo
    {
        private string _fileName;
        private readonly FileInfo _fileInfo;

        public FileSizeInfo(string fileName, FileInfo fileInfo)
        {
            _fileName = fileName;
            _fileInfo = fileInfo;
        }
    }
}
