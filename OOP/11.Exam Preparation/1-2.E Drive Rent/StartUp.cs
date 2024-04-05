namespace EDriveRent
{
    using EDriveRent.Core;
    using EDriveRent.Core.Contracts;
    using EDriveRent.Models;
    using EDriveRent.Models.Contracts;
    using EDriveRent.Repositories;
    using EDriveRent.Repositories.Contracts;
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {


            //IRepository<IVehicle> vehicles = new VehicleRepository();

            //IVehicle car = new PassengerCar("Subaru","Outback", "SS1000SG");
            //vehicles.AddModel(car);
            //Controller controller = new Controller();
            //IUser driver = new User("Gosho", "Ursulata", "191919");
            //IRoute route = new Route("Sofia", "Thesalloniki", 200, 1);


            //controller.MakeTrip("191919", "SS1000SG", "1", true);

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
