using System.IO;
using System.Linq;

namespace DuplicatesFinder
{
    public class MD5Comparer : IFileComparer
    {
        private readonly MD5Proxy _md5Proxy = new MD5Proxy();

        public bool Equals(string fileName1, string fileName2)
        {
            var hash1 = ComputeHash(fileName1);
            var hash2 = ComputeHash(fileName2);

            return hash1.SequenceEqual(hash2);
        }

        private byte[] ComputeHash(string fileName)
        {
            using (var stream = File.OpenRead(fileName))
            {
                return _md5Proxy.ComputeHash(stream);
            }
        }
    }
}
