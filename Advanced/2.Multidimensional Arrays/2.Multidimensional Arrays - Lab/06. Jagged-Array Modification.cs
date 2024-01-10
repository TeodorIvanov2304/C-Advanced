using System.Globalization;

namespace _06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //READING THE JAGGED ARRAY
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[row] = rowValues;
            }

            //Правим променлива, в която ще пазим командите
            string input = Console.ReadLine().ToLower();
            //Пускаме while-loop, докато не получим end
            while (input != "end")
            {
                //Разцепваме си командата и записваме в отделни променливи
                string[] commandArgs = input.Split();
                //string command = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                //Проверка, дали не излизаме от границите на масива!!! ТОВА ДА СЕ КОПИРА ЗА ВСЯКА ЗАДАЧА!
                if (row < 0 || col < 0 || row >= jagged.Length || jagged[row].Length <= col)
                {
                    Console.WriteLine($"Invalid coordinates");
                }
                else
                {
                    switch (commandArgs[0])
                    {
                        //Обърни внимание, на jagged[row][col]!!
                        //Събираме
                        case "add": 
                            jagged[row][col] += value;
                            break;
                        //Изваждаме
                        case "subtract":
                            jagged[row][col] -= value;
                            break;
                    }
                }

                input = Console.ReadLine().ToLower();
            }

            //PRINTING THE JAGGED ARRAY
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write($"{jagged[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}