using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DuplicatesFinder
{
    class Program
    {
        const string dirOne = @"D:\Фотографии";
        const string dirTwo = @"E:\Фотографии";

        static void Main(string[] args)
        {
            var serialized = new[] { @"..\..\DataDumps\dPhotos.txt", @"..\..\DataDumps\ePhotos.txt" };

            var partOne = Deserialize(serialized[0]);
            var partTwo = Deserialize(serialized[1]);
        }

        private static void DoWork()
        {
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
