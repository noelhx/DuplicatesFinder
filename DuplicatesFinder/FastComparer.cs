namespace DuplicatesFinder
{
    public class FastComparer : IFileComparer
    {
        #region Private Fields

        private readonly IFileComparer _md5Comparer = new MD5Comparer();
        private readonly IFileComparer _sizeComparer = new SizeComparer();

        #endregion

        #region Public Methods

        public bool Equals(string fileName1, string fileName2)
        {
            var equal = _sizeComparer.Equals(fileName1, fileName2);
            return equal && _md5Comparer.Equals(fileName1, fileName2);
        }

        #endregion
    }
}
