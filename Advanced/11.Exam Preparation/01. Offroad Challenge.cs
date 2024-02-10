namespace _01._Offroad_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stack<int> initialFuels = new Stack<int>(Console.ReadLine()
                                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray()); //Можем да кажем на стека и опашката ToArray!
            int top = initialFuels.Count;

            //Съкратено
            Queue<int> initialConsumptions = new Queue<int>(Console.ReadLine()
                                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray());

            Queue<int> neededFuels = new(Console.ReadLine()
                                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray());

            

            int result = Math.Abs(initialConsumptions.Peek() - initialFuels.Peek());
            int altitudeCount = 0;
            while (initialFuels.Count >0)
            {
                int initialFuel = initialFuels.Pop();
                int initialConsumpiton = initialConsumptions.Dequeue();
                int neededFuel = neededFuels.Dequeue();

                int actionFuel = Math.Abs(initialFuel - initialConsumpiton);

                if (actionFuel>=neededFuel)
                {
                    altitudeCount++;
                    Console.WriteLine($"John has reached: Altitude {altitudeCount}");
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {altitudeCount + 1}");
                    break;
                }
            }

            

            if (altitudeCount == 0)
            {
                Console.WriteLine($"John failed to reach the top.");
                Console.WriteLine($"John didn't reach any altitude.");
            }
            else if (altitudeCount>0 && altitudeCount<top)
            {
                Console.WriteLine($"John failed to reach the top.");
                Console.Write("Reached altitudes: ");
                for (int i = 0; i < altitudeCount; i++)
                {
                    
                    Console.Write($"Altitude {i+1}");
                    //Добавяме запетайката, само ако не сме достигнали последната височина
                    if (i < altitudeCount-1)
                    {
                        Console.Write(", ");
                    }
                }
                
            }
            else if(altitudeCount==top)
            {
                Console.WriteLine($"John has reached all the altitudes and managed to reach the top!");
            }
        }
    }
}