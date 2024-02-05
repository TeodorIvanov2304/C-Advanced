namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> box;

        
        public Box()
        {
            this.box = new Stack<T>();
        }

        public int Count { get {return box.Count; } }

        public void Add(T element)
        {
            box.Push(element);
        }

        public T Remove()
        {
            return box.Pop();
        }
    }
}
