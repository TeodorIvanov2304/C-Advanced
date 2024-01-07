namespace _05._Fashion_Boutique_Optimized
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] boxWithClothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(boxWithClothes);

            int capacity = int.Parse(Console.ReadLine());
            int currentRack = 0;
            int racks = 1;

            while (stack.Count > 0)
            {   
                //След като и в двата случая ще се поп-ва, няма нужда да пишем Peek()
                int currentCloth = stack.Pop();

                if (currentRack + currentCloth <= capacity)
                {
                    currentRack += currentCloth;
                }
                else
                {
                    //Вместо да зануляваме текущия шкаф, направо го приравняваме към стойността на сегашните дрехи currentRack = currentCloth;
                    racks++;
                    currentRack = currentCloth;
                }
            }

            Console.WriteLine(racks);
        }
    }
}