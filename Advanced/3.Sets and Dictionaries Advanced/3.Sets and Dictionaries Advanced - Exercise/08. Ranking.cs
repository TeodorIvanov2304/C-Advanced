namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> candidates = new SortedDictionary<string, Dictionary<string, int>>();

            string command = "";
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] credentials = command.Split(":");
                contests.Add(credentials[0], credentials[1]);

            }

            string input = "";
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = input.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string candidate = tokens[2];
                int points = int.Parse(tokens[3]);

                //Ако contests от ключ се съдъжа в input, и ако value от contests[constest] отговаря на речника
                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    UpsertCandidate(candidates, contest, candidate, points);
                }
            }

            //Променлива за името на най-добрия кандидат, редим низходящо, после с x.Value.Values.Sum() сумираме и връщаме този на първо място с .First().Key;, като кей е за името
            string bestCandidate = candidates.OrderByDescending(x => x.Value.Values.Sum())
                                              .First().Key;
            //Създаваме променлива за сумираните точки = candidates[bestCandidate] ключ, достъпваме стойностите с Values и ги сумираме
            int totalPoints = candidates[bestCandidate].Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidate} with total {totalPoints} points.");
            Console.WriteLine("Ranking:");

            //За всеки кандидат в кандидатите
            foreach (var candidate in candidates)
            {
                var orderedByPointsDescending = candidate.Value.OrderByDescending(x => x.Value);
                Console.WriteLine(candidate.Key);

                foreach (var contest in orderedByPointsDescending)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        static void UpsertCandidate(SortedDictionary<string, Dictionary<string, int>> candidates, string contest, string name, int points)
        {
            if (!candidates.ContainsKey(name))
            {

                candidates[name] = new Dictionary<string, int>();
            }
            if (!candidates[name].ContainsKey(contest))
            {
                candidates[name][contest] = 0;
            }
            if (candidates[name][contest] < points)
            {
                candidates[name][contest] = points;
            }
        }
    }
}