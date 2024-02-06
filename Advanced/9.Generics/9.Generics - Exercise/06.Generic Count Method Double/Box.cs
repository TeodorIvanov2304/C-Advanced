namespace GenericCountMethodDouble
{
    public class Box<T> where T : IComparable
    {
        private List<T> _list;

        public Box()
        {
            this._list = new List<T>();
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public int CountBiggerValues(T element)
        {
            int count = 0;
            foreach (var item in _list)
            {
                //Ако сравнението между item и елемент > 0, значи
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
