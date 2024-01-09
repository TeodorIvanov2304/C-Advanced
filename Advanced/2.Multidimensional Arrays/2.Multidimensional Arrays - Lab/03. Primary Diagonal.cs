namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rowsAndCols,rowsAndCols];

            int sum = 0;

            for (int row = 0; row < rowsAndCols; row++)
            {
                int[] rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < rowsAndCols; col++)
                {
                    matrix[row, col] = rowValues[col];

                    //Ако индексът на реда и колоната са равни, това значи че вървим по главния диагонал(Primary Diagonal)
                    //Само тогава, взимам числото и го добавяме към сумата
                    if (row == col)
                    {
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}