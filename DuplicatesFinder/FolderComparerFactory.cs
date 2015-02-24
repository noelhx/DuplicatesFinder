namespace DuplicatesFinder
{
    public class FolderComparerFactory
    {
        public IFolderComparer Create(FolderCompareType compareType, string searchPattern)
        {
            switch (compareType)
            {
                case FolderCompareType.Size:
                    return new FolderSizeComparer(searchPattern);

                case FolderCompareType.Content:
                    return new FolderContentComparer(searchPattern);

                default:
                    return null;
            }
        }
    }
}

