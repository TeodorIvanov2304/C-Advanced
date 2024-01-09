namespace _03._Primary_Diagonal_Dakov_Variation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rowsAndCols, rowsAndCols];

            int sum = 0;

            //Изпечатване на диагонал надясно
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(matrix[i,i] + " ");
            }

            Console.WriteLine();

            //Изпечатване на диагонал наляво
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(matrix[i,matrix.GetLength(1)-i-1] + " ");
            }
            
        }
    }
}