using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DuplicatesFinder
{
    public class Finder
    {
        #region Private Fields

        private readonly IComparer _comparer;
        private readonly string _searchPattern;
        private readonly bool _includeSubDirectories;

        #endregion

        #region Public Constructors

        public Finder(ComparerType comparerType, bool includeSubDirectories, string searchPattern = "*")
        {
            switch (comparerType)
            {
                case ComparerType.MD5:
                    _comparer = new MD5Comparer();
                    break;

                case ComparerType.Size:
                    _comparer = new SizeComparer();
                    break;

                case ComparerType.Fast:
                    _comparer = new FastComparer();
                    break;

                default:
                    throw new NotImplementedException();
            }

            _searchPattern = searchPattern;
            _includeSubDirectories = includeSubDirectories;
        }

        #endregion

        #region Public Methods

        public void FindDuplicates(string directoryOne, string directoryTwo)
        {
            var filesFromDirectoryOne = GetFiles(directoryOne);
            var filesFromDirectoryTwo = GetFiles(directoryTwo);

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

        #region Private Methods

        private List<string> GetFiles(string rootDirectory)
        {
            var searchOption = _includeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var directories = Directory.GetDirectories(rootDirectory, _searchPattern, searchOption).ToList();
            directories.Add(rootDirectory);

            return directories.SelectMany(Directory.GetFiles).ToList();
        }

        #endregion
    }
}

