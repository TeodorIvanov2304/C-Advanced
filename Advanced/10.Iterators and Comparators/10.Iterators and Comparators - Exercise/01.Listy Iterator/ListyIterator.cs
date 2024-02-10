using static System.Reflection.Metadata.BlobBuilder;

namespace ListyIterator
{
    public class ListyIterator<T>
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
    }
}
