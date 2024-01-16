namespace _05._Snake_Moves_2nd_Variation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadIntArray();
            string snake = Console.ReadLine();

            //Създаваме матрицата и я запълваме
            string[,] matrix = new string[sizes[0], sizes[1]];
            int snakeCounter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {   
                        //Даваме му ToString, защото иначе връща char
                        matrix[row, col] = snake[snakeCounter].ToString();
                        snakeCounter = GetSnakeValue(snake, snakeCounter);
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[snakeCounter].ToString();
                        snakeCounter = GetSnakeValue(snake, snakeCounter);
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }

        //Метод за броене на буквите от змията. Ако змията(буквите на стринга) свъши, нулираме
        static int GetSnakeValue(string snake, int snakeCounter)
        {
            snakeCounter++;

            if (snakeCounter >= snake.Length)
            {
                snakeCounter = 0;
            }
            return snakeCounter;
        }
        
        //Метод за четене на матрицата
        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();
        }
    }
}