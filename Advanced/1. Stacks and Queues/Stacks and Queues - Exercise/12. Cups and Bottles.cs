namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] filledBottles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottles = new Stack<int>(filledBottles);
            Queue<int> cups = new Queue<int>(cupsCapacity);

            int wastedWatter = 0;

            while (cups.Count > 0 && bottles.Count>0) 
            {
                int currentBottle = bottles.Pop();
                int currentCup = cups.Dequeue();

                if (currentBottle>=currentCup)
                {
                    wastedWatter += currentBottle - currentCup;
                    continue;
                }

                else
                {
                    currentCup -= currentBottle;

                    while (currentCup>0)
                    {
                        currentCup -= bottles.Pop();

                        if (currentCup<0)
                        {
                            wastedWatter += currentCup * -1;
                        }
                    }
                }

            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            else if(bottles.Count>0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWatter}");
        }
    }
}