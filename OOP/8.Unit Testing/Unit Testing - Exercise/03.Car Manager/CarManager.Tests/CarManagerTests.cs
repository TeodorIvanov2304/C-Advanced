namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private const string Make = "Subaru";
        private const string Model = "LeVorg";
        private const double FuelConsumption = 6.02;
        private const double FuelAmount = 0.00;
        private const double FuelCapacity = 60.00;
        private Car subaru;
        private const string CtorMakeShouldNotBeEmpty = "Make cannot be null or empty!";
        private const string CtorModelShouldNotBeEmpty = "Model cannot be null or empty!";
        private const string CtorFuelConsumptionShouldBeMoreThanZero = "Fuel consumption cannot be zero or negative!";
        private const string CtorFuelCapacityShouldBeMoreThanZero = "Fuel capacity cannot be zero or negative!";
        private const string RefuelFuelAmountShouldBeMoreThanZero = "Fuel amount cannot be zero or negative!";
        private const string DriveFuelNeededIsMoreThanCapacityShouldThrowException = "You don't have enough fuel to drive!";

        [SetUp]

        public void SetUp()
        {
            subaru = new(Make, Model, FuelConsumption, FuelCapacity);
        }

        [Test]
        public void Ctor_WithValidParameters_CreateNewInstance()
        {
            Assert.IsNotNull(subaru);
            Assert.AreEqual(subaru.Make, Make);
            Assert.AreEqual(subaru.Model, Model);
            Assert.AreEqual(subaru.FuelConsumption, FuelConsumption);
            Assert.AreEqual(subaru.FuelCapacity, FuelCapacity);
            Assert.AreEqual(subaru.FuelAmount, 0);
        }

        [Test]
        public void Ctor_Make_ShouldNotBeNullOrEmpty()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                subaru = new("", Model, FuelConsumption, FuelCapacity);
            });



            Assert.AreEqual(CtorMakeShouldNotBeEmpty, ex.Message);

        }

        [Test]
        public void Ctor_Model_ShouldNotBeNullOrEmpty()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                subaru = new(Make, "", FuelConsumption, FuelCapacity);
            });

            Assert.AreEqual(CtorModelShouldNotBeEmpty, ex.Message);
        }

        [Test]
        public void Ctor_FuelConsumption_ShouldBeMoreThanZero()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                subaru = new(Make, Model, -1, FuelCapacity);
            });

            ArgumentException ex2 = Assert.Throws<ArgumentException>(() =>
            {
                subaru = new(Make, Model, 0, FuelCapacity);
            });

            Assert.AreEqual(CtorFuelConsumptionShouldBeMoreThanZero, ex.Message);
            Assert.AreEqual(CtorFuelConsumptionShouldBeMoreThanZero, ex2.Message);
        }

        [Test]
        public void Ctor_FuelCapacity_ShouldBeMoreThanZero()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                subaru = new(Make, Model, FuelConsumption, 0);
            });

            ArgumentException ex2 = Assert.Throws<ArgumentException>(() =>
            {
                subaru = new(Make, Model, FuelConsumption, -1);
            });

            Assert.AreEqual(CtorFuelCapacityShouldBeMoreThanZero, ex.Message);
            Assert.AreEqual(CtorFuelCapacityShouldBeMoreThanZero, ex2.Message);
        }

        [Test]
        public void Refuel_HappyPath()
        {
            double fuelAmount = FuelCapacity - 1;
            subaru.Refuel(fuelAmount);
            Assert.AreEqual(subaru.FuelAmount, fuelAmount);
        }

        [Test]
        public void Refuel_NegativeAmount_ShouldThrowException()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => { subaru.Refuel(-1); });
            ArgumentException ex2 = Assert.Throws<ArgumentException>(() => { subaru.Refuel(0); });
            Assert.AreEqual(RefuelFuelAmountShouldBeMoreThanZero, ex.Message);
            Assert.AreEqual(RefuelFuelAmountShouldBeMoreThanZero, ex2.Message);
        }

        [Test]
        public void Refuel_MoreThanCapacity_ShouldRefuelToMaxCapacity()
        {
            double fuelAmount = 70;
            subaru.Refuel(fuelAmount);
            Assert.AreEqual(subaru.FuelAmount,FuelCapacity);
        }

        [Test]
        public void Drive_HappyPath_CarDrivesCorrectly()
        {
            double distance = 100;
            double fuelNeeded = (distance / 100) * subaru.FuelConsumption;
            subaru.Refuel(50);
            double actualResult = subaru.FuelAmount - fuelNeeded;
            subaru.Drive(distance);
            Assert.AreEqual(subaru.FuelAmount, actualResult) ;

        }

        [Test]
        public void Drive_FuelNeededIsMoreThanCapacity_ShouldThrowException()
        {
            double distance = 200;
            subaru.Refuel(1);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                subaru.Drive(distance);
            });

            Assert.AreEqual(DriveFuelNeededIsMoreThanCapacityShouldThrowException,ex.Message);
        }
    }
}