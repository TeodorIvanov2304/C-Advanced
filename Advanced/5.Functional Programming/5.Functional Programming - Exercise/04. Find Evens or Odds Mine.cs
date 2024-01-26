namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                                 .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            int lowerBound = bounds[0];
            int upperBound = bounds[1];
            List<int> numbers = new List<int>();
            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            string command = Console.ReadLine();
            
            Predicate<int> even = x => x % 2 == 0;
            Predicate<int> odd = x => x % 2 != 0;
            
            if (command == "even")
            {
                List<int> evens = numbers.FindAll(even);
                Console.WriteLine(string.Join(" ", evens));
            }
            else if (command == "odd")
            {
                
                List<int> odds = numbers.FindAll(odd);
                Console.WriteLine(string.Join(" ", odds));
            }
            
        }
    }
}