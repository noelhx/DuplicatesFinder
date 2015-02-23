using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DuplicatesFinder
{
    public class FileManager
    {
        #region Public Methods

        /// <summary>
        /// Returns the list of files from the directory and sub directories (optionally)
        /// which match the search pattern.
        /// </summary>
        public static List<string> GetFiles(string rootDirectory, bool includeSubDirectories, string searchPattern)
        {
            var searchOption = includeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var directories = Directory.GetDirectories(rootDirectory, searchPattern, searchOption).ToList();
            directories.Add(rootDirectory);

            return directories.SelectMany(Directory.GetFiles).ToList();
        }

        /// <summary>
        /// Returns the list of folders which contain files which match the search pattern.
        /// </summary>
        public static List<string> GetScanFolders(string rootDirectory, string searchPattern)
        {
            var result = new List<string>();
            GetScanFolders(rootDirectory, result, searchPattern);

            return result;
        }

        private static void GetScanFolders(string rootDirectory, List<string> result, string searchPattern)
        {
            var directories = Directory.GetDirectories(rootDirectory);
            foreach (var directory in directories)
            {
                var files = Directory.GetFiles(directory, searchPattern).ToList();
                if (files.Count > 0)
                {
                    result.Add(directory);
                }
                else
                {
                    GetScanFolders(directory, result, searchPattern);
                }
            }
        }

        #endregion
    }
}

