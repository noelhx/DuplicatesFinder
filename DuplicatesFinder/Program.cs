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
            const string dPath = @"D:\Фотографии";
            const string ePath = @"E:\Фотографии";

            var paths = new[] { dPath, ePath };
            var outputs = new[] { @"D:\dPhotos.txt", @"D:\ePhotos.txt" };

            foreach (var output in outputs)
            {
                var infos = Deserialize(output);
            }

            return;

            /*for (int i = 0; i < paths.Length; i++)
            {
                var path = paths[i];
                var outputFileName = outputs[i];

                Serialize(path, outputFileName);
            }

            return;

            var files = Finder.GetAllFiles(dPath);
            var fileExtensions = files.Select(Path.GetExtension).Distinct().ToList();

            var filesSizes = Finder.GetFilesSize(files);

            var distFiles = filesSizes.GroupBy(a => new {a.ShortFileName, a.FileSize}).Select(a => a.First()).ToList();

            var duplicates = filesSizes.Except(distFiles).ToList();

            foreach (var info in duplicates)
            {
                Console.WriteLine(info.FileName);
            }

            Console.WriteLine("Files count: " + files.Count);*/
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
