namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] namesTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            string[] beerTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] bankTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, string, string> names = new($"{namesTokens[0]} {namesTokens[1]}", namesTokens[2], namesTokens[3]);
            Threeuple<string, int, bool> beer = new(beerTokens[0], int.Parse(beerTokens[1]), beerTokens[2] == "drunk");
            Threeuple<string, double, string> bank = new(bankTokens[0], double.Parse(bankTokens[1]), bankTokens[2]);

            Console.WriteLine(names);
            Console.WriteLine(beer);
            Console.WriteLine(bank);


        }
    }
}