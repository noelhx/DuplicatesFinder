using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DuplicatesFinder
{
    public class SmartScanner : Scanner
    {
        #region Constructors

        public SmartScanner(ScanOptions scanOptions) : base(scanOptions)
        {
        }

        #endregion

        #region Public Methods

        public override void Scan(string directory1, string directory2)
        {
            var folders1 = FileManager.GetScanFolders(directory1, _options.SearchPattern);
            var folders2 = FileManager.GetScanFolders(directory2, _options.SearchPattern);
        }

        #endregion
    }
}

