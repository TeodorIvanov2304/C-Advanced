namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double fuelConsumptionModifier = 0.9;

        //Car have more fuel consumption, because is summer. We add 0.9 modifier to the constructor
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + fuelConsumptionModifier) 
        {

        }
    }
}
