namespace DuplicatesFinder
{
    public class SizeComparer : IFileComparer
    {
        #region Private Fields

        private readonly FileInfoProxy _fileInfoProxy = new FileInfoProxy();

        #endregion

        #region Public Methods

        public bool Equals(string fileName1, string fileName2)
        {
            var size1 = GetFileSize(fileName1);
            var size2 = GetFileSize(fileName2);

            return size1.Equals(size2);
        }

        #endregion

        #region Private Methods

        private long GetFileSize(string fileName)
        {
            return _fileInfoProxy.Init(fileName).Length;
        }

        #endregion
    }
}
