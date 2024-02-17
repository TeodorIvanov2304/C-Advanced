namespace _02._Clear_Skies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] airspace = new char[size,size];

            int enemies = 0;
            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < size; row++)
            {   
                string rowInfo = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    airspace[row,col] = rowInfo[col];
                    if (airspace[row,col] == 'J')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    if (airspace[row, col] == 'E')
                    {
                        enemies++;
                    }
                }
            }

            int armor = 300;
            while (true)
            {
                Directions direction = (Directions)Enum.Parse(typeof(Directions), Console.ReadLine());
                airspace[currentRow, currentCol] = '-';

                switch (direction)
                {
                    case Directions.up:
                        currentRow--;
                        if (airspace[currentRow,currentCol] == 'E')
                        {
                            if (enemies > 1)
                            {
                                enemies--;
                                airspace[currentRow, currentCol] = '-';
                                armor -= 100;
                                if (armor == 0)
                                {
                                    Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currentRow}, {currentCol}]!");
                                    airspace[currentRow, currentCol] = 'J';
                                    PrintMatrix(airspace);
                                    return;
                                }
                            }
                            else if (enemies == 1)
                            {
                                enemies--;
                                airspace[currentRow, currentCol] = 'J';
                                Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                                PrintMatrix(airspace);
                                return;
                            }
                        }
                        else if (airspace[currentRow, currentCol] == 'R')
                        {
                            armor = 300;
                            airspace[currentRow, currentCol] = '-';
                        }
                        break;
                    case Directions.down:
                        currentRow++;
                        if (airspace[currentRow, currentCol] == 'E')
                        {
                            if (enemies > 1)
                            {
                                enemies--;
                                airspace[currentRow, currentCol] = '-';
                                armor -= 100;
                                if (armor == 0)
                                {
                                    Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currentRow}, {currentCol}]!");
                                    airspace[currentRow, currentCol] = 'J';
                                    PrintMatrix(airspace);
                                    return;
                                }
                            }
                            else if (enemies == 1)
                            {
                                enemies--;
                                airspace[currentRow, currentCol] = 'J';
                                Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                                PrintMatrix(airspace);
                                return;
                            }
                        }
                        else if (airspace[currentRow, currentCol] == 'R')
                        {
                            armor = 300;
                            airspace[currentRow, currentCol] = '-';
                        }
                        break;
                    case Directions.left:
                        currentCol--;
                        if (airspace[currentRow, currentCol] == 'E')
                        {
                            if (enemies > 1)
                            {
                                enemies--;
                                airspace[currentRow, currentCol] = '-';
                                armor -= 100;
                                if (armor == 0)
                                {
                                    Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currentRow}, {currentCol}]!");
                                    airspace[currentRow, currentCol] = 'J';
                                    PrintMatrix(airspace);
                                    return;
                                }
                            }
                            else if (enemies == 1)
                            {
                                enemies--;
                                airspace[currentRow, currentCol] = 'J';
                                Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                                PrintMatrix(airspace);
                                return;
                            }
                        }
                        else if (airspace[currentRow, currentCol] == 'R')
                        {
                            armor = 300;
                            airspace[currentRow, currentCol] = '-';
                        }
                        break;
                    case Directions.right:
                        currentCol++;
                        if (airspace[currentRow, currentCol] == 'E')
                        {
                            if (enemies > 1)
                            {
                                enemies--;
                                airspace[currentRow, currentCol] = '-';
                                armor -= 100;
                                if (armor == 0)
                                {
                                    Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currentRow}, {currentCol}]!");
                                    airspace[currentRow, currentCol] = 'J';
                                    PrintMatrix(airspace);
                                    return;
                                }
                            }
                            else if (enemies == 1)
                            {
                                enemies--;
                                airspace[currentRow, currentCol] = 'J';
                                Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                                PrintMatrix(airspace);
                                return;
                            }
                        }
                        else if (airspace[currentRow, currentCol] == 'R')
                        {
                            armor = 300;
                            airspace[currentRow, currentCol] = '-';
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