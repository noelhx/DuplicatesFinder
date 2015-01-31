using System.IO;
using System.Security.Cryptography;

namespace DuplicatesFinder
{
    /// <summary>
    /// Provides caching mechanism for MD5
    /// </summary>
    public class MD5Proxy
    {
        #region Private Fields

        private readonly Cache<string, byte[]> _cache = new Cache<string, byte[]>();
        private readonly MD5 _md5;

        #endregion

        #region Public Constructors

        public MD5Proxy()
        {
            _md5 = MD5.Create();
        }

        #endregion

        #region Public Methods

        public byte[] ComputeHash(FileStream stream)
        {
            return _cache.GetOrAdd(stream.Name, a => _md5.ComputeHash(stream));
        }

        #endregion
    }
}
