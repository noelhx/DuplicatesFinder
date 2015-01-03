using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DuplicatesFinder
{
    public class Finder
    {
        #region Private Fields

        private readonly IComparer _comparer;
        private readonly string _searchPattern;

        #endregion

        #region Public Constructors

        public Finder(ComparerType comparerType, string serachPattern = "*")
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

            _searchPattern = serachPattern;
        }

        #endregion

        #region Public Methods

        public void FindDuplicates(string directoryOne, string directoryTwo)
        {
            var filesFromDirectoryOne = GetAllFiles(directoryOne, _searchPattern);
            var filesFromDirectoryTwo = GetAllFiles(directoryTwo, _searchPattern);

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

        private bool Compare(string fileName1, string fileName2)
        {
            return _comparer.Equals(fileName1, fileName2);
        }

        // temporary method used for serialization
        public static List<FileSizeInfo> GetFileSizeInfos(string path)
        {
            var files = GetAllFiles(path);
            var infos = GetFilesSize(files);

            return infos;
        }

        // should be made private
        public static List<string> GetAllFiles(string rootDirectory, string searchPattern = "*")
        {
            var files = new List<string>();
            var directories = Directory.GetDirectories(rootDirectory, searchPattern, SearchOption.AllDirectories).ToList();
            directories.Add(rootDirectory);

            foreach (var directory in directories)
            {
                foreach (var file in Directory.GetFiles(directory))
                {
                    files.Add(file);
                }
            }

            return files;
        }

        // should be made private
        public static List<FileSizeInfo> GetFilesSize(List<string> files)
        {
            var result = new List<FileSizeInfo>();

            foreach (var file in files)
            {
                try
                {
                    var fi = new FileInfo(file);
                    var fsi = new FileSizeInfo(file, fi.Length);
                    result.Add(fsi);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error has occured during processing {0} file: {1}.", file, e.Message);
                }
            }

            return result;
        }
    }
}

