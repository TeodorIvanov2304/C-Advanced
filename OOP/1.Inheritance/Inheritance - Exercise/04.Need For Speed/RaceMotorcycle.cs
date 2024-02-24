namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        //За да override-нем пропъртито FuelConsumption, задаваме нова константа, само за този клас DefaultFuelConsumption = 8
        private const double DefaultFuelConsumption = 8.0;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }


        
        public override double FuelConsumption => DefaultFuelConsumption;
        
    }
}
