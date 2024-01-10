namespace _01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Четем размера на матрицата
            int size = int.Parse(Console.ReadLine());
            //Създаваме матрицата
            int[,] matrix = new int[size,size];
            //Създаваме променлива за главняи диагонал
            int primaryDiagonal = 0;

            //Пълним матрицата от входа, и междувременно смятаме общата сума на главния диагонал
            for (int row = 0; row < size; row++)
            {
                int[] rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowValues[col];

                    if (row == col)
                    {
                        primaryDiagonal += matrix[row, col];
                    }
                }
            }

            //Създаваме променлиа, която ще пази сумата на вторичня диагонал
            int secondaryDiagonal = 0;

            //Трасираме матрицата, и смятаме вторичния диагонал(отдясно наляво - надолу)
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {   
                    //Ако колоната е равна на големината на матрицата - 1 - реда
                    if (col == size - 1 - row)
                    {
                        secondaryDiagonal += matrix[row, col];
                    }
                }
            }

            //Смятаме разликата в асболютна стойност
            int differnce = Math.Abs(primaryDiagonal - secondaryDiagonal);
            Console.WriteLine(differnce);

        }
    }
}