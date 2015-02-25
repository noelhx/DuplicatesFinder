namespace DuplicatesFinder
{
    public abstract class Scanner
    {
        #region Private Fields

        protected ScanOptions _options;
        protected IFileComparer _fileComparer;

        #endregion

        #region Constructors

        protected Scanner(ScanOptions scanOptions)
        {
            var fileComparerFactory = new FileComparerFactory();
            _options = scanOptions;
            _fileComparer = fileComparerFactory.Create(scanOptions.FileCompareType);
        }

        #endregion

        #region Public Methods

        public abstract void Scan(string directory1, string directory2);

        #endregion
    }
}

