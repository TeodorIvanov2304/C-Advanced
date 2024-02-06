using System.Text;

namespace BoxOfString
{
    public class Box<T>
    {
        private List<T> _boxes;
        public Box()
        {
            this._boxes = new List<T>();
        }

        public void Add(T item)
        {
            _boxes.Add(item);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T item in _boxes) 
            {   
                //Typeof изкарва типа на променливата
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
