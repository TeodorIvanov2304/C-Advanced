namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        private const string CtorNameShouldThrowExceptionWhenNullOrWhitespace = "Name cannot be null or empty!";
        private RailwayStation railwayStation;
        private const string RailwayName = "Kings Cross";
        private string train = "Varna - Sofia";


        [SetUp]
        public void Setup()
        {
            railwayStation = new RailwayStation(RailwayName);

        }

        [Test]
        public void Ctor_RailwayInitializesCorrectly()
        {
            Assert.That(railwayStation, Is.Not.Null);
            Assert.That(RailwayName, Is.EqualTo(railwayStation.Name));
            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(0));
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(0));

        }

        [Test]
        public void Ctor_Name_ShouldThrowExceptionWhenNullOrWhitespace()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                RailwayStation station = new RailwayStation("");
            });
            ArgumentException ex1 = Assert.Throws<ArgumentException>(() =>
            {
                RailwayStation station = new RailwayStation(null);
            });
            Assert.That(CtorNameShouldThrowExceptionWhenNullOrWhitespace, Is.EqualTo(ex.Message));
        }

        [Test]
        public void Method_NewArrivalOnBoard_ShouldWorkCorrectly()
        {
            railwayStation.NewArrivalOnBoard("Pernk - Sofia");
            Assert.That(1, Is.EqualTo(railwayStation.ArrivalTrains.Count));
            Assert.That("Pernk - Sofia", Is.EqualTo(railwayStation.ArrivalTrains.Dequeue()));
        }

        [Test]
        public void Method_TrainHasArrived_ShouldWorkCorrectly()
        {
            string arrivalTrainInfo = "Varna - Sofia";
            string arrivalTrainInfo2 = "Istanbul - Svilengrad";
            railwayStation.NewArrivalOnBoard(arrivalTrainInfo);
            railwayStation.NewArrivalOnBoard(arrivalTrainInfo2);
            int expectedResult = 2;
            railwayStation.TrainHasArrived(arrivalTrainInfo);
            railwayStation.TrainHasArrived(arrivalTrainInfo2);
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(expectedResult));
            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(0));

        }

        [Test]
        public void Method_TrainHasArrived_IsDifferent()
        {
            string arrivalTrainInfo = "Varna - Sofia";
            string arrivalTrainInfo2 = "Istanbul - Svilengrad";

            railwayStation.NewArrivalOnBoard(arrivalTrainInfo);

            railwayStation.TrainHasArrived(arrivalTrainInfo2);
            Assert.That(railwayStation.ArrivalTrains.Peek(), Is.Not.EqualTo(arrivalTrainInfo2));
        }

        [Test]
        public void Method_TrainHasLeft_WorkingCorrectly_ReturnsTrue()
        {
            railwayStation.NewArrivalOnBoard(train);
            Assert.That(railwayStation.TrainHasArrived("Plovdiv - Sofia"),
                Is.EqualTo("There are other trains to arrive before Plovdiv - Sofia."));

            Assert.That($"{train} is on the platform and will leave in 5 minutes.",
                Is.EqualTo(railwayStation.TrainHasArrived($"{train}")));
            Assert.That(1, Is.EqualTo(railwayStation.DepartureTrains.Count));
            Assert.That($"{train}", Is.EqualTo(railwayStation.DepartureTrains.Dequeue()));
            Assert.That(0, Is.EqualTo(railwayStation.ArrivalTrains.Count));
        }

        [Test]
        public void Method_TrainHasLeft_WorkingCorrectly_ReturnsFalse()
        {
            string arrivalTrainInfo = "Varna - Sofia";
            string arrivalTrainInfo2 = "Istanbul - Svilengrad";

            railwayStation.NewArrivalOnBoard(arrivalTrainInfo);
            railwayStation.TrainHasArrived(arrivalTrainInfo);

            railwayStation.TrainHasLeft(arrivalTrainInfo2);
        }
    }
}