namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToArray();

            int[] sortedIntegers = integers.OrderByDescending(x => x).ToArray();

            //Алтернатива на break:
            //int count = numbers.Length >= 3 ? 3 : numbers.Length; - ако дължината е по-малка от 3, count = дължината. После пускаме for-loop до count
            // for (int i = 0; i < count; i++)

            for (int i = 0; i < 3; i++)
            {   
                if (sortedIntegers.Length<3 && i == sortedIntegers.Length)
                {
                    break;
                }
                Console.Write($"{sortedIntegers[i]} ");
            }
        }
    }
}