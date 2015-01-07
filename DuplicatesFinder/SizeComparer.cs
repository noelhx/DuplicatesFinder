using System.IO;

namespace DuplicatesFinder
{
    public class SizeComparer : IComparer
    {
        #region Private Fields

        private readonly Cache<string, long> _cache = new Cache<string, long>();

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
            return _cache.GetOrAdd(fileName, a => new FileInfo(fileName).Length);
        }

        #endregion
    }
}
