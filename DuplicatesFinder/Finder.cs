using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DuplicatesFinder
{
    public class Finder
    {
        #region Private Fields

        private readonly IFileComparer _comparer;
        private readonly string _searchPattern;
        private readonly bool _includeSubDirectories;

        #endregion

        #region Public Constructors

        public Finder(FileCompareType fileCompareType, bool includeSubDirectories, string searchPattern = "*")
        {
            var factory = new FileComparerFactory();
            _comparer = factory.Create(fileCompareType);
            _searchPattern = searchPattern;
            _includeSubDirectories = includeSubDirectories;
        }

        #endregion

        #region Public Methods

        public void FindDuplicates(string directoryOne, string directoryTwo)
        {
            var filesFromDirectoryOne = FileManager.GetFiles(directoryOne, _includeSubDirectories, _searchPattern);
            var filesFromDirectoryTwo = FileManager.GetFiles(directoryTwo, _includeSubDirectories, _searchPattern);

            foreach (var fileOne in filesFromDirectoryOne)
            {
                foreach (var fileTwo in filesFromDirectoryTwo)
                {
                    var equal = _comparer.Equals(fileOne, fileTwo);
                    if (equal)
                        Console.WriteLine("[ {0}, {1} ]", fileOne, fileTwo);
                }
            }
        }

        #endregion
    }
}

