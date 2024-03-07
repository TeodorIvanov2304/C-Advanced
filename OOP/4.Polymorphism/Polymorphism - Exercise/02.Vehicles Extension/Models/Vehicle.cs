using Vehicles.Models.Interfaces;

namespace Vehicles
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be positive number");
                }
                
                if (value <= TankCapacity)
                {
                    fuelQuantity = value;
                }
                //If fuel quantity > tankCapacity
                else
                {
                    fuelQuantity = 0;
                }
            }
        }
        public virtual double FuelConsumption 
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

        public double TankCapacity
        {
            get => tankCapacity;
            protected set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be positive number");
                }
                tankCapacity = value;
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

            double totalFuelAfterRefueling = fuelAmount + FuelQuantity;
            if (totalFuelAfterRefueling > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }

            FuelQuantity += fuelAmount;
        }
    }
}
