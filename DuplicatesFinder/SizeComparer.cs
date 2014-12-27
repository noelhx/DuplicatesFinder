using System.IO;

namespace DuplicatesFinder
{
    public class SizeComparer : IComparer
    {
        public bool Equals(string fileName1, string fileName2)
        {
            var size1 = GetFileSize(fileName1);
            var size2 = GetFileSize(fileName2);

            return size1.Equals(size2);
        }

        private long GetFileSize(string fileName)
        {
            var fi = new FileInfo(fileName);
            return fi.Length;
        }
    }
}
