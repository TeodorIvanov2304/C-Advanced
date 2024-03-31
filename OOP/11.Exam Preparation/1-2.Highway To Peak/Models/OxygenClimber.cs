using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class OxygenClimber : Climber
    {
        private const int startingStaminaOxygenClimber = 10;
        private const int staminaRecoveryForDay = 1;
        public OxygenClimber(string name) : base(name, startingStaminaOxygenClimber)
        {
        }

        public override void Rest(int daysCount)
        {
            Stamina += daysCount * staminaRecoveryForDay;
        }
    }
}
