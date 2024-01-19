namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            //Създаваме сортирана хаш-таблица
            SortedSet<string> periodicTable = new SortedSet<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] elements = Console.ReadLine().Split();
                foreach (string element in elements) 
                {
                    periodicTable.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", periodicTable));
        }
    }
}