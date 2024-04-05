namespace EDriveRent.Models
{
    using EDriveRent.Models.Contracts;
    using EDriveRent.Utilities.Messages;
    using System;
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private double maxMileage;
        private string licensePlateNumber;
        private int batteryLevel;
        private bool isDamaged;

        protected Vehicle(string brand, string model, double maxMilage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            this.maxMileage = maxMilage;
            LicensePlateNumber = licensePlateNumber;
            this.batteryLevel = 100;
            this.isDamaged = false;
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.BrandNull));
                }
                brand = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ModelNull));
                }
                model = value;
            }
        }

        public double MaxMileage => this.maxMileage;

        public string LicensePlateNumber
        {
            get => licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.LicenceNumberRequired));
                }
                licensePlateNumber = value;
            }
        }

        public int BatteryLevel => batteryLevel;

        public bool IsDamaged => isDamaged;

        public void ChangeStatus()
        {
            isDamaged = !isDamaged;
        }

        public void Drive(double mileage)
        {
            double percentage = Math.Round((mileage / this.maxMileage) * 100);
            this.batteryLevel -= (int)percentage;

            if (this.GetType().Name == nameof(CargoVan))
            {
                this.batteryLevel -= 5;
            }
        }

        public void Recharge()
        {
            this.batteryLevel = 100;
        }

        public override string ToString()
        {
            string vehicleCondition;

            if (isDamaged)
            {
                vehicleCondition = "damaged";
            }
            else
            {
                vehicleCondition = "OK";
            }

            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {vehicleCondition}";
        }
    }
}
