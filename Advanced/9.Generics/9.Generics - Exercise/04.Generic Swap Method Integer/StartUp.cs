namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<int> boxes = new List<int>();
            for (int i = 0; i < lines; i++)
            {
                boxes.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Swap(boxes, indexes[0], indexes[1]);
            foreach (var box in boxes)
            {
                //box.GetType() действа като typeof, връща ни типа
                Console.WriteLine($"{box.GetType()}: {box}");
            }

        }

        public static void Swap<T>(List<T> list, int index1, int index2)
        {
            if (index1 < 0 || index2 < 0 || index1 > list.Count - 1 || index1 > list.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
            //Tupple, deconstruciton syntax
            //(items[index1],items[index2]) = (items[index2],items[index1])

        }
    }
}