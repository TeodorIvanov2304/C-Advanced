namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionModifier = 1.6;
        //The fuel reservoir has a hole, and can take only 95% of the fuel
        private const double truckerFacktor = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + fuelConsumptionModifier)
        {

        }

        public override void Refuel(double fuelAmount)
        {   
            //We pass the different, 95% of 100% fuel amount
            base.Refuel(truckerFacktor * fuelAmount);
        }
    }
}
