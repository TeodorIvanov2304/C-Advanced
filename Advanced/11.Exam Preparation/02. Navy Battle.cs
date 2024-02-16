namespace _02._Navy_Battle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] battleField = new char[size, size];

            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < size; row++)
            {
                string rowInfo = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    battleField[row, col] = rowInfo[col];
                    if (battleField[row, col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            int destroyedCruisers = 0;
            int minesHit = 0;

            while (true)
            {
                Directions direction = (Directions)Enum.Parse(typeof(Directions), Console.ReadLine());
                battleField[currentRow, currentCol] = '-';
                
                switch (direction)
                {
                    case Directions.up:

                        currentRow--;
                        if (battleField[currentRow, currentCol] == '*')
                        {
                            minesHit++;
                            battleField[currentRow, currentCol] = '-';
                            if (minesHit == 3)
                            {
                                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{currentRow}, {currentCol}]!");
                                battleField[currentRow, currentCol] = 'S';
                                PrintMatrix(battleField);
                                return;
                            }
                        }
                        else if (battleField[currentRow, currentCol] == 'C')
                        {
                            destroyedCruisers++;
                            battleField[currentRow, currentCol] = '-';
                            if (destroyedCruisers == 3)
                            {
                                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                                battleField[currentRow, currentCol] = 'S';
                                PrintMatrix(battleField);
                                return;
                            }
                        }
                        break;
                    case Directions.down:
                        currentRow++;
                        if (battleField[currentRow, currentCol] == '*')
                        {
                            minesHit++;
                            battleField[currentRow, currentCol] = '-';
                            if (minesHit == 3)
                            {
                                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{currentRow}, {currentCol}]!");
                                battleField[currentRow, currentCol] = 'S';
                                PrintMatrix(battleField);
                                return;
                            }
                        }
                        else if (battleField[currentRow, currentCol] == 'C')
                        {
                            destroyedCruisers++;
                            battleField[currentRow, currentCol] = '-';
                            if (destroyedCruisers == 3)
                            {
                                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                                battleField[currentRow, currentCol] = 'S';
                                PrintMatrix(battleField);
                                return;
                            }
                        }
                        break;
                    case Directions.left:
                        currentCol--;
                        if (battleField[currentRow, currentCol] == '*')
                        {
                            minesHit++;
                            battleField[currentRow, currentCol] = '-';
                            if (minesHit == 3)
                            {
                                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{currentRow}, {currentCol}]!");
                                battleField[currentRow, currentCol] = 'S';
                                PrintMatrix(battleField);
                                return;
                            }
                        }
                        else if (battleField[currentRow, currentCol] == 'C')
                        {
                            destroyedCruisers++;
                            battleField[currentRow, currentCol] = '-';
                            if (destroyedCruisers == 3)
                            {
                                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                                battleField[currentRow, currentCol] = 'S';
                                PrintMatrix(battleField);
                                return;
                            }
                        }
                        break;
                    case Directions.right:
                        currentCol++;
                        if (battleField[currentRow, currentCol] == '*')
                        {
                            minesHit++;
                            battleField[currentRow, currentCol] = '-';
                            if (minesHit == 3)
                            {
                                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{currentRow}, {currentCol}]!");
                                battleField[currentRow, currentCol] = 'S';
                                PrintMatrix(battleField);
                                return;
                            }
                        }
                        else if (battleField[currentRow, currentCol] == 'C')
                        {
                            destroyedCruisers++;
                            battleField[currentRow, currentCol] = '-';
                            if (destroyedCruisers == 3)
                            {
                                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                                battleField[currentRow, currentCol] = 'S';
                                PrintMatrix(battleField);
                                return;
                            }
                        }
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
            up,
            down,
            left,
            right
        }
    }
}