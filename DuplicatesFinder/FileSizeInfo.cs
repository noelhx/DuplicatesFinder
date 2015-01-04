using System;

namespace DuplicatesFinder
{
    /// <summary>
    /// Helper class which is used for faster access to a list of files with the sizes.
    /// It is serializable class.
    /// </summary>
    [Serializable]
    public class FileSizeInfo
    {
        #region Private Fields

        private readonly string _fileName;
        private readonly long _fileSize;

        #endregion

        #region Public Constructors

        public FileSizeInfo(string fileName, long fileSize)
        {
            _fileName = fileName;
            _fileSize = fileSize;
        }

        #endregion

        #region Public Properties

        public string FileName
        {
            get { return _fileName; }
        }

        public long FileSize
        {
            get { return _fileSize; }
        }

        #endregion
    }
}
