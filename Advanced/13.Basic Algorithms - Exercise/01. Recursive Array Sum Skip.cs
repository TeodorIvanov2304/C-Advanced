namespace _01._Recursive_Array_Sum_Skip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            Console.WriteLine(ArraySum(array));
        }

        static int ArraySum(int[] array)
        {
            if (array.Length == 1)
            {
                return array[0];
            }

            int[] restOfTheArray = array.Skip(1).ToArray();
            int restOfArraySum = ArraySum(restOfTheArray);

            return array[0] + restOfArraySum;
        }
    }
}