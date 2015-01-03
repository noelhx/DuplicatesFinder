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
                    var equal = Compare(fileOne, fileTwo);
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

        private List<string> GetFiles(string rootDirectory)
        {
            var searchOption = _includeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var directories = Directory.GetDirectories(rootDirectory, _searchPattern, searchOption).ToList();
            directories.Add(rootDirectory);

            return directories.SelectMany(Directory.GetFiles).ToList();
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

