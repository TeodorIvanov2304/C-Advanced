using System.Security.Cryptography.X509Certificates;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .Reverse()
                                 .ToArray();

            int divisor = int.Parse(Console.ReadLine());

            Predicate<int> predicate = n => n % divisor != 0;

            input = input.Where(n =>predicate(n)).ToArray();

            Console.WriteLine(string.Join(' ', input));

        }
    }
}