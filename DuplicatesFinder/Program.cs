using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace DuplicatesFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var serialized = new[] { @"..\..\DataDumps\dPhotos.txt", @"..\..\DataDumps\ePhotos.txt" };

            var files = new List<FileSizeInfo>[2];

            for (int i = 0; i < serialized.Length; i++)
            {
                files[i] = Deserialize(serialized[i]);
            }*/

            var cache = new Dictionary<string, FileInfo>();
            var allFiles = Finder.GetAllFiles(@"D:\Фотографии");

            int count = 0;

            foreach (var file in allFiles)
            {
                cache.Add(file, new FileInfo(file));
                count++;
            }

//            DoWork();
        }

        private static void DoWork()
        {
            const string dirOne = @"D:\Фотографии";
            const string dirTwo = @"E:\Фотографии";

            var finder = new Finder(ComparerType.Fast, true);
            finder.FindDuplicates(dirOne, dirTwo);
        }

        private static void Serialize(string path, string outputFileName)
        {
            var infos = Finder.GetFileSizeInfos(path);

            using (var stream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, infos);
            }
        }

        private static List<FileSizeInfo> Deserialize(string fileName)
        {
            List<FileSizeInfo> result;

            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var formatter = new BinaryFormatter();
                result = (List<FileSizeInfo>) formatter.Deserialize(stream);
            }

            return result;
        }
    }
}
