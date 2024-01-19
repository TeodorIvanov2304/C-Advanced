
namespace _07._The_V_Logger
{
    class Vlogger
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vlogerDatabase = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] data = input.Split();

                string vlogger = data[0];
                string command = data[1];

                if (command == "joined")
                {
                    if (vlogerDatabase.ContainsKey(vlogger) == false)
                    {
                        vlogerDatabase.Add(vlogger, new Dictionary<string, HashSet<string>>());
                        vlogerDatabase[vlogger].Add("followers", new HashSet<string>());
                        vlogerDatabase[vlogger].Add("following", new HashSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string member = data[2];

                    if (vlogger != member && vlogerDatabase.ContainsKey(vlogger) && vlogerDatabase.ContainsKey(member))
                    {
                        vlogerDatabase[vlogger]["following"].Add(member);
                        vlogerDatabase[member]["followers"].Add(vlogger);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vlogerDatabase.Count} vloggers in its logs.");

            int number = 1;

            foreach (var vlogger in vlogerDatabase.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (number == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                number++;
            }
        }
    }
}