namespace _01._Climb_The_Peaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> portions = new Stack<int>(Console
               .ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray());
            Queue<int> stamina = new Queue<int>(Console
                .ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> peeks = new Dictionary<string, int>
                                                {
                                                    {"Vihren", 80 },
                                                    {"Kutelo", 90 },
                                                    {"Banski Suhodol", 100 },
                                                    {"Polezhan",60},
                                                    {"Kamenitza",70 }
                                                };
            List<string> conqueredPeeks = new List<string>(5);

            for (int i = 0; i < 7; i++)
            {
                int result = portions.Peek() + stamina.Peek();
                string peek = peeks.Keys.First();
                int difficulty = peeks[peek];
                if (result >= difficulty)
                {
                    peeks.Remove(peek);
                    conqueredPeeks.Add(peek);
                    portions.Pop();
                    stamina.Dequeue();
                    if (conqueredPeeks.Count == 5)
                    {
                        Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
                        Console.WriteLine("Conquered peaks:");
                        foreach (var name in conqueredPeeks)
                        {
                            Console.WriteLine(name);
                        }
                        return;
                    }
                }
                else
                {
                    portions.Pop();
                    stamina.Dequeue();
                }
                if (portions.Count == 0 || stamina.Count == 0)
                {
                    break;
                }
            }

            Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            if (conqueredPeeks.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");
                foreach (var name in conqueredPeeks)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}