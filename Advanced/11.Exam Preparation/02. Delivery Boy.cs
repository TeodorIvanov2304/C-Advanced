using System.Numerics;

namespace _02._Delivery_Boy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                                 .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            char[,] matrix = new char[sizes[0], sizes[1]];
            int startingRow = 0;
            int startingCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                    if (matrix[row, col] == 'B')
                    {
                        startingRow = row;
                        startingCol = col;
                    }
                }
            }

            int currentRow = startingRow;
            int currentCol = startingCol;
            while (true) 
            {   
                string command = Console.ReadLine();
                Directions direction = (Directions)Enum.Parse(typeof(Directions), command);

                if (matrix[currentRow, currentCol] != 'R')
                {
                    matrix[currentRow, currentCol] = '.';
                }
                
                switch (direction)
                {
                    case Directions.down:
                        if (currentRow + 1 < sizes[0])
                        {
                            if (matrix[currentRow + 1,currentCol] == '-' 
                                || matrix[currentRow + 1, currentCol] == '.')
                            {
                                currentRow++;
                            }
                            else if (matrix[currentRow + 1, currentCol] == 'P')
                            {
                                currentRow++;
                                matrix[currentRow, currentCol] = 'R';
                                Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                                
                            }
                            else if(matrix[currentRow + 1, currentCol] == 'A')
                            {
                                currentRow++;
                                matrix[currentRow, currentCol] = 'P';
                                Console.WriteLine("Pizza is delivered on time! Next order...");
                                matrix[startingRow, startingCol] = 'B';
                                PrintMatrix(matrix);
                                return;
                            }
                        }
                        else
                        {
                            matrix[startingRow, startingCol] = ' ';
                            Console.WriteLine("The delivery is late. Order is canceled.");
                            PrintMatrix(matrix);
                            return;
                        }
                        break;
                    case Directions.up:
                        if (currentRow - 1 >= 0 )
                        {

                            if (matrix[currentRow - 1, currentCol] == '-'
                                || matrix[currentRow - 1, currentCol] == '.')
                            {
                                currentRow--;
                            }
                            else if (matrix[currentRow - 1, currentCol] == 'P')
                            {
                                currentRow--;
                                matrix[currentRow, currentCol] = 'R';
                                Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                                
                            }
                            else if (matrix[currentRow - 1, currentCol] == 'A')
                            {
                                currentRow--;
                                matrix[currentRow, currentCol] = 'P';
                                Console.WriteLine("Pizza is delivered on time! Next order...");
                                matrix[startingRow, startingCol] = 'B';
                                PrintMatrix(matrix);
                                return;
                            }
                        }
                        else
                        {
                            matrix[startingRow, startingCol] = ' ';
                            Console.WriteLine("The delivery is late. Order is canceled.");
                            PrintMatrix(matrix);
                            return;
                        }
                        break;
                    case Directions.left:
                        if (currentCol - 1 >= 0)
                        {
                            if (matrix[currentRow, currentCol - 1] == '-'
                                || matrix[currentRow, currentCol - 1] == '.')
                            {
                                currentCol--;
                            }
                            else if (matrix[currentRow, currentCol - 1] == 'P')
                            {
                                currentCol--;
                                matrix[currentRow, currentCol] = 'R';
                                Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                               
                            }
                            else if (matrix[currentRow, currentCol - 1] == 'A')
                            {
                                currentCol--;
                                matrix[currentRow, currentCol] = 'P';
                                Console.WriteLine("Pizza is delivered on time! Next order...");
                                matrix[startingRow, startingCol] = 'B';
                                PrintMatrix(matrix);
                                return;
                            }
                        }
                        else
                        {
                            matrix[startingRow, startingCol] = ' ';
                            Console.WriteLine("The delivery is late. Order is canceled.");
                            PrintMatrix(matrix);
                            return;
                        }
                        break;
                    case Directions.right:
                        if (currentCol + 1 < sizes[1])
                        {
                            if (matrix[currentRow, currentCol + 1] == '-'
                                || matrix[currentRow, currentCol + 1] == '.')
                            {
                                currentCol++;
                            }
                            else if (matrix[currentRow, currentCol + 1] == 'P')
                            {
                                currentCol++;
                                matrix[currentRow, currentCol] = 'R';
                                Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                                
                            }
                            else if (matrix[currentRow, currentCol + 1] == 'A')
                            {
                                currentCol++;
                                matrix[currentRow, currentCol] = 'P';
                                Console.WriteLine("Pizza is delivered on time! Next order...");
                                matrix[startingRow, startingCol] = 'B';
                                PrintMatrix(matrix);
                                return;
                            }
                        }
                        else
                        {
                            matrix[startingRow, startingCol] = ' ';
                            Console.WriteLine("The delivery is late. Order is canceled.");
                            PrintMatrix(matrix);
                            return;
                        }
                        break;
                    default:
                        break;
                }
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

        enum Directions
        {
            down,
            up,
            left,
            right
        }
    }
}