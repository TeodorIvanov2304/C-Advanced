namespace Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                                    .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();
            Lake lake = new(list);
            string result = string.Join(", ", lake);
            Console.WriteLine(result);
        }
    }
}