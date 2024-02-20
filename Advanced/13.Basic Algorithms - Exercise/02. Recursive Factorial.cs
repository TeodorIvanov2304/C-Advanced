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
            if (n == 1)
            {
                return 1;
            }

            //Use recursion
            int result = n * RecursiveFactorial(n - 1);
            return result;
        }
    }
}