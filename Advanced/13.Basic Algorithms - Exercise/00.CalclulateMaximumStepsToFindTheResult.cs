using System.Reflection.Metadata;

namespace CalclulateMaximumStepsToFindTheResult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 100;
            Console.WriteLine(GetOperationsCount(n));
            //Estimation T(n) = 3(n^2) + 3n + 3;
            //constant O(1) n = 1 000 → 1 - 2 operations
            //logarithmic O(log n) n = 1 000 → 10 operations
            //linear O(n) n = 1 000 → 1 000 operations
            //linearithmic O(n * log n) n = 1 000 → 10 000 operations
            //quadratic O(n2) n = 1 000 → 1 000 000 operations
            //cubic O(n3) n = 1 000 → 1 000 000 000 operations
            //exponential O(n ^ n) n = 10 → 10 000 000 000 operations
        }

         static long GetOperationsCount(int n)
        {
            long counter = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    counter++;
            return counter;
        }
    }
}