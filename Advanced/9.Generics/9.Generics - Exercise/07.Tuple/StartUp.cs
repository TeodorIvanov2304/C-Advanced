namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] namesTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            CustomTuple<string, string> tuple = new Tuple.CustomTuple<string, string>(namesTokens[0]+" " + namesTokens[1], namesTokens[2]);
            Console.WriteLine(tuple);

            string[] beerTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            CustomTuple<string,int> secondTuple = new CustomTuple<string, int>(beerTokens[0], int.Parse(beerTokens[1]));
            Console.WriteLine(secondTuple);

            string[] numbersToken = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            CustomTuple<int,double>  thirdTuple = new CustomTuple<int, double>(int.Parse(numbersToken[0]), double.Parse(numbersToken[1]));
            Console.WriteLine(thirdTuple);
        }
    }
}