using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DuplicatesFinder
{
    public class Helper
    {
        public static void Serialize(List<FileSizeInfo> infos, string outputFileName)
        {
            using (var stream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, infos);
            }
        }

        public static List<FileSizeInfo> Deserialize(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var formatter = new BinaryFormatter();
                return (List<FileSizeInfo>)formatter.Deserialize(stream);
            }
        }
    }
}
