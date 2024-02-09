using System.Collections;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            //Подаваме новия BookComparator, вместо да използваме default OrderBy
            return new LibraryIterator(books.OrderBy(b=>b,new BookComparator()).ToList());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
                this.books.Sort();
            }

            private readonly List<Book> books;
            private int currentIndex;

            public bool MoveNext()
            {
                return ++this.currentIndex < this.books.Count;
            }

            public void Reset() => this.currentIndex = -1;


            public Book Current => this.books[this.currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose() { }
        }
    }
}