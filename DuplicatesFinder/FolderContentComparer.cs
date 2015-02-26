using System.Linq;

namespace DuplicatesFinder
{
    public class FolderContentComparer : IFolderComparer
    {
        #region Private Fields

        private readonly string _searchPattern;

        #endregion

        #region Constructors

        public FolderContentComparer(string searchPattern)
        {
            _searchPattern = searchPattern;
        }

        #endregion

        #region Public Methods

        public bool Equals(string folder1, string folder2)
        {
            var count1 = FileManager.GetDirectoryFilesCount(folder1, false, _searchPattern);
            var count2 = FileManager.GetDirectoryFilesCount(folder2, false, _searchPattern);

            var files1 = FileManager.GetFiles(folder1, false, _searchPattern).Select(FileManager.GetShortFileName).ToList();
            var files2 = FileManager.GetFiles(folder2, false, _searchPattern).Select(FileManager.GetShortFileName).ToList();

            files1.Sort();
            files2.Sort();

            return count1.Equals(count2) && files1.SequenceEqual(files2);
        }

        #endregion
    }
}

