namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }



        //Правим пропъртито IReadOnlyCollection без сетър, за да е енкапсулирано и да не може да се променя. Също така в гетъра слагаме firstTeam и му даваме .AsReadOnly();
        public IReadOnlyCollection<Person> FirstTeam { get => firstTeam.AsReadOnly();}
        public IReadOnlyCollection<Person> ReserveTeam { get => reserveTeam.AsReadOnly();}

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                firstTeam.Add(player);

            }
            else
            {
                reserveTeam.Add(player);
            }
        }
    }
}
