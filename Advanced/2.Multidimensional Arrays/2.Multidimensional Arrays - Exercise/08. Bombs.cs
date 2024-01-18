

namespace _08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizes, sizes];
            PopulateMatrix(matrix);

            string[] bombsCoordinates = Console.ReadLine()
                                        .Split()
                                        .ToArray();
            Bomb(sizes, matrix, bombsCoordinates);

            int aliveCellCounter = 0;
            int aliveCellsSum = 0;

            CountAndSumCells(sizes, matrix, ref aliveCellCounter, ref aliveCellsSum);

            Console.WriteLine($"Alive cells: {aliveCellCounter}");
            Console.WriteLine($"Sum: {aliveCellsSum}");

            PrintMatrix(matrix);

        }

        private static void Bomb(int sizes, int[,] matrix, string[] bombsCoordinates)
        {
            for (int i = 0; i < bombsCoordinates.Length; i++)
            {
                string[] coordinates = bombsCoordinates[i].Split(",");
                int currentRow = int.Parse(coordinates[0]);
                int currentCol = int.Parse(coordinates[1]);
                int bombValue = matrix[currentRow, currentCol];

                if (bombValue <= 0)
                {
                    continue;
                }
                if (IsValid(currentRow, currentCol - 1, sizes))
                {

                    if (matrix[currentRow, currentCol - 1] > 0)
                    {
                        matrix[currentRow, currentCol - 1] -= bombValue;
                    }
                }
                if (IsValid(currentRow, currentCol + 1, sizes))
                {
                    if (matrix[currentRow, currentCol + 1] > 0)
                    {
                        matrix[currentRow, currentCol + 1] -= bombValue;
                    }
                }
                if (IsValid(currentRow - 1, currentCol, sizes))
                {
                    if (matrix[currentRow - 1, currentCol] > 0)
                    {
                        matrix[currentRow - 1, currentCol] -= bombValue;
                    }
                }
                if (IsValid(currentRow + 1, currentCol, sizes))
                {
                    if (matrix[currentRow + 1, currentCol] > 0)
                    {
                        matrix[currentRow + 1, currentCol] -= bombValue;
                    }
                }
                if (IsValid(currentRow - 1, currentCol - 1, sizes))
                {
                    if (matrix[currentRow - 1, currentCol - 1] > 0)
                    {
                        matrix[currentRow - 1, currentCol - 1] -= bombValue;
                    }
                }
                if (IsValid(currentRow - 1, currentCol + 1, sizes))
                {
                    if (matrix[currentRow - 1, currentCol + 1] > 0)
                    {
                        matrix[currentRow - 1, currentCol + 1] -= bombValue;
                    }
                }
                if (IsValid(currentRow + 1, currentCol - 1, sizes))
                {
                    if (matrix[currentRow + 1, currentCol - 1] > 0)
                    {
                        matrix[currentRow + 1, currentCol - 1] -= bombValue;
                    }
                }
                if (IsValid(currentRow + 1, currentCol + 1, sizes))
                {
                    if (matrix[currentRow + 1, currentCol + 1] > 0)
                    {
                        matrix[currentRow + 1, currentCol + 1] -= bombValue;
                    }
                }

                matrix[currentRow, currentCol] = 0;
            }
        }

        private static void CountAndSumCells(int sizes, int[,] matrix, ref int aliveCellCounter, ref int aliveCellsSum)
        {
            for (int row = 0; row < sizes; row++)
            {
                for (int col = 0; col < sizes; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCellCounter++;
                        aliveCellsSum += matrix[row, col];
                    }
                }
            }
        }

        private static void PopulateMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowValues = ReadIntArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();
        }

        static bool IsValid(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }

        static int[,] PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            return matrix;
        }
    }
}