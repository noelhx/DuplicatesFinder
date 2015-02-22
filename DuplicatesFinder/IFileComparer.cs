namespace DuplicatesFinder
{
    public interface IFileComparer
    {
        bool Equals(string fileName1, string fileName2);
    }
}
