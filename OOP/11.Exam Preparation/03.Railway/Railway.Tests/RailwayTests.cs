namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    public class RailwayStationTests
    {
        private RailwayStation _station;
        private string stationName = "Hogwarts";
        private string firstTrain = "Sofia - Solun";
        private string secondTrain = "Sofia-Istanbul";
        private string thirdTrain = "Plovdiv-Svilengrad";

        [SetUp]
        public void SetUp()
        {
            _station = new RailwayStation(stationName);
        }

        [Test]
        public void Constructor_ShouldInitializeStation()
        {
            Assert.IsNotNull(_station);
        }

        [Test]
        public void Constructor_ShouldSetNameCorrectly()
        {
            Assert.AreEqual(stationName, _station.Name);
        }

        [Test]
        public void Constructor_ShouldInitializeArrivalTrains()
        {
            Assert.IsNotNull(_station.ArrivalTrains);
        }

        [Test]
        public void Constructor_ShouldInitializeDepartureTrains()
        {
            Assert.IsNotNull(_station.DepartureTrains);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\t")]

        public void SettingTheNameToNullOrWhitespace_ShouldThrowException(string invalidName)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => _station = new RailwayStation(invalidName));

            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }

        [Test]
        public void NewArrivalOnBoard_ShouldCorrectlyEnqueueTrainOnArrivalTrains()
        {
            Assert.AreEqual(0, _station.ArrivalTrains.Count);
            _station.NewArrivalOnBoard(firstTrain);
            Assert.AreEqual(1, _station.ArrivalTrains.Count);
            Assert.AreEqual(firstTrain, _station.ArrivalTrains.Peek());
        }


        [Test]
        public void TrainHasArrived_ShouldRemoveTrainFromArrivalTrainList()
        {
            _station.NewArrivalOnBoard(firstTrain);
            _station.TrainHasArrived(firstTrain);

            Assert.That(!_station.ArrivalTrains.Contains(firstTrain));
            Assert.AreEqual(0, _station.ArrivalTrains.Count);
        }

        [Test]
        public void TrainHasArrived_ShouldAddTrainToDepartureTrainList()
        {
            _station.NewArrivalOnBoard(firstTrain);
            Assert.AreEqual(0, _station.DepartureTrains.Count);
            _station.TrainHasArrived(firstTrain);

            Assert.AreEqual(firstTrain, _station.DepartureTrains.Peek());
            Assert.AreEqual(1, _station.DepartureTrains.Count);
        }

        [Test]
        public void TrainHasArrived_ShouldReturnCorrectInfoAboutDeparturingTrain()
        {
            _station.NewArrivalOnBoard(firstTrain);

            string expectedResult = $"{firstTrain} is on the platform and will leave in 5 minutes.";
            Assert.AreEqual(expectedResult, _station.TrainHasArrived(firstTrain));
        }

        [Test]
        public void TrainHasArrived_ShouldReturnCorrectInfoIfThereAreMoreArrivingTrains()
        {
            _station.NewArrivalOnBoard(firstTrain);
            _station.NewArrivalOnBoard(secondTrain);
            _station.NewArrivalOnBoard(thirdTrain);

            string expectedResult = $"There are other trains to arrive before {thirdTrain}.";
            Assert.AreEqual(expectedResult, _station.TrainHasArrived(thirdTrain));
        }

        [Test]
        public void TrainHasArrived_ShouldRemoveFirstFromArrivalTrainsAndQueueToDepartureTrains()
        {
            _station.NewArrivalOnBoard(firstTrain);
            _station.NewArrivalOnBoard(secondTrain);
            _station.TrainHasArrived(firstTrain);

            Assert.AreEqual(false, _station.ArrivalTrains.Contains(firstTrain));
            Assert.AreEqual(secondTrain, _station.ArrivalTrains.Peek());
            Assert.AreEqual(true, _station.DepartureTrains.Contains(firstTrain));
            Assert.AreEqual(firstTrain, _station.DepartureTrains.Peek());
        }

        [Test]
        public void TrainHasLeft_ShouldReturnTrue_WhenTrainIsTheOneToLeave()
        {
            _station.NewArrivalOnBoard(firstTrain);
            _station.NewArrivalOnBoard(secondTrain);
            _station.TrainHasArrived(firstTrain);
            _station.TrainHasArrived(secondTrain);

            Assert.AreEqual(true, _station.TrainHasLeft(firstTrain));
        }

        [Test]
        public void TrainHasLeft_ShouldRemoveTrainFromDepartureTrainList()
        {
            _station.NewArrivalOnBoard(firstTrain);
            _station.NewArrivalOnBoard(secondTrain);
            _station.TrainHasArrived(firstTrain);
            _station.TrainHasArrived(secondTrain);
            _station.TrainHasLeft(firstTrain);

            Assert.IsFalse(_station.DepartureTrains.Contains(firstTrain));
        }

        [Test]
        public void TrainHasLeft_ShouldReturnFalse_WhenTrainIsNotTheOneToLeave()
        {
            _station.NewArrivalOnBoard(firstTrain);
            _station.NewArrivalOnBoard(secondTrain);
            _station.TrainHasArrived(firstTrain);
            _station.TrainHasArrived(secondTrain);

            Assert.AreEqual(false, _station.TrainHasLeft(secondTrain));
        }
    }
}