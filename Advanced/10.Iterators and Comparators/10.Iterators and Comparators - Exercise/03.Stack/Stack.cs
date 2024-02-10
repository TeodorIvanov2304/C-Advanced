using System.Collections;

namespace Stack

{
    public class CustomStack<T>: IEnumerable<T>
    {
        private const int initialCapacity = 4;
        private T[] _stack;
        public int Count { get; private set; }
        public CustomStack()
        {
            this._stack = new T[initialCapacity];
        }

        //Този ForEach метод приема някакво действие, което не връща резултат. Например Console.Writeline();
        //Действието се подава от Program.cs
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(_stack[i]);
            }
        }
        public void Push(T element)
        {
            if (Count == _stack.Length)
            {
                IncreaseCapacity();
            }
            else
            {
                _stack[Count] = element;
            }
            Count++;
        }



        public T Pop()
        {
            CheckIfCountIsZero();
            T result = _stack[Count - 1];
            Count--;

            return result;
        }

        private void Resize()
        {
            T[] temp = new T[initialCapacity*2];
            for (int i = 0; i < _stack.Length; i++)
            {
                temp[i] = _stack[i];
            }
            _stack = temp;
        }

        public T Peek()
        {
            CheckIfCountIsZero();

            return _stack[Count - 1];
        }

        private void IncreaseCapacity()
        {
            T[] copy = new T[_stack.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = _stack[i];
            }
            _stack = copy;
        }

        private void CheckIfCountIsZero()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
