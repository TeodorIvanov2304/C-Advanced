
namespace ReadingJaggedArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //READ JAGGED ARRAY
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                //Съкратено четене на назъбен масив
                //int[] rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray(); ЕКВИВАЛЕНТНО
                //jagged[row] = rowValues;
                jagged[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            //PRINT JAGGED ARRAY

            //Изпечатваме, като въртим до дължината на масива jagged.Length
            for (int row = 0; row < jagged.Length; row++)
            {
                //Индексът на реда jagged[row].Lenght
                for (int col = 0; col < jagged[row].Length; col++)
                {   
                    //Изпечатваме като подаваме индекси [row][col]
                    Console.Write($"{jagged[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}