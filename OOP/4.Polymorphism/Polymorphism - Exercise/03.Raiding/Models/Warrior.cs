namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int warriorBasePower = 100;
        public Warrior(string name) : base(name, warriorBasePower)
        {
        }
        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage"; ;
        }
    }
}
