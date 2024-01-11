namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Четем масива от конзолата
            int[] rowsAndCols = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {

                //Даваше Runtime error без StringSplitOptions
                int[] rowValues = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            int maxSquareRow = 0;
            int maxSquareCol = 0;
            int maxSquareSum = int.MinValue;

            //Цикъла върти до - 2, за да не излизаме от границите на матрицата
            for (int row = 0; row < rows-2; row++)
            {
                for (int col = 0; col < cols-2; col++)
                {
                    int currentSqureSum = matrix[row, col]
                        + matrix[row, col + 1] 
                        + matrix[row, col + 2]
                        + matrix[row + 1, col]
                        + matrix[row +1, col + 1]
                        + matrix[row +1, col + 2]
                        + matrix[row + 2, col]
                        + matrix[row + 2, col + 1]
                        + matrix[row + 2, col + 2];

                    if (currentSqureSum > maxSquareSum)
                    {
                        maxSquareSum = currentSqureSum;
                        maxSquareRow = row;
                        maxSquareCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSquareSum}");

            Console.WriteLine($"{matrix[maxSquareRow, maxSquareCol]} {matrix[maxSquareRow, maxSquareCol + 1]} {matrix[maxSquareRow, maxSquareCol + 2]}");
            Console.WriteLine($"{matrix[maxSquareRow + 1, maxSquareCol]} {matrix[maxSquareRow + 1, maxSquareCol + 1]} {matrix[maxSquareRow + 1,maxSquareCol + 2]}");
            Console.WriteLine($"{matrix[maxSquareRow + 2, maxSquareCol]} {matrix[maxSquareRow +2, maxSquareCol +1]} {matrix[maxSquareRow + 2,maxSquareCol +2]}");
        }
    }
}