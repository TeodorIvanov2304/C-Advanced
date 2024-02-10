using System.Collections;
using static System.Reflection.Metadata.BlobBuilder;

namespace ListyIterator
{
    public class ListyIterator<T>:IEnumerable<T>
    {
        private  int _index = 0;
        private List<T> list;
        public ListyIterator(List<T> list)
        {
            this.list = list;
        }

        public bool Move()
        {   
            if (HasNext()) 
            {
                _index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            return _index < list.Count-1;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException();
            }
            Console.WriteLine(list[_index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                //yield return връша резултата от всяка итерация на цикъла
                yield return list[i];
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
