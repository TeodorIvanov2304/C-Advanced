namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> predicate = x => x.Length <= length;

            string[] sorted = names.Where(n=>predicate(n)).ToArray();
            Console.WriteLine(string.Join("\n",sorted));
        }
    }
}