namespace _01._Apocalypse_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new Queue<int>(Console
                .ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> medicaments = new Stack<int>(Console
                .ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Dictionary<string, int> inventory = new Dictionary<string, int>
                                                {
                                                    { "Patch", 0 },
                                                    { "Bandage", 0 },
                                                    { "MedKit", 0 }
                                                };

            while (textiles.Count > 0 && medicaments.Count > 0)
            {
                int result = textiles.Peek() + medicaments.Peek();

                if (result == 30)
                {
                    inventory["Patch"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                }
                else if (result == 40)
                {
                    inventory["Bandage"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                }
                else if (result == 100)
                {
                    inventory["MedKit"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                }
                else if (result > 100)
                {
                    inventory["MedKit"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                    result -= 100;
                    if (medicaments.Count > 0)
                    {
                        result += medicaments.Pop();
                    }
                    medicaments.Push(result);
                }
                else
                {
                    result -= textiles.Dequeue();
                    medicaments.Pop();

                    medicaments.Push(result + 10);
                }
            }

            if(textiles.Count == 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (medicaments.Count == 0)
            {
                Console.WriteLine("Medicaments are empty.");
            }
            else if (textiles.Count == 0)
            {
                Console.WriteLine("Textiles are empty.");
            }

            foreach (KeyValuePair<string, int> kvp in inventory.OrderByDescending(c => c.Value).ThenBy(n=>n.Key))
            {
                if (kvp.Value > 0)
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }

            if (medicaments.Count > 0)
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }
            if (textiles.Count > 0)
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }
    }
}