using System.Text;

namespace GenericSwapMethodInteger
{
    public class Box<T>
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

        public void Swap<T>(List<T> list, int index1, int index2)
        {
            if (index1 < 0 || index2 < 0 || index1 > list.Count - 1 || index1 > list.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;


        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (T item in _list)
            {
                stringBuilder.AppendLine($"{typeof(T)}: {item}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
