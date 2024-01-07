// Само подменихме Stack с Queue, и Pop() c Dequeue() !!!

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int valuesToPush = values[0];
            int valuesToPop = values[1];
            int lookUpValue = values[2];

            //Съкратено пълнене на стека, без for-loop
            Queue<int> stack = new Queue<int>(input.Take(valuesToPush));

            //for (int i = 0; i < valuesToPush; i++)
            //{
            //    stack.Push(input[i]);

            //}

            while (stack.Count > 0 && valuesToPop > 0)
            {
                stack.Dequeue();
                valuesToPop--;
            }
            //Използваме Contains, вместо да сравняваме стойностите 1 по 1
            if (stack.Contains(lookUpValue))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}