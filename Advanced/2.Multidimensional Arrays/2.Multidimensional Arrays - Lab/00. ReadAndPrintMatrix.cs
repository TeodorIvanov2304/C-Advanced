using System.Data;

namespace _00._ReadAndPrintMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrica = ReadMatrix(3,3);

            PrintMatrix(matrica);
        }

        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(Console.ReadLine());
                }
            }

            return matrix;
        }

        static int[,] PrintMatrix(int[,] matrix) 
        {   
            //GetLength(0) взима дължината на редовете
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }

            return matrix;
        }
    }

    
}