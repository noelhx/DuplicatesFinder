namespace DuplicatesFinder
{
    public class Program
    {
        private const string dirOne = @"D:\Фотографии";
        private const string dirTwo = @"E:\Фотографии";

        public static void Main(string[] args)
        {
        }

        private static void DoWork()
        {
            var finder = new Finder(ComparerType.Fast, true);
            finder.FindDuplicates(dirOne, dirTwo);
        }
    }
}
