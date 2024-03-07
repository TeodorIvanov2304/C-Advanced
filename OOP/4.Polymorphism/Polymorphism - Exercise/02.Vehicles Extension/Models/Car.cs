namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        //Car have more fuel consumption, because is summer. We add 0.9 modifier to the constructor
        private const double fuelConsumptionModifier = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + fuelConsumptionModifier, tankCapacity)
        {
        }

        

    }
}
