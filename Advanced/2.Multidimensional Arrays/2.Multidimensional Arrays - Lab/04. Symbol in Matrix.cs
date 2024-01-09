namespace _04._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Четем редовете и колоните на квадратна матица, напр. 2,2
            int rowsAndCols = int.Parse(Console.ReadLine());
            //Създаваме матрица по размерите
            string[,] matrix = new string[rowsAndCols, rowsAndCols];

            //Пълним я
            for (int row = 0; row < rowsAndCols; row++)
            {   
                string rowValues = Console.ReadLine();
                for (int col = 0; col < rowsAndCols; col++)
                {   
                    //Даваме му ToString(), защото иначе дава грешка
                    matrix[row, col] = rowValues[col].ToString();
                }
            }
            //Четем символа, който търсим
            string symbol = Console.ReadLine();
            //Правим флаг променлива
            bool flag = false;

            //Минаваме през матрицата, за да намерим символа
            for (int row = 0; row < rowsAndCols; row++)
            {
                for (int col = 0; col < rowsAndCols; col++)
                {   
                    //Ако го намерим , го изпечатваме
                    if (matrix[row,col] == symbol)
                    {   
                        Console.WriteLine($"({row}, {col})");
                        flag = true;
                        Environment.Exit(0);
                    }
                }
            }

            //Ако не
            if (!flag)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}