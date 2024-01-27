namespace _09._PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guessList = Console.ReadLine().Split().ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Party!") break;

                string[] commands = input.Split();

                //Създаваме предикат, който вика метода GetPredicate, като му подаваме commands[1], commands[2]. Целта на GetPredicate е да определи по какъв критерий ще махаме или слагаме гости
                Func<string, bool> predicate = GetPredicate(commands[1], commands[2]);

                switch (commands[0])
                {
                    case "Remove":
                        //Викаме метода Remove, и му подаваме guestList и предиката
                        guessList = Remove(guessList, predicate);
                        break;
                    case "Double":
                        //Викаме метода Double
                        guessList = Double(guessList, predicate);
                        break;
                }

            }

            //Използваме guestList.Any() вместо guestList.Count == 0, и конструкцията ? : вместо if-else
            Console.WriteLine(guessList.Any()
                ? $"{string.Join(", ", guessList)} are going to the party!"
                : "Nobody is going to the party!"
            );
        }

        //Метод за определяне на предиката
        private static Func<string, bool> GetPredicate(string command, string substring)
        {
            //Ако = StartsWith, използваме string метода StartsWith
            if (command == "StartsWith")
            {
                return s => s.StartsWith(substring);
            }

            //Използваме Endswith
            if (command == "EndsWith")
            {
                return s => s.EndsWith(substring);
            }

            //Парсваме дължината
            if (command == "Length")
            {
                return s => s.Length == int.Parse(substring);
            }

            return default;
        }
        //Метода за удвояване на имената на гостите. Подаваме му листа и предиката, определен от горния метод
        static List<string> Double(List<string> guestList, Func<string, bool> predicate)
        {
            List<string> result = new List<string>();

            foreach (string guest in guestList)
            {
                if (predicate(guest))
                {
                    result.Add(guest);
                }

                result.Add(guest);
            }

            return result;
        }

        //Метод за премахване на гости от листа, подаваме му guestList и предиката определен от GetPredicate
        static List<string> Remove(List<string> guestList, Func<string, bool> predicate)
        {
            guestList = guestList.Where(guest => predicate(guest) == false).ToList();
            return guestList;
        }
    }
}