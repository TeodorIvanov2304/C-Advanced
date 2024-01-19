namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lines = Console.ReadLine()
                          .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            for (int i = 0; i < lines[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < lines[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            //С командата IntersectWith, двата сета се събират, и остават само НЕповтарящите се елементи в тях
            firstSet.IntersectWith(secondSet);
            //2-ри вариант
            //var newSet = firstSet.Intersect(secondSet);
            foreach (var number in firstSet)
            {
                Console.Write($"{number} ");
            }
        }
    }
}