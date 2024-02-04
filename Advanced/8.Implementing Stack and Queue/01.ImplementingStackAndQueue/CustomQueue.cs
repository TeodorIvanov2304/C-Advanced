namespace _01.ImplementingStackAndQueue
{
    public class CustomQueue
    {
        private const int initialCapacity = 4;
        private const int firstElementIndex = 0;
        private int[] items;

        public int Count { get; private set; }

        public CustomQueue()
        {
            items = new int[initialCapacity];
        }
        public void Enqueue(int element)
        {   
            if (Count == items.Length)
            {
                IncreaseCapacity();
            }
            Count++;
        }

        public int Dequeue()
        {
            CheckIfQueEmpty();
            int result = items[firstElementIndex];
            ShiftAllLeft();
            Count--;
            return result;
        }


        public int Peek()
        {
            CheckIfQueEmpty();
            return items[firstElementIndex];
        }
        private void ShiftAllLeft()
        {
            for (int i = 0; i < Count-1; i++)
            {
                items[i] = items[i + 1];
            }
        }

        public void Clear()
        {
            int[] empty = new int[initialCapacity];
            items = empty;
            Count = 0;
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

        private void CheckIfQueEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
