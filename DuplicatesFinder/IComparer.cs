namespace DuplicatesFinder
{
    public interface IComparer
    {
        bool Equals(string fileName1, string fileName2);
    }
}
