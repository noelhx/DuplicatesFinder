namespace DuplicatesFinder
{
    public class FileComparerFactory
    {
        public IFileComparer Create(FileCompareType compareType)
        {
            switch (compareType)
            {
                case FileCompareType.MD5:
                    return new MD5Comparer();

                case FileCompareType.Size:
                    return new SizeComparer();

                case FileCompareType.Fast:
                    return new FastComparer();

                default:
                    return null;
            }
        }
    }
}

