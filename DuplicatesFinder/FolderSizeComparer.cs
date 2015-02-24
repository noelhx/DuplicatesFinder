namespace DuplicatesFinder
{
    public class FolderSizeComparer : IFolderComparer
    {
        #region Private Fields

        private string _searchPattern;

        #endregion

        #region Constructors

        public FolderSizeComparer(string searchPattern)
        {
            _searchPattern = searchPattern;
        }

        #endregion

        #region Public Methods

        public bool Equals(string folder1, string folder2)
        {
            var size1 = FileManager.GetDirectorySize(folder1, false, _searchPattern);
            var size2 = FileManager.GetDirectorySize(folder2, false, _searchPattern);

            return size1.Equals(size2);
        }

        #endregion
    }
}

