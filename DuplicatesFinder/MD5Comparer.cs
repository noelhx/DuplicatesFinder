using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace DuplicatesFinder
{
    public class MD5Comparer : IComparer
    {
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
                using (var md5 = MD5.Create())
                {
                    return md5.ComputeHash(stream);
                }
            }
        }
    }
}
