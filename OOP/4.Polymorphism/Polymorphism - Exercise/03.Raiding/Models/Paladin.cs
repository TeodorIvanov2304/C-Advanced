namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int paladinBasePower = 100;
        public Paladin(string name) : base(name, paladinBasePower)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
