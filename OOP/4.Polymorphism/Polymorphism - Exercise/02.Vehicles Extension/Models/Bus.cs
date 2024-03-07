using Vehicles;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {   
        private const double consumptionModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public void DriveWithPeople(double distance)
        {
            var totalConsumptionPerTravel = distance * (FuelConsumption + consumptionModifier);

            if (FuelQuantity >= totalConsumptionPerTravel)
            {
                FuelQuantity -= totalConsumptionPerTravel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                throw new ArgumentException("Bus needs refueling");
            }
        }
    }
}
