using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using BorderControl.Models;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = tokens[0];
                switch (type)
                {
                    case "Citizen":
                        IBirthable citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                        birthables.Add(citizen);
                        break;
                    case "Pet":
                        IBirthable pet = new Pet(tokens[1], tokens[2]);
                        birthables.Add(pet);
                        break;
                    default : 
                            break;
                }
            }

            string date = Console.ReadLine();
            List<IBirthable> orderedByBirthday = birthables.Where(b => b.BirthDate.EndsWith(date)).ToList();

            foreach (var entity in orderedByBirthday)
            {
                Console.WriteLine(entity.BirthDate);
            }
        }
    }
}