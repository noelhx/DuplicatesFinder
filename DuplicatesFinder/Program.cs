using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DuplicatesFinder
{
    public class Program
    {
        private const string dirOne = @"D:\Фотографии";
        private const string dirTwo = @"E:\Фотографии";
        private static bool _isMac = true;

        public static void Main(string[] args)
        {
            var serialized = new[] { @"..\..\DataDumps/dPhotos.txt", @"..\..\DataDumps\ePhotos.txt" };

            if (_isMac)
            {
                for (int i = 0; i < serialized.Length; i++)
                    serialized[i] = serialized[i].Replace('\\', '/');
            }

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
