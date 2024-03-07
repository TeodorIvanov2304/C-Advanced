using Vehicles.Models.Interfaces;

namespace Vehicles
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public  double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel must be positive number");
                }
                fuelQuantity = value;
            }
        }
        public  double FuelConsumption 
        {
            get => fuelConsumption;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Consumption must be positive number");
                }
                fuelConsumption = value;
            }
        }

        public virtual void Drive(double distance)
        {
            double totalConsumption = distance * FuelConsumption;
            if (totalConsumption > FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            FuelQuantity -= totalConsumption;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            FuelQuantity += fuelAmount;
        }
    }
}
