namespace _02._Recursive_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read from the console
            Console.WriteLine(RecursiveFactorial(int.Parse(Console.ReadLine())));
        }

        //Method for finding factorial
        static int RecursiveFactorial(int n)
        {
            Console.WriteLine($"{n}! = {n} * {n - 1}!");

            if (n == 1)
            {
                return 1;
            }
            //Console.WriteLine("Before recursion");
            //Use recursion
            int result = RecursiveFactorial(n - 1);
            Console.WriteLine($"{n}! = {n} * {result}");
            return n * result;
        }
    }
}