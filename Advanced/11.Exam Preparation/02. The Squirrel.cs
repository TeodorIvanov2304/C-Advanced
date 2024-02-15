namespace _02._The_Squirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte sizes = byte.Parse(Console.ReadLine());
            string[] commandArray = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[sizes, sizes];
            int currentRow = 0;
            int currentCol = 0;
            for (int row = 0; row < sizes; row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < sizes; col++)
                {
                    matrix[row, col] = rowInput[col];
                    if (matrix[row, col] == 's')
                    {
                        currentRow = row;
                        currentCol = col;

                    }
                }
            }

            int hazelNuts = 0;

            foreach (var command in commandArray)
            {
                Directions direction = (Directions)Enum.Parse(typeof(Directions), command);
                matrix[currentRow, currentCol] = '*';
                switch (direction)
                {
                    case Directions.left:
                        if (currentCol - 1 >= 0)
                        {
                            currentCol--;
                            if (matrix[currentRow,currentCol] == 'h')
                            {
                                hazelNuts++;
                                if (hazelNuts == 3)
                                {
                                    Console.WriteLine("Good job! You have collected all hazelnuts!");
                                    Console.WriteLine($"Hazelnuts collected: {hazelNuts}");
                                    Environment.Exit(0);
                                }
                            }
                            else if (matrix[currentRow, currentCol] == 't')
                            {
                                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                                Console.WriteLine($"Hazelnuts collected: {hazelNuts}");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("The squirrel is out of the field.");
                            Console.WriteLine($"Hazelnuts collected: {hazelNuts}");
                            Environment.Exit(0);
                        }
                        
                        break;
                    case Directions.right:
                        if (currentCol + 1 < sizes)
                        {
                            currentCol++;
                            if (matrix[currentRow, currentCol] == 'h')
                            {
                                hazelNuts++;
                                if (hazelNuts == 3)
                                {
                                    Console.WriteLine("Good job! You have collected all hazelnuts!");
                                    Console.WriteLine($"Hazelnuts collected: {hazelNuts}");
                                    Environment.Exit(0);
                                }
                            }
                            else if (matrix[currentRow, currentCol] == 't')
                            {
                                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                                Console.WriteLine($"Hazelnuts collected: {hazelNuts}");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("The squirrel is out of the field.");
                            Console.WriteLine($"Hazelnuts collected: {hazelNuts}");
                            Environment.Exit(0);
                        }
                        break;
                    case Directions.up:
                        if (currentRow - 1 >= 0)
                        {
                            currentRow--;
                            if (matrix[currentRow, currentCol] == 'h')
                            {
                                hazelNuts++;
                                if (hazelNuts == 3)
                                {
                                    Console.WriteLine("Good job! You have collected all hazelnuts!");
                                    Console.WriteLine($"Hazelnuts collected: {hazelNuts}");
                                    Environment.Exit(0);
                                }
                            }
                            else if (matrix[currentRow, currentCol] == 't')
                            {
                                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                                Console.WriteLine($"Hazelnuts collected: {hazelNuts}");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("The squirrel is out of the field.");
                            Console.WriteLine($"Hazelnuts collected: {hazelNuts}");
                            Environment.Exit(0);
                        }
                        break;
                    case Directions.down:
                        if (currentRow + 1 < sizes)
                        {
                            currentRow++;
                            if (matrix[currentRow, currentCol] == 'h')
                            {
                                hazelNuts++;
                                if (hazelNuts == 3)
                                {
                                    Console.WriteLine("Good job! You have collected all hazelnuts!");
                                    Console.WriteLine($"Hazelnuts collected: {hazelNuts}");
                                    Environment.Exit(0);
                                }
                            }
                            else if (matrix[currentRow, currentCol] == 't')
                            {
                                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                                Console.WriteLine($"Hazelnuts collected: {hazelNuts}");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("The squirrel is out of the field.");
                            Console.WriteLine($"Hazelnuts collected: {hazelNuts}");
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("There are more hazelnuts to collect.");
            Console.WriteLine($"Hazelnuts collected: {hazelNuts}");
        }

        public enum Directions
        {
            left,
            right,
            up,
            down
        }
    }
}