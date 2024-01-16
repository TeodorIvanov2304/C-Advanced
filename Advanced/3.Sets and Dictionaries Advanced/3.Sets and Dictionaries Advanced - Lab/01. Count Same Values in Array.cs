namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                                          .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                          .Select(double.Parse)
                                          .ToList();

            Dictionary<double,int> times = new Dictionary<double,int>();

            foreach (var number in numbers) 
            {
                if (!times.ContainsKey(number))
                {
                    times[number] = 0;
                }

                times[number]++;
            }

            foreach (KeyValuePair<double,int> kvp in times)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}