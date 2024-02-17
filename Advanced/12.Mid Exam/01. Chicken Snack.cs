namespace _01._Chicken_Snack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> money = new Stack<int>(Console
                .ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> price = new Queue<int>(Console
                .ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int eatenFood = 0;

            while (money.Count > 0 && price.Count > 0)
            {
                if (money.Peek() == price.Peek())
                {
                    eatenFood++;
                    money.Pop();
                    price.Dequeue();
                }
                else if (money.Peek() > price.Peek())
                {
                    int result = money.Pop() - price.Dequeue();
                    eatenFood++;
                    if (money.Count > 0)
                    {
                        result += money.Pop();
                        money.Push(result);
                    }
                }
                else if (money.Peek() < price.Peek())
                {
                    money.Pop();
                    price.Dequeue();
                }
            }

            if (eatenFood >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {eatenFood} foods.");
            }
            if (eatenFood > 0 && eatenFood < 4)
            {
                if (eatenFood == 1)
                {
                    Console.WriteLine($"Henry ate: {eatenFood} food.");
                }
                else if (eatenFood > 0)
                {
                    Console.WriteLine($"Henry ate: {eatenFood} foods.");
                }
            }
            if (eatenFood == 0)
            {
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            }
        }
    }
}