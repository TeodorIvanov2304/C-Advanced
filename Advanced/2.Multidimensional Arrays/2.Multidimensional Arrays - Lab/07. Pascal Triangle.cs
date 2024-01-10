using System.Linq;

namespace _07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            //Създавме назъбен масив от тип Long, за да не превъртаме int, когато редовете минат 60!
            long[][] pascalTriangle = new long[size][];

            // Инициализиране на елемент от назъбен масив
            pascalTriangle[0] = new long[1] {1};

            //Пускаме фор-цикъл, и започваме от 1
            for (int row = 1; row < size; row++)
            {   
                //Паскал от индекс row = нов инт от реда + 1
                pascalTriangle[row] = new long[row + 1];

                //Пускаме for-loop, който ще върти докато не достигне големината на реда pascalTriangle[row].Length
                for (int col = 0; col < pascalTriangle[row].Length; col++)
                {
                    //Правим проверка, за да не излезнем от границите на масива надясно
                    if (col < pascalTriangle[row-1].Length)
                    {
                        //Паскал с индекси ред и колона = Паскал с индекси ред и колона + Паскал от ред - 1 от телущата колона
                        pascalTriangle[row][col] += pascalTriangle[row - 1][col];
                    }
                    
                    //Правим проверка, за да не излезнем от границите на масива наляво
                    if (col > 0)
                    {
                        //Паскал с индекси ред и колона = Паскал с индекси ред и колона + Паскал от ред - 1 от колона - 1(т.е едно нагоре и назад)
                        pascalTriangle[row][col] += pascalTriangle[row - 1][col - 1];
                    }
                    
                }

            }

            //Изпечатваме назъбения масив
            for (int row = 0; row < pascalTriangle.Length; row++)
            {
                for (int col = 0; col < pascalTriangle[row].Length; col++)
                {
                    Console.Write($"{pascalTriangle[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}