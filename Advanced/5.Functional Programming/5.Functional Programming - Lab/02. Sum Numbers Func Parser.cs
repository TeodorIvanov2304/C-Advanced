namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            //Създаваме функция parser, която приема string и връща int. Правим ламбда функция n=> int.Parse(n)
            //После вместо всеки път да пишем int.Parse пишем само parser
            Func<string, int> parser = n => int.Parse(n);

            int[] numbers = input.Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(parser)
                                 .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}