using System.Collections.Generic;
using System.IO;

namespace DuplicatesFinder
{
    public class SizeComparer : IComparer
    {
        #region Private Fields

        private Dictionary<string, FileInfo> _cache = new Dictionary<string, FileInfo>(); 

        #endregion

        #region Public Methods

        public bool Equals(string fileName1, string fileName2)
        {
            var size1 = GetFileSize(fileName1);
            var size2 = GetFileSize(fileName2);

            return size1.Equals(size2);
        }

        #endregion

        #region Private Methods

        private long GetFileSize(string fileName)
        {
            var fileInfo = GetOrInitFileInfo(fileName);
            return fileInfo.Length;
        }

        private FileInfo GetOrInitFileInfo(string fileName)
        {
            FileInfo fileInfo;

            if (!_cache.TryGetValue(fileName, out fileInfo))
                fileInfo = new FileInfo(fileName);

            return fileInfo;
        }

        #endregion
    }
}
