using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {   
            //Използваме вграденият метод на List<T>, GetEnumerator()
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private  int currentIndex = -1;
            private readonly List<Book> books;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
            }

            public Book Current => throw new NotImplementedException();

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {   
                //Връщай true, докато не е е достигната гранциата на масива
                return ++currentIndex<books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }
    }
}
