using System;

namespace DuplicatesFinder
{
    public class SimpleScanner : Scanner
    {
        #region Constructors

        public SimpleScanner(ScanOptions scanOptions) : base(scanOptions)
        {
        }

        #endregion

        #region Public Methods

        public override void Scan(string directory1, string directory2)
        {
            var files1 = FileManager.GetFiles(directory1, _options.IncludeSubDirectories, _options.SearchPattern);
            var files2 = FileManager.GetFiles(directory2, _options.IncludeSubDirectories, _options.SearchPattern);

            foreach (var fileOne in files1)
            {
                foreach (var fileTwo in files2)
                {
                    var equal = _comparer.Equals(fileOne, fileTwo);
                }
            }
        }

        #endregion
    }
}

