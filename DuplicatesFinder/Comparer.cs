using System.Collections.Generic;

namespace DuplicatesFinder
{
    public class Comparer : IEqualityComparer<FileSizeInfo>
    {
        public bool Equals(FileSizeInfo x, FileSizeInfo y)
        {
            return 
                x.ShortFileName.Equals(y.ShortFileName) && 
                x.FileSize.Equals(y.FileSize);
        }

        public int GetHashCode(FileSizeInfo obj)
        {
            return obj.FileName.GetHashCode();
        }
    }

    public class SimpleComparer : IEqualityComparer<FileSizeInfo>
    {
        public bool Equals(FileSizeInfo x, FileSizeInfo y)
        {
            return
                x.ShortFileName.Equals(y.ShortFileName) &&
                x.FileSize.Equals(y.FileSize);
        }

        public int GetHashCode(FileSizeInfo obj)
        {
            return obj.FileName.GetHashCode();
        }
    }
}
