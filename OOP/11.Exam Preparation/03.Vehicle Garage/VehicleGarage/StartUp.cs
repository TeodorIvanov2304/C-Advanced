using System;
using System.Diagnostics;

namespace VehicleGarage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new("Ford", "Mustang", "CB1111BB");
            Garage garage = new(10);
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("CB1111BB",99,false);

        }
    }
}
