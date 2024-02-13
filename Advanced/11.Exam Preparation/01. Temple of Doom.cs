﻿namespace _01._Temple_of_Doom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> substances = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            List<int>challenges = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (tools.Count > 0 && substances.Count > 0 && challenges.Count >0)
            {
                int result = tools.Peek() * substances.Peek();
                bool isMatch = false;
                for (int i = 0; i < challenges.Count; i++)
                {
                    if (challenges[i] == result)
                    {
                        tools.Dequeue();
                        substances.Pop();
                        challenges.RemoveAt(i);
                        isMatch = true;
                        break;
                    }
                    
                }

                if(!isMatch)
                {
                    int currentTool = tools.Dequeue() + 1;
                    tools.Enqueue(currentTool);

                    int currentSubstance = substances.Pop() - 1;
                    if (currentSubstance != 0)
                    {
                        substances.Push(currentSubstance);
                    }
                    
                    isMatch = false;
                }
            }
            if (challenges.Count>0)
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }

            if (tools.Count >0)
            {
                Console.WriteLine($"Tools: {string.Join(", ",tools)}");
            }
            if (substances.Count>0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }
            if (challenges.Count>0)
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }
}