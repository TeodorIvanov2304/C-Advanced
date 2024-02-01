namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer(string name, int numberOfBadges, List<Pokemon> pokemons)
        {
            Name = name;
            NumberOfBadges = numberOfBadges;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
