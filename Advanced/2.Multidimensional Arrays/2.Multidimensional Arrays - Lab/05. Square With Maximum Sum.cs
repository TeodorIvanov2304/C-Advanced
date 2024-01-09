namespace _05._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Четем матрицата и параметрите й от конзолата,и я запълваме
            int[] rowsAndCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowValues = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            //Създаваме промениви за максимална сума на два съседни числа и две числа едно под друго
            int maxSquareRow = 0;
            int maxSquareCol = 0;
            //Създаваме променлива за максимална сума на квадрата 2х2
            int maxSquareSum = int.MinValue;

            //Пускаме цикъл, който върти по редовете и колоните
            //Като напишем matrix.GetLength(0)-1, си гарантираме, че няма да излезнем от индексите, т.е няма
            //да се опитваме да правим квадрати надясно от крайният индекс!

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    //Създаваме променлива, която пази сумата на четири числа едно и под друго (2х2 матица)
                    //matrix[row, col] за дясното горно число
                    // matrix[row, col + 1] за съседното отдясно число
                    // matrix[row + 1, col] за числото, което е отдолу на първото
                    //matrix[row + 1, col + 1] за числото, което е надолу по диагонал от първото
                    int currentSquareSum = 
                        matrix[row, col] 
                        + matrix[row, col + 1]
                        + matrix[row + 1, col] 
                        + matrix[row + 1, col + 1];

                    //Проверяваме дали текущата сума на квадрата е по-голяма от maxSquareSum
                    //Ако е , записваме реда и колоната на която се намират, и презаписваме maxSquareSum
                    if (currentSquareSum > maxSquareSum)
                    {
                        maxSquareSum = currentSquareSum;
                        maxSquareRow = row;
                        maxSquareCol = col;
                    }
                }
            }

            //Изпечатавме максималните съседни квадрати
            Console.WriteLine($"{matrix[maxSquareRow,maxSquareCol]} {matrix[maxSquareRow,maxSquareCol + 1]}");
            Console.WriteLine($"{matrix[maxSquareRow+1,maxSquareCol]} {matrix[maxSquareRow + 1,maxSquareCol + 1]}");
            //Изпечатваме максимлания квадрат
            Console.WriteLine(maxSquareSum);
        }
    }
}