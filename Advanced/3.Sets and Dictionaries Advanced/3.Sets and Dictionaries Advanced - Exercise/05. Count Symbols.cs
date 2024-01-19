namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> occurences = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {   
                char currentSymbol = text[i];
                if (occurences.ContainsKey(currentSymbol))
                {
                    occurences[currentSymbol]++;
                }
                else
                {
                    occurences[currentSymbol] = 1;
                }

            }

            foreach (var pair in occurences)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}