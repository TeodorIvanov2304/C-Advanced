using System.Text;

namespace _01.ImplementingStackAndQueue
{
    public class CustomList
    {
        //С регионите може да отделяме частите на класа една от друга за повече четимост
        #region FieldsAndProperties 

        private const int initialCapacity = 2;
        private int[] items;

        //Когато напишем private set, значи че стойността на Count може да се задава само от класа
        public int Count { get; private set; } = 0; //Инициализираме начална стойност 0. Масива започва от 0
        public int this[int index]
        {

            get
            {
                if (index >= Count || index <0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }


            set
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }

        #endregion


        public CustomList()
        {
            items = new int[initialCapacity];
        }


        //По този начин пишем описанитео на самия тип, метод и т.н
        /// <summary>
        /// This is a method to add an element to the list! ХО-ХО-ХО
        /// </summary>
        /// <param name="element"></param>

        public void Add(int element)
        {
            if (Count >= items.Length)
            {
                Resize();
            }
            items[Count] = element;
            Count++;
        }



        public int RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            int result = items[index];
            //Преместваме целия масива наляво, след като сме премахнали елемента
            ShiftLeft(index);
            Count--;

            if (Count <= items.Length / 4)
            {
                ShrinkCapacity();
            }
            return result;
        }





        /// <summary>
        /// Is element present in the array
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(int element)
        {
            //Даваме граница на цикъла Count, защото items.Length може да съдържа празни елементи
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if(CheckIsIndexValid(firstIndex, secondIndex))
            {
                throw new ArgumentOutOfRangeException();
            }
            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                sb.Append($"{items[i]} ");
            }
            return sb.ToString().TrimEnd();
        }

        private bool CheckIsIndexValid(int firstIndex, int secondIndex)
        {
            return (firstIndex < 0
                            || secondIndex < 0
                            || firstIndex >= Count
                            || secondIndex >= Count);
            
        }

        //Метод за увеличаване на масива
        //Private методите стоят най-отдолу
        private void Resize()
        {
            //Създаваме нов масив с двойна големина
            int[] copy = new int[items.Length * 2];

            //Пълним го със старите стойности
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            //Подаваме нова референция на items, то вече сочи към копи и е неговия размер
            items = copy;
        }

        public void InsertAt(int index, int element)
        {
            if (index < 0 || index > Count) 
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count == items.Length)
            {
                Resize();
            }

            Count++;
            ShiftToRight(index);
            items[index] = element;
        }

        private void ShiftLeft(int index)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }
        private void ShiftToRight(int index)
        {
            for (int i = Count - 1; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }

        private void ShrinkCapacity()
        {
            int[] copy = new int[items.Length / 2];

            //Пълним го със старите стойности
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
    }
}
