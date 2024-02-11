using System.Text;

namespace _01._Worms_And_Holes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> worms = new Stack<int>(Console.ReadLine()
                                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                     .Select(int.Parse)
                                                      .ToArray());

            Queue<int> holes = new Queue<int>(Console.ReadLine()
                                              .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse)
                                              .ToArray());

            int matchesCount = 0;
            int deadWorms = 0;
            while (worms.Count > 0 && holes.Count >0) 
            {
                if (worms.Peek() == holes.Peek()) 
                {   
                    matchesCount++;
                    worms.Pop();
                    holes.Dequeue();
                }
                else
                {
                    
                    holes.Dequeue();
                    int temp = worms.Pop();
                    temp -= 3;
                    worms.Push(temp);
                    if (temp <=0)
                    {
                        worms.Pop();
                        deadWorms++;
                    }
                }
               
            }

            if(matchesCount>0)
            {
                Console.WriteLine($"Matches: {matchesCount}");
            }
            else
            {
                Console.WriteLine("There are no matches.");
            }

            if (worms.Count == 0 && deadWorms == 0)
            {
                Console.WriteLine("Every worm found a suitable hole!");
            }
            else if (worms.Count == 0 && deadWorms > 0)
            {
                Console.WriteLine("Worms left: none");
            }
            else if (worms.Count > 0)
            {
                Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
            }
            if (holes.Count == 0)
            {
                Console.WriteLine("Holes left: none");
            }
            else if (holes.Count > 0)
            {
                Console.WriteLine($"Holes left: {string.Join(", ", holes)}");
            }
            
        }

        
    }
}