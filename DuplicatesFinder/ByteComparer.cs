using System;
using System.IO;

namespace DuplicatesFinder
{
    public class ByteComparer : IComparer
    {
        public bool Equals(string fileName1, string fileName2)
        {
            using (var stream1 = File.OpenRead(fileName1))
            using (var stream2 = File.OpenRead(fileName2))
            {
                // to be implemented
            }

            return false;
        }
    }
}

