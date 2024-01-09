namespace _02._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Прочитаме матрицата и я запълваме по същия начин, като миналата задача
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = sizes[0];

            int cols = sizes[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            //За да съберем колоните, обръщаме циклите външния цикъл върви по колоните, а вътрешния по редовете
            for (int col = 0; col < cols; col++)
            {
                int sum = 0;

                for (int row = 0; row < rows; row++)
                {   
                    //Събираме стойностите на колоните
                    sum += matrix[row, col];
                }
                //Изпечатваме заедно с нов ред
                Console.WriteLine();
                Console.Write(sum);
            }
        }
    }
}