namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .Where(n => n % 2 == 0) //Където n е четно число
                            .OrderBy(n => n)        //Подреждаме във възходящ ред
                            .ToArray();

            Console.WriteLine(string.Join(", ", numbers));


        }
    }
}