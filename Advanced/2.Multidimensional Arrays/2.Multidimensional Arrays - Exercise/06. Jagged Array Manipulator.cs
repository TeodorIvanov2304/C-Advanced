namespace _06._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedMatrix = new double[rows][];

            //Четем назъбения масив
            for (int row = 0; row < rows; row++)
            {
                double[] rowValues = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedMatrix[row] = rowValues;
            }

            //Въртим цикъл до предпследния ред, за да не излезнем от матрицата
            for (int row = 0; row < rows - 1; row++)
            {
                //Проверяваме, дали редовете един под друг са еднакви
                if (jaggedMatrix[row].Length == jaggedMatrix[row + 1].Length)
                {
                    //Ако да, умножаваме
                    for (int col = 0; col < jaggedMatrix[row].Length; col++)
                    {
                        jaggedMatrix[row][col] *= 2;
                    }
                    for (int col = 0; col < jaggedMatrix[row + 1].Length; col++)
                    {
                        jaggedMatrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    //Ако не, делим всяка стойност
                    for (int col = 0; col < jaggedMatrix[row].Length; col++)
                    {
                        jaggedMatrix[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedMatrix[row + 1].Length; col++)
                    {
                        jaggedMatrix[row + 1][col] /= 2;
                    }
                }
            }

            string commands = "";

            while ((commands = Console.ReadLine()) != "End")
            {
                string[] commandArgs = commands.Split();
                string command = commandArgs[0];
                int rowToChange = int.Parse(commandArgs[1]);
                int colToChange = int.Parse(commandArgs[2]);
                double value = double.Parse(commandArgs[3]);

                switch(command)
                {
                    case "Add":
                        if (rowToChange >=0 && rowToChange <= jaggedMatrix.Length &&colToChange>=0 && colToChange <= jaggedMatrix[rowToChange].Length)
                        {
                            jaggedMatrix[rowToChange][colToChange] += value;
                        }
                        
                        break;
                    case "Subtract":
                        if (rowToChange >= 0 && rowToChange <= jaggedMatrix.Length && colToChange >= 0 && colToChange <= jaggedMatrix[rowToChange].Length)
                        {
                            jaggedMatrix[rowToChange][colToChange] -= value;
                        }
                        
                        break;
                }
            }

            PrintJaggedArray(jaggedMatrix);
        }

        public static void PrintJaggedArray(double[][] jaggedMatrix)
        {
            for (int row = 0; row < jaggedMatrix.Length; row++)
            {
                for (int col = 0; col < jaggedMatrix[row].Length; col++)
                {
                    Console.Write($"{jaggedMatrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}