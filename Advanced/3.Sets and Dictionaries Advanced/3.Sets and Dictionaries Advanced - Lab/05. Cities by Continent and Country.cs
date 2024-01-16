namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int destinations = int.Parse(Console.ReadLine());
            Dictionary<string,Dictionary<string,List<string>>> places = new Dictionary<string,Dictionary<string,List<string>>>();

            for (int i = 0; i < destinations; i++)
            {
                string[] ContinentsCountriesTowns = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = ContinentsCountriesTowns[0];
                string country = ContinentsCountriesTowns[1];
                string city = ContinentsCountriesTowns[2];

                if (!places.ContainsKey(continent))
                {
                    places.Add(continent, new Dictionary<string,List<string>>());
                }
                if (!places[continent].ContainsKey(country))
                {
                    places[continent].Add(country,new List<string>());
                }
                places[continent][country].Add(city);
            }

            
            foreach ((string continent, Dictionary<string, List<string>> country) in places)
            {
                Console.WriteLine($"{continent}:");

                foreach ((string state,List<string> city) in country)
                {   
                    //Със string.Join изпечатваме всички градове!
                    Console.WriteLine($"{state} -> {string.Join(", ",city)}");
                }
            }
        }
    }
}