namespace _02._Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            List<int> numbers = new List<int>(10);
            
            while (numbers.Count < 10)
            {
                
                try
                {
                    int number = ReadNumber(start, end);
                    numbers.Add(number);
                    start = number;
                }
                catch (FormatException fa)
                {

                    Console.WriteLine("Invalid Number!");
                }
                catch (ArgumentOutOfRangeException ae)
                {
                    Console.WriteLine($"Your number is not in range {start} - 100!");
                }
            }
            Console.WriteLine(string.Join(", ",numbers));
        }

        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int number;
            bool isGood = int.Parse(input) > start && int.Parse(input) < end;
            bool IsANumber = int.TryParse(input, out number);
            if (IsANumber && isGood)
            {
                return number;
            }
            else if(!IsANumber)
            {
                throw new FormatException();
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}