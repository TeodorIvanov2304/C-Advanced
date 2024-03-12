namespace _05._Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int exceptionCount = 0;

            while (exceptionCount < 3)
            {
                try
                {
                    string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    switch (command[0])
                    {
                        case "Replace":
                            int index = int.Parse(command[1]);
                            CheckForIndexOutOfRange(integers, index);

                            int element;
                            bool isInteger = int.TryParse(command[2], out element);

                            CheckIfIsInteger(integers, index, element, isInteger);
                            break;
                        case "Print":
                            int startIndex = int.Parse(command[1]);
                            int endIndex = int.Parse(command[2]);

                            CheckForIndexOutOfRange(integers, startIndex);
                            CheckForIndexOutOfRange(integers, endIndex);
                            PrintArray(integers, startIndex, endIndex);
                            break;
                        case "Show":
                            index = int.Parse(command[1]);
                            isInteger = int.TryParse(command[1], out element);
                            if (isInteger)
                            {
                                Console.WriteLine(integers[index]);
                            }
                            else
                            {
                                throw new FormatException();
                            }
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {

                    Console.WriteLine("The index does not exist!");
                    exceptionCount++;
                }
                catch(FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionCount++;
                }
            }

            Console.WriteLine(string.Join(", ", integers));
        }

        private static void PrintArray(int[] integers, int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {

                Console.Write($"{integers[i]}");
                if (i < endIndex)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }

        private static void CheckIfIsInteger(int[] integers, int index, int element, bool isInteger)
        {
            if (isInteger)
            {
                integers[index] = element;
            }
            else
            {
                throw new FormatException();
            }
        }

        private static void CheckForIndexOutOfRange(int[] integers, int index)
        {
            if (index < 0 || index > integers.Length - 1)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}