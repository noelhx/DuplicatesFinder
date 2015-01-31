using System.IO;

namespace DuplicatesFinder
{
    /// <summary>
    /// Provides caching mechanism for FileInfo class.
    /// </summary>
    public class FileInfoProxy
    {
        #region Private Fields

        private readonly Cache<string, FileInfo> _cache = new Cache<string, FileInfo>();

        #endregion

        #region Public Methods

        public FileInfo Init(string fileName)
        {
            return _cache.GetOrAdd(fileName, a => new FileInfo(fileName));
        }

        #endregion
    }
}
