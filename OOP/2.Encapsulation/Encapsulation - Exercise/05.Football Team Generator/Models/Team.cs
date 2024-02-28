namespace FootballTeamGenerator.Models
{
    public class Team
    {   
        //Argument exeption string constants
        private const string propertyNameArgumentExeption = "A name should not be empty.";
        private const string methodRemoveArgumentExeption = "Player {0} is not in {1} team.";

        //Fields for players and team name
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {   
                //Check for empty Team name
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(propertyNameArgumentExeption);
                }

                name = value;
            }
        }

        //Average team rating
        public double Rating
        {
            get
            {   
                //Team rating is calculated with average from all players
                if (players.Any())
                {
                    return players.Average(s => s.Stats);
                }

                return 0;
            }

        }

        //Method for adding players, new syntax!
        public void AddPlayer(Player player) => players.Add(player);
        
        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);
            if (player == null)
            {
                throw new ArgumentException(string.Format(methodRemoveArgumentExeption,playerName,Name));
            }

            players.Remove(player);
        }
    }
}
