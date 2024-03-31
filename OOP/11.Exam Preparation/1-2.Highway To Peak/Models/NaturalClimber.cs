using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        private const int startingStaminaNaturalClimber = 6;
        private const int staminaRecoveryForDay = 2;
        public NaturalClimber(string name) : base(name, startingStaminaNaturalClimber)
        {
        }

        public override void Rest(int daysCount)
        {
            Stamina += daysCount * staminaRecoveryForDay;

        }
    }
}
