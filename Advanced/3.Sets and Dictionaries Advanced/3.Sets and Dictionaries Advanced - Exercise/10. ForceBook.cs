namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> sidesUsers = new Dictionary<string, SortedSet<string>>();

            string commands = "";

            while ((commands = Console.ReadLine()) != "Lumpawaroo")
            {
                if (commands.Contains("|"))
                {
                    string[] tokens = commands.Split(" | ",StringSplitOptions.RemoveEmptyEntries);
                    string side = tokens[0];
                    string user = tokens[1];

                    //Ако sideUsers съдържа Values, всяко(Any) => Contains(user))
                    if (!sidesUsers.Values.Any(u => u.Contains(user)))
                    {
                        if (!sidesUsers.ContainsKey(side))
                        {
                            sidesUsers.Add(side, new SortedSet<string>());
                        }
                        sidesUsers[side].Add(user);
                    }
                }
                else
                {
                    string[] tokens = commands.Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
                    string side = tokens[1];
                    string user = tokens[0];

                    foreach (var sideUsers in sidesUsers)
                    {
                        if (sideUsers.Value.Contains(user))
                        {
                            sideUsers.Value.Remove(user);
                            break;
                        }
                    }

                    if (!sidesUsers.ContainsKey(side))
                    {
                        sidesUsers.Add(side, new SortedSet<string>());
                        
                    }
                    sidesUsers[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            //Нареждаме (в нова променлива) sideUsers, първо по брой на хората, после име
            var ordered = sidesUsers.OrderByDescending(x => x.Value.Count)
                                    .ThenBy(x=>x.Key);

            foreach (var user in ordered)
            {
                if (user.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {user.Key}, Members: {user.Value.Count}");

                    foreach (var sideUser in user.Value)
                    {
                        Console.WriteLine($"! {sideUser}");
                    }
                }
            }
        }
    }
}