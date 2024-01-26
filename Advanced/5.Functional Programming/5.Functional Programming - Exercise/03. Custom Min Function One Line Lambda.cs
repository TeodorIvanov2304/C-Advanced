namespace _03._Custom_Min_Function_One_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] numbers = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();
            //Find min
            Func<int[], int> customMin = arr => arr.Min();
            //Find max
            Func<int[], int> customMax = arr => arr.Max();
            Console.WriteLine(customMin(numbers));
            Console.WriteLine(customMax(numbers));
        }
    }
}