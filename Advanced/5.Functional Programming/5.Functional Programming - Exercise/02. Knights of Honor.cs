using System.Threading.Channels;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> honor = name => Console.WriteLine($"Sir {name}");
            Array.ForEach(names, honor);

            //Equivalent for the previous lines + Method
            //Action<string> honor2 = PrintHonor;
            //Array.ForEach(names, honor2);
        }

        //static void PrintHonor(string name)
        //{
        //    Console.WriteLine($"Sir {name}");
        //}
    }
}