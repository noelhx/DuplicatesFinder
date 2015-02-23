using System;

namespace DuplicatesFinder
{
    public class ScanOptions
    {
        #region Public Properties

        public FileCompareType FileCompareType { get; set; }
        public bool IncludeSubDirectories { get; set; }
        public string SearchPattern { get; set; }

        #endregion
    }
}

