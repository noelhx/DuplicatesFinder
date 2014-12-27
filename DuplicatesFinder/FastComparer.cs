namespace DuplicatesFinder
{
    public class FastComparer : IComparer
    {
        #region Private Fields

        private readonly IComparer _md5Comparer = new MD5Comparer();
        private readonly IComparer _sizeComparer = new SizeComparer();

        #endregion

        #region Public Methods

        public bool Equals(string fileName1, string fileName2)
        {
            var sizeCompareResult = _sizeComparer.Equals(fileName1, fileName2);
            if (sizeCompareResult)
                return true;

            return _md5Comparer.Equals(fileName1, fileName2);
        }

        #endregion
    }
}
