using System.Text;

namespace GenericSwapMethodStrings
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
