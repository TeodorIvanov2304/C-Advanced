using System.Transactions;

namespace _01._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Четем размерите на матрицата, като ги сплитваме по ", " (3,6 за задачата)
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            //Записваме бр. на редовете в променлива
            int rows = sizes[0];
            //Записваме бр. на колоните
            int cols = sizes[1];

            //Създаваме матрица, с големина колкото записаните променливи (3,6)
            int[,] matrix = new int[rows, cols];
            //Създаваме променлива, която ще пази сумата
            int sum = 0;

            //Пускаме фор-цикъл, който ще върти по редовете
            for (int row = 0; row < rows; row++)
            {   
                //Създаваме променлива, която ще пази стойностите за реда
                int[] rowValues = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                //Пускаме фор-цикъл, който ще върти по колоните
                for (int col = 0; col < cols; col++)
                {   
                    //Попълваме матицата със стойностите
                    //matrix, с размери row,col = стойностите rowValues с индекс col
                    matrix[row,col] = rowValues[col];
                    //Сумираме всички числа
                    sum += matrix[row, col];
                }
            }

            //Изпечатваме
            Console.WriteLine(rows);
            Console.WriteLine(cols);;
            Console.WriteLine(sum);
        }
    }
}