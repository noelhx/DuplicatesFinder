using Xunit.Extensions;

namespace DuplicatesFinder.Tests
{
    /// <summary>
    /// Temporary test environment.
    /// </summary>
    public class Preparation
    {
        private const string dirOne = @"D:\Фотографии";
        private const string dirTwo = @"E:\Фотографии";
        private const string dumpOne = @"..\..\..\DuplicatesFinder\DataDumps\dPhotos.txt";
        private const string dumpTwo = @"..\..\..\DuplicatesFinder\DataDumps\ePhotos.txt";

        [Theory]
        [InlineData(dirOne, dumpOne)]
        [InlineData(dirTwo, dumpTwo)]
        public void CreateDump(string path, string dumpPath)
        {
            var infos = Finder.GetFileSizeInfos(path);
            Helper.Serialize(infos, dumpPath);
        }

        [Theory]
        [InlineData(dumpOne)]
        [InlineData(dumpTwo)]
        public void Desreialize(string dumpPath)
        {
            var infos = Helper.Deserialize(dumpPath);
        }
    }
}
