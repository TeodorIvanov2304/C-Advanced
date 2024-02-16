using System.Text.RegularExpressions;

namespace _02._Blind_Man_s_Buff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            char[,] matrix = new char[sizes[0], sizes[1]];
            int currentRow = 0;
            int currentCol = 0;
            string pattern = @"\S";

            for (int row = 0; row < sizes[0]; row++)
            {
                string rowInput = Console.ReadLine();
                string input = "";
                input = RemoveSpaces(pattern, rowInput, input);
                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'B')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }



            int moves = 0;
            int touchedOpponents = 0;
            string command = "";

            while ((command = Console.ReadLine()) != "Finish")
            {
                Directions direction = (Directions)Enum.Parse(typeof(Directions), command);
                switch (direction)
                {
                    case Directions.up:
                        if (currentRow - 1 >= 0)
                        {
                            if (matrix[currentRow - 1, currentCol] == 'O')
                            {
                                continue;
                            }
                            currentRow--;
                            
                            if (matrix[currentRow, currentCol] == '-')
                            {
                                moves++;
                            }
                            else if (matrix[currentRow, currentCol] == 'P')
                            {
                                matrix[currentRow, currentCol] = '-';
                                moves++;
                                touchedOpponents++;
                                if (touchedOpponents == 3)
                                {
                                    Console.WriteLine("Game over!");
                                    Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {moves}");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case Directions.down:
                        if (currentRow + 1 < sizes[0])
                        {
                            if (matrix[currentRow + 1, currentCol] == 'O')
                            {
                                continue;
                            }
                            currentRow++;
                            
                            if (matrix[currentRow, currentCol] == '-')
                            {
                                moves++;
                            }
                            else if (matrix[currentRow, currentCol] == 'P')
                            {
                                matrix[currentRow, currentCol] = '-';
                                moves++;
                                touchedOpponents++;
                                if (touchedOpponents == 3)
                                {
                                    Console.WriteLine("Game over!");
                                    Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {moves}");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case Directions.left:
                        if (currentCol - 1 >= 0)
                        {
                            if (matrix[currentRow, currentCol - 1] == 'O')
                            {
                                continue;
                            }
                            currentCol--;
                            if (matrix[currentRow, currentCol] == '-')
                            {
                                moves++;
                            }
                            else if (matrix[currentRow, currentCol] == 'P')
                            {
                                matrix[currentRow, currentCol] = '-';
                                moves++;
                                touchedOpponents++;
                                if (touchedOpponents == 3)
                                {
                                    Console.WriteLine("Game over!");
                                    Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {moves}");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case Directions.right:
                        if (currentCol + 1 < sizes[1])
                        {
                            if (matrix[currentRow, currentCol + 1] == 'O')
                            {
                                continue;
                            }
                            currentCol++;
                            if (matrix[currentRow, currentCol] == '-')
                            {
                                moves++;
                            }
                            else if (matrix[currentRow, currentCol] == 'P')
                            {
                                matrix[currentRow, currentCol] = '-';
                                moves++;
                                touchedOpponents++;
                                if (touchedOpponents == 3)
                                {
                                    Console.WriteLine("Game over!");
                                    Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {moves}");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                        break;

                }
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {moves}");

        }

        public static string RemoveSpaces(string pattern, string rowInput, string input)
        {
            foreach (var match in Regex.Matches(rowInput, pattern))
            {
                input = input + match;
            }

            return input;
        }

        enum Directions
        {
            up,
            down,
            left,
            right
        }

    }
}