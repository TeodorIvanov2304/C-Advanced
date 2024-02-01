namespace DefiningClasses
{
    public class Pokemon
    {
        public Pokemon(string name, string element, int health)
        {
            Name = name;
            Element = element;
            Health = health;
        }

        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }

        public static void RemoveHealth(Trainer trainer)
        {
            foreach (var pokemon in trainer.Pokemons)
            {
                pokemon.Health -= 10;
            }
        }

        public static void RemovePokemon(Trainer trainer)
        {
            if (trainer.Pokemons.Any(x => x.Health <= 0))
            {
                trainer.Pokemons.RemoveAll(p => p.Health <= 0);
            }
        }
    }

    
}
