namespace _04._Find_Evens_or_Odds_With_1_Predicate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToArray();

            string criteria = Console.ReadLine();
            int start = bounds[0];
            int end = bounds[1];

            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            //Задаваме му начална стойност true
            Predicate<int> predicate = x => true;

            if (criteria == "even")
            {
                predicate = i => i % 2 == 0;
            }
            else if (criteria == "odd")
            {
                predicate = i => i % 2 != 0;
            }

            //За да използваме предиката с Where, трябва да му зададем new Func, от типа който ни трябва и в скоби му даваме predicate , и после ToList()
            List<int> filtered = numbers.Where(new Func<int, bool> (predicate)).ToList();
            Console.WriteLine(string.Join(" ", filtered));
        }
    }
}