using System.ComponentModel;
using System.Numerics;

namespace _09._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());


            string[] directions = Console.ReadLine()
                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[size, size];
            int currentRow = 0;
            int currentCol = 0;
            int totalCoal = 0;

            for (int row = 0; row <= size - 1; row++)
            {

                char[] symbol = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();


                for (int col = 0; col <= size - 1; col++)
                {
                    matrix[row, col] = symbol[col];

                    //Ако символът[колона] = s, стартовия ред е равен на реда, а стартовата колона, на колоната
                    //на които сме в момента

                    if (symbol[col] == 's')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    else if (symbol[col] == 'c')
                    {
                        totalCoal++;
                    }
                }
            }

            //За всяка команда, получена от входа
            foreach (string direction in directions)
            {
                switch (direction)
                {
                    //Колоната се намалява с 1
                    case "left":
                        //Валидираме, че няма да излезнем от матрицата
                        if (currentCol - 1 >= 0 && currentCol - 1 <= size - 1)
                        {
                            currentCol--;

                            if (matrix[currentRow, currentCol] == 'c')
                            {

                                matrix[currentRow, currentCol] = '*';
                                totalCoal--;

                                if (totalCoal == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                    Environment.Exit(0);
                                }
                            }
                            else if (matrix[currentRow, currentCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                                Environment.Exit(0);
                            }
                        }

                        break;
                    //Колоната се увеличава с 1
                    case "right":
                        if (currentCol + 1 >= 0 && currentCol + 1 <= size - 1)
                        {
                            currentCol++;

                            if (matrix[currentRow, currentCol] == 'c')
                            {
                                matrix[currentRow, currentCol] = '*';
                                totalCoal--;

                                if (totalCoal == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                    Environment.Exit(0);
                                }
                            }
                            else if (matrix[currentRow, currentCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                                Environment.Exit(0);
                            }
                        }

                        break;
                    //Реда се намалява с 1
                    case "up":
                        if (currentRow - 1 >= 0 && currentRow - 1 <= size - 1)
                        {
                            currentRow--;

                            if (matrix[currentRow, currentCol] == 'c')
                            {
                                matrix[currentRow, currentCol] = '*';
                                totalCoal--;

                                if (totalCoal == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                    Environment.Exit(0);
                                }
                            }
                            else if (matrix[currentRow, currentCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                                Environment.Exit(0);
                            }
                        }

                        break;
                    //Реда се увеличава с 1
                    case "down":
                        if (currentRow + 1 >= 0 && currentRow + 1 <= size - 1)
                        {
                            currentRow++;
                            totalCoal = Play(matrix, currentRow, currentCol, totalCoal);
                        }

                        break;

                }
            }

            Console.WriteLine($"{totalCoal} coals left. ({currentRow}, {currentCol})");
        }

        private static int Play(char[,] matrix, int currentRow, int currentCol, int totalCoal)
        {
            if (matrix[currentRow, currentCol] == 'c')
            {
                matrix[currentRow, currentCol] = '*';
                totalCoal--;

                if (totalCoal == 0)
                {
                    Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                    Environment.Exit(0);
                }
            }
            else if (matrix[currentRow, currentCol] == 'e')
            {
                Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                Environment.Exit(0);
            }

            return totalCoal;
        }

    }
}