namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        public const double DefaultFuelConsumption  = 1.25;

        //Може да се направи и без константа, като DefaultFuelConsumption се зададе направо в конструктора. За другите класове също
        //public Vehicle(int hp, double fuel)
        //{
        //    HP = hp;
        //    Fuel = fuel;
        //    DefaultFuelConsumption = 1.25;
        //}
        protected Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        
        public virtual double FuelConsumption => DefaultFuelConsumption;

        public virtual void Drive(double kilometers)
        {
            Fuel-= FuelConsumption * kilometers;
        }
    }
}
