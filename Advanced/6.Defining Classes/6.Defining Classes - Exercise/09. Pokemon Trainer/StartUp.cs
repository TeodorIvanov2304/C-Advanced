using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "Tournament")
            {
                AddTrainersAndPokemons(trainers, commands);

            }

            string element = string.Empty;
            while ((element = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    var checker = trainer.Pokemons.FirstOrDefault(x => x.Element == element);

                    if (checker != null)
                    {
                        trainer.NumberOfBadges += 1;
                    }
                    else
                    {
                        Pokemon.RemoveHealth(trainer);
                        Pokemon.RemovePokemon(trainer);
                    }
                }
            }

            var ordered = trainers.OrderByDescending(x => x.NumberOfBadges);

            foreach (var trainer in ordered)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }

        public static void AddTrainersAndPokemons(List<Trainer> trainers, string commands)
        {
            string[] commandInfo = commands.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string trainerName = commandInfo[0];
            int numberOfBadges = 0;
            string pokemonName = commandInfo[1];
            string pokemonElement = commandInfo[2];
            int pokemonHealth = int.Parse(commandInfo[3]);
            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            Trainer trainer = new(trainerName, numberOfBadges, new List<Pokemon>());
            var checkTrainer = trainers.FirstOrDefault(trainer => trainer.Name == trainerName);
            if (checkTrainer == null)
            {
                trainers.Add(trainer);
                trainer.Pokemons.Add(pokemon);
            }
            else
            {
                checkTrainer.Pokemons.Add(pokemon);
            }
        }



    }
}