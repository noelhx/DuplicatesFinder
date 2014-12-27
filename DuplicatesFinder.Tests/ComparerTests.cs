using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Extensions;

namespace DuplicatesFinder
{
    public class ComparerTests
    {
        private readonly Comparer _comparer;

        public ComparerTests()
        {
            _comparer = new Comparer();
        }

        [Theory(DisplayName = "GetHashCode() return value depends on FileName value. Two different FileName values should return different hash codes.")]
        [InlineData(@"D:\file1.txt", 10000, @"D:\file2.txt", 10000)]
        [InlineData(@"D:\file1.txt", 10000, @"D:\Folder\file1.txt", 10000)]
        public void GetHashCode_ShouldReturnDifferentHashCodes_Test(string fileName1, long fileSize1, string fileName2, long fileSize2)
        {
            var obj1 = new FileSizeInfo(fileName1, fileSize1);
            var obj2 = new FileSizeInfo(fileName2, fileSize2);

            var hashCode1 = _comparer.GetHashCode(obj1);
            var hashCode2 = _comparer.GetHashCode(obj2);

            Assert.NotEqual(hashCode1, hashCode2);
        }

        [Theory(DisplayName = "GetHashCode() return value depends on FileName value. The same FileName values should return the same hash codes.")]
        [InlineData(@"D:\file1.txt", 10000, @"D:\file1.txt", 10000)]
        public void GetHashCode_ShouldReturnEqualHashCodes_Test(string fileName1, long fileSize1, string fileName2, long fileSize2)
        {
            var obj1 = new FileSizeInfo(fileName1, fileSize1);
            var obj2 = new FileSizeInfo(fileName2, fileSize2);

            var hashCode1 = _comparer.GetHashCode(obj1);
            var hashCode2 = _comparer.GetHashCode(obj2);

            Assert.Equal(hashCode1, hashCode2);
        }

        [Theory]
        [InlineData(@"D:\file1.txt", 10000, @"D:\folder\file2.txt", 10000, false)]
        [InlineData(@"D:\file1.txt", 20000, @"D:\folder\file2.txt", 10000, false)]
        [InlineData(@"D:\file1.txt", 10000, @"D:\folder\file1.txt", 10000, true)]
        [InlineData(@"D:\file1.txt", 20000, @"D:\folder\file1.txt", 10000, false)]
        public void Equals_Test(string fileName1, long fileSize1, string fileName2, long fileSize2, bool expectedResult)
        {
            var obj1 = new FileSizeInfo(fileName1, fileSize1);
            var obj2 = new FileSizeInfo(fileName2, fileSize2);

            bool result = _comparer.Equals(obj1, obj2);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void General_GroupBy_Test()
        {
            var list = new List<FileSizeInfo>();
            list.Add(new FileSizeInfo(@"D:\file1.txt", 10000));
            list.Add(new FileSizeInfo(@"D:\file2.txt", 10000));
            list.Add(new FileSizeInfo(@"D:\Folder\file1.txt", 10000));

            var distinctList = list.GroupBy(a => a).Select(a => a.First()).ToList();

            Assert.Equal(2, distinctList.Count);
        }
    }
}
