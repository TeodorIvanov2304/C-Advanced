namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Action is allways void
            Action<string> print = name => Console.WriteLine(name);
            string[] names = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //Използваме клас Array и метода Foreach, като за параметри му подаваме масива, и анонимната ламбда функция Action<string> print
            Array.ForEach(names, print);

            //Алтернативно изписване, + метода Print. Да се обърне внимание, че не се слагат () след принт, когато той е референция!
            //Action<string> print2 = Print;
            //Array.ForEach(names, print2);
        }

        static void Print(string s)
        {
            Console.WriteLine(s);
        }
    }
}