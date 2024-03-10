namespace _01._Square_Root
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine(SquareRoot(number));
                
            }
            catch (FormatException fe)
            {

                Console.WriteLine(fe.Message);
            }
            finally 
            {
                Console.WriteLine("Goodbye.");
            }
        }

        public static double SquareRoot(int number)
        {
            CheckForNegativeNumber(number);

            return Math.Sqrt(number);
        }

        public static void CheckForNegativeNumber(int number)
        {
            if (number < 0)
            {
                throw new FormatException("Invalid number.");
            }
        }
    }

    
}