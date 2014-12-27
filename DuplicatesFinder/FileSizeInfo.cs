using System;
using System.IO;

namespace DuplicatesFinder
{
    [Serializable]
    public class FileSizeInfo
    {
        public string FileName;
        public string ShortFileName;
        public long FileSize;

        public FileSizeInfo(string fileName, long fileSize)
        {
            FileName = fileName;
            ShortFileName = Path.GetFileName(FileName);
            FileSize = fileSize;
        }
    }
}
