using System.Diagnostics;
using System.Reflection.Metadata;

namespace ComplexityComarison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 100_000;

            ConstantTime(n);
            LinearTime(n);
            //NlogN and Quadratic are doing the same thing, but NlogN is way faster
            NlogNTime(n);
            QuadraticTime(n);

            //The slolest time! For 13 elements = 6 seconds
            Console.Write($"Exponential time O(n^n) {n} -> ");
            Stopwatch stopwatch = Stopwatch.StartNew();
            ExponentialTime(n,0);
            stopwatch.Stop();
            

        }

        static void ConstantTime(int n)
        {
            Console.Write($"Constant time {n} -> ");
            HashSet<int> set = new HashSet<int>(Enumerable.Range(0,n));
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < n; i++)
            {
                set.Contains(i);
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds); // 1,1 sec for 100_000_000 elements with HashSet
        }

        static void LinearTime(int n)
        {
            Console.Write($"Linear time {n} -> ");
            Random r = new Random();
            List<int> list = new List<int>(Enumerable.Range(0, n));
            Stopwatch stopwatch = Stopwatch.StartNew();

            list.Contains(r.Next(0,n));
            
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds); 
        }

        static void NlogNTime(int n)
        {
            Console.Write($"N LogN time O(nlog(n)) {n} -> ");
            Random r = new Random();
            List<int> list = new List<int>(Enumerable.Range(0, n));
            Stopwatch stopwatch = Stopwatch.StartNew();
            int[] test = new int[5];
            for (int i = 0; i < test.Length; i++)
            {
                list.Add(r.Next(0, n));
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        //Good for under 40 000 elements
        static void QuadraticTime(int n)
        {
            Console.Write($"Quadratic time O(n^2) {n} -> ");
            Random r = new Random();
            List<int> list = new List<int>(Enumerable.Range(0, n));
            Stopwatch stopwatch = Stopwatch.StartNew();

            //Selection sort - Quadratic time
            var arrayLength = list.Count;
            for (int i = 0; i < arrayLength - 1; i++)
            {
                var smallestValue = i;
                for (int j = i + 1; j < arrayLength; j++)
                {
                    if (list[j] < list[smallestValue])
                    {
                        smallestValue = j;
                    }
                }
                var tempVarable = list[smallestValue];
                list[smallestValue] = list[i];
                list[i] = tempVarable;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        //Slowest
        static void ExponentialTime(int n, int start)
        {
            for (int i = start; i < n; i++)
            {
                ExponentialTime(n, start + 1);
            }
        }
    }

    
}