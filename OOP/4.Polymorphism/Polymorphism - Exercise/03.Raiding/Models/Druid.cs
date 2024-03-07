namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int druidBasePower = 80;
        public Druid(string name) : base(name, druidBasePower)
        {
        }
        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
