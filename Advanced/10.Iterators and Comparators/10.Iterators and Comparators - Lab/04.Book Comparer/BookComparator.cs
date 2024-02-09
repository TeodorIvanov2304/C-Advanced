
namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book? x, Book? y)
        {
            //alphabeticalComparison е от тип инт, защото CompareTo връща -1,0 или 1!
            int alphabeticalComparison = x.Title.CompareTo(y.Title);

            if (alphabeticalComparison == 0)
            {
                return y.Year.CompareTo(x.Year);
            }

            return alphabeticalComparison;
        }
    }
}
