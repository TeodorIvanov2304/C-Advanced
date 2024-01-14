using System.Text;

namespace _05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadArrayFromConsole();

            char[,] matrix = new char[sizes[0], sizes[1]];

            int index = -1;

            string snake = Console.ReadLine();

            for (int row = 0; row < sizes[0]; row++)
            {

                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (index == snake.Length - 1)
                        {
                            index = -1;
                        }
                        index++;
                        matrix[row, col] = snake[index];
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {

                        if (index == snake.Length - 1)
                        {
                            index = -1;
                        }
                        index++;
                        matrix[row, col] = snake[index];
                    }
                }
            }

            PrintMatrix(matrix);


        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}