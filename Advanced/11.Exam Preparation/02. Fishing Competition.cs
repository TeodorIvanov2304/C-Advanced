using System.Numerics;

namespace _02._Fishing_Competition
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int tonnage = 20;
            int side = int.Parse(Console.ReadLine());

            char[,] matrix = new char[side, side];
            int currentRow = 0;
            int currentCol = 0;
            for (int row = 0; row < side; row++)
            {
                string rowValues = Console.ReadLine();
                for (int col = 0; col < side; col++)
                {
                    matrix[row, col] = rowValues[col];
                    if (matrix[row, col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }
            int caughtFish = 0;
            string command = "";
            while ((command = Console.ReadLine()) != "collect the nets")
            {
                matrix[currentRow, currentCol] = '-';
                //Парсваме direction enumerator-a към стринг
                Directions direction = (Directions)Enum.Parse(typeof(Directions), command);
                //Валидация за минаване от другата страна на полето!
                switch (direction)
                {
                    case Directions.down:
                        currentRow++;
                        if (currentRow >= side)
                        {
                            currentRow = 0;
                        }
                        break;
                    case Directions.up:
                        currentRow--;
                        if (currentRow < 0)
                        {
                            currentRow = side - 1;
                        }
                        break;
                    case Directions.left:
                        currentCol--;
                        if (currentCol < 0)
                        {
                            currentCol = side - 1;
                        }
                        break;
                    case Directions.right:
                        currentCol++;
                        if (currentCol >= side)
                        {
                            currentCol = 0;
                        }
                        break;
                    default: break;
                }
                if (matrix[currentRow, currentCol] != '-')
                {
                    if (matrix[currentRow, currentCol] == 'W')
                    {
                        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{currentRow},{currentCol}]");
                        return; // Излизаме от програмата
                    }
                    else
                    {
                        //Даваме му ToString(), иначе не работи
                        caughtFish += int.Parse(matrix[currentRow, currentCol].ToString());
                    }
                }
                matrix[currentRow, currentCol] = 'S';
            }

            if (caughtFish < tonnage)
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {tonnage - caughtFish} tons of fish more.");
            }
            else if(caughtFish >= tonnage)
            {
                Console.WriteLine($"Success! You managed to reach the quota!");
            }
            if (caughtFish>0)
            {
                Console.WriteLine($"Amount of fish caught: {caughtFish} tons.");
            }
            

            //Тук можем да дефинираме различен начин на изпечатване, например да добавим " " след symbol
            PrintMatrix(matrix, symbol =>
            {
                Console.Write(symbol);
            });

        }

        //Изпечатваме матрица
        static void PrintMatrix<T>(T[,] matrix, Action<T> print)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    print(matrix[row, col]);
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