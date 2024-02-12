
using System.Numerics;

namespace _02._Fishing_Competition
{
    public class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizes, sizes];
            int currentRow = 0;
            int currentCol = 0;

            

            for (int row = 0; row < sizes; row++)
            {
                string matrixInfo = Console.ReadLine();

                for (int col = 0; col < sizes; col++)
                {
                    matrix[row, col] = matrixInfo[col];

                    if (matrix[row, col] == 'G')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string command = "";
            bool isOutOfRange = false;
            bool isJackPot = false;
            int currentMoney = 100;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "up" && currentRow - 1 >= 0)
                {
                    if (matrix[currentRow - 1, currentCol] == 'W')
                    {
                        currentMoney += 100;
                    }
                    else if (matrix[currentRow - 1, currentCol] == 'P')
                    {
                        currentMoney -= 200;
                    }
                    else if (matrix[currentRow - 1, currentCol] == 'J')
                    {
                        isJackPot = true;
                        matrix[currentRow, currentCol] = '-';
                        currentRow--;
                        matrix[currentRow, currentCol] = 'G';
                        break;
                    }

                    matrix[currentRow, currentCol] = '-';
                    currentRow--;
                    matrix[currentRow, currentCol] = 'G';
                }
                else if (command == "down" && currentRow + 1 < sizes)
                {
                    if (matrix[currentRow + 1, currentCol] == 'W')
                    {
                        currentMoney += 100;
                    }
                    else if (matrix[currentRow + 1, currentCol] == 'P')
                    {
                        currentMoney -= 200;
                    }
                    else if (matrix[currentRow + 1, currentCol] == 'J')
                    {
                        isJackPot = true;
                        matrix[currentRow, currentCol] = '-';
                        currentRow++;
                        matrix[currentRow, currentCol] = 'G';
                        break;
                    }

                    matrix[currentRow, currentCol] = '-';
                    currentRow++;
                    matrix[currentRow, currentCol] = 'G';
                }
                else if (command == "left" && currentCol - 1 >= 0)
                {
                    if (matrix[currentRow, currentCol - 1] == 'W')
                    {
                        currentMoney += 100;
                    }
                    else if (matrix[currentRow, currentCol - 1] == 'P')
                    {
                        currentMoney -= 200;
                    }
                    else if (matrix[currentRow, currentCol - 1] == 'J')
                    {
                        isJackPot = true;
                        matrix[currentRow, currentCol] = '-';
                        currentCol--;
                        matrix[currentRow, currentCol] = 'G';
                        break;
                    }
                    matrix[currentRow, currentCol] = '-';
                    currentCol--;
                    matrix[currentRow, currentCol] = 'G';
                }
                else if (command == "right" && currentCol + 1 < sizes)
                {
                    if (matrix[currentRow, currentCol + 1] == 'W')
                    {
                        currentMoney += 100;
                    }
                    else if (matrix[currentRow, currentCol + 1] == 'P')
                    {
                        currentMoney -= 200;
                    }
                    else if (matrix[currentRow, currentCol + 1] == 'J')
                    {
                        isJackPot = true;
                        matrix[currentRow, currentCol] = '-';
                        currentCol++;
                        matrix[currentRow, currentCol] = 'G';
                        break;
                    }
                    matrix[currentRow, currentCol] = '-';
                    currentCol++;
                    matrix[currentRow, currentCol] = 'G';
                }
                else
                {
                    isOutOfRange = true;
                    break;
                }


                if (currentMoney <= 0)
                {
                    break;
                }

            }

            if (isOutOfRange || currentMoney <= 0)
            {
                Console.WriteLine("Game over! You lost everything!");
                Environment.Exit(0);
            }

            if (isJackPot)
            {
                currentMoney += 100_000;
                Console.WriteLine("You win the Jackpot!");
                Console.WriteLine($"End of the game. Total amount: {currentMoney}$");
            }
            else
            {
                Console.WriteLine($"End of the game. Total amount: {currentMoney}$");
            }

            if (currentMoney > 0)
            {
                PrintMatrix(matrix);
            }
        }
        static void PrintMatrix(char[,] matrix)
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
    }
}
            


