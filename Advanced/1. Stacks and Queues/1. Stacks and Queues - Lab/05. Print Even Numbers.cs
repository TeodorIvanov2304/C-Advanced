namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            // Създаваме масив, в който записваме входа
            int[] arrayOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //Създаваме опашка, в която ще записваме числата от масива
            Queue<int> queueOfNumbers = new Queue<int>();

            //Записваме числата от масива в опашка, с помощта на for-loop
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                queueOfNumbers.Enqueue(arrayOfNumbers[i]);
            }
            //Създаваме опашкка, тип Queue<int>, в която ще записваме четните числа
            Queue<int> evenQueue = new Queue<int>();
            //Пускаме цикъл, който върти докато в опашката в числата няма нищо
            while (queueOfNumbers.Count>0)
            {   
                //Създаваме променлива, която ще пази изваденото от опашката число
                int currentNumber = queueOfNumbers.Dequeue();
                //Ако чилото е четно, го записваме в новата опашка  Queue<int> evenQueue 
                if (currentNumber % 2 == 0)
                {
                    evenQueue.Enqueue(currentNumber);
                }
            }

            //Изпечатваме със String.Join + ","
            Console.WriteLine(string.Join(", ",evenQueue));

        }
    }
}