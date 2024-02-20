namespace _00.Simple_Recursion
{
    public class Program
    {
        static void Main(string[] args)
        {
            RecursiveForCycle(10);
        }

        //Function, that calls itself until is equal to zero
        static void RecursiveForCycle(int n)
        {
            if (n <= 0)
            {
                return;
            }
            Console.WriteLine($"Before recursion {n}");
            RecursiveForCycle(n - 1);

            //The recursion allways comes back, in reverse order 
            Console.WriteLine($"After recursion {n}");
        }
    }
}