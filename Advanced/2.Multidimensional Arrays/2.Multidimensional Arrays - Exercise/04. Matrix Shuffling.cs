namespace _04._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {

                string[] rowValues = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col].ToString();
                }
            }

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split();
                string command = inputArgs[0];

                if (command != "swap" 
                    || inputArgs.Length < 5 
                    || inputArgs.Length > 5
                    || int.Parse(inputArgs[1]) > matrix.GetLength(0)
                    || int.Parse(inputArgs[2]) > matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string valuesToSwap = matrix[int.Parse(inputArgs[1]), int.Parse(inputArgs[2])];
                matrix[int.Parse(inputArgs[1]), int.Parse(inputArgs[2])] = matrix[int.Parse(inputArgs[3]), int.Parse(inputArgs[4])];
                matrix[int.Parse(inputArgs[3]), int.Parse(inputArgs[4])] = valuesToSwap;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}