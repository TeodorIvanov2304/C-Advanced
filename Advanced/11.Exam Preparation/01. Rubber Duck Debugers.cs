namespace _01._Rubber_Duck_Debugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> time = new Queue<int>(Console
                .ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> tasks = new Stack<int>(Console
                .ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int darthVaderDuckyCount = 0;
            int thorDuckyCount = 0;
            int bigBlueDucky = 0;
            int smallYellowDucky = 0;

            while (time.Count>0 && tasks.Count > 0)
            {
                int result = time.Peek() * tasks.Peek();

                if (result > 0 && result <= 60)
                {
                    darthVaderDuckyCount++;
                    time.Dequeue();
                    tasks.Pop();
                }
                else if (result > 60 && result <= 120)
                {
                    thorDuckyCount++;
                    time.Dequeue();
                    tasks.Pop();
                }
                else if (result > 120 && result <=180)
                {
                    bigBlueDucky++;
                    time.Dequeue();
                    tasks.Pop();
                }
                else if (result> 180 && result <=240)
                {
                    smallYellowDucky++;
                    time.Dequeue();
                    tasks.Pop();
                }
                else if (result > 240)
                {
                    int tempTask = tasks.Pop() - 2;
                    tasks.Push(tempTask);
                    int tempTime = time.Dequeue();
                    time.Enqueue(tempTime);
                }
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {darthVaderDuckyCount}");
            Console.WriteLine($"Thor Ducky: {thorDuckyCount}");
            Console.WriteLine($"Big Blue Rubber Ducky: {bigBlueDucky}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {smallYellowDucky}");
        }
    }
}