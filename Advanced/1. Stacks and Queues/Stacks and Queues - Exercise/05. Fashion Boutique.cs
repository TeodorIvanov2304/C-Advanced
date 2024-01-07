namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] boxWithClothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int capacity = int.Parse(Console.ReadLine());
            int currentRack = 0;
            int racks = 1;
            Stack<int> stack = new Stack<int>(boxWithClothes);

            while (stack.Count>0)
            {
                int currentCloth = stack.Peek();

                if (currentRack + currentCloth <= capacity) 
                {
                    stack.Pop();
                    currentRack += currentCloth;
                }
                else
                {
                    racks++;
                    currentRack = 0;
                    stack.Pop();
                    currentRack += currentCloth;
                    
                }
            }

            Console.WriteLine(racks);
        }
    }
}