namespace _01._Recursive_Array_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            int index = 0;
            Console.WriteLine(Sum(array, index));
        }

        static int Sum(int[] array, int index)
        {
            if (index == array.Length-1)
            {
                return array[index];
            }

            return array[index] + Sum(array, index+1);
        }
    }
}