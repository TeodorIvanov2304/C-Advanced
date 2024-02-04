namespace _01.ImplementingStackAndQueue
{
    public class CustomStack
    {
        private const int initialCapacity = 4;
        private int[] items;
        public int Count { get; private set; }
        public CustomStack()
        {
            this.items = new int[initialCapacity];
        }

        //Този ForEach метод приема някакво действие, което не връща резултат. Например Console.Writeline();
        //Действието се подава от Program.cs
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }
        public void Push(int element)
        {
            if (Count==items.Length)
            {
                IncreaseCapacity();
            }
            else
            {
                items[Count] = element;
            }
            Count++;
        }

        

        public int Pop()
        {
            CheckIfCountIsZero();
            int result = items[Count - 1];
            Count--;

            return result;
        }

        

        public int Peek()
        {
            CheckIfCountIsZero();

            return items[Count-1]; 
        }

        private void IncreaseCapacity()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }

        private void CheckIfCountIsZero()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
