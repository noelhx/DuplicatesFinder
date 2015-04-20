namespace DuplicatesFinder
{
    public class Finder
    {
        #region Private Fields

        private readonly Scanner _scanner;

        #endregion

        #region Public Constructors

        public Finder(ScanType scanType, FileCompareType fileCompareType, bool includeSubDirectories, string searchPattern = "*")
        {
            var scanOptions = new ScanOptions();
            scanOptions.FileCompareType = fileCompareType;
            scanOptions.IncludeSubDirectories = includeSubDirectories;
            scanOptions.SearchPattern = searchPattern;

            var scannerFactory = new ScannerFactory();
            _scanner = scannerFactory.Create(scanType, scanOptions);
        }

        #endregion

        #region Public Methods

        public void FindDuplicates(string directory1, string directory2)
        {
            _scanner.Scan(directory1, directory2);
        }

        #endregion
    }
}

