namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);


            Predicate<string> capitalLetters = word => char.IsUpper(word[0]);

            //Предикатите често се използват с Where, после се дава ToArray()
            words = words.Where(w=>capitalLetters(w)).ToArray();

            foreach(string word in words) 
            {
                Console.WriteLine(word);
            }
        }
    }
}