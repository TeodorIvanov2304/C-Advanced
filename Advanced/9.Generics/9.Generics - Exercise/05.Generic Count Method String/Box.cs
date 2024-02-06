using System.Text;

namespace GenericCountMethodString
{   
    //С where T: IComparable добавяме ограничители, който указват какъв тип може да е T. В случая избираме
    //IComparable, т.е типове които може да се сравняват
    public class Box<T> where T: IComparable
    {
        private List<T> _list;
        private int _count;
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
        public int Counts(T element)
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
