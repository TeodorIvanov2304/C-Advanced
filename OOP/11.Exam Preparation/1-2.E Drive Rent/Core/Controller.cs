using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private IRepository<IUser> users;
        private IRepository<IVehicle> vehicles;
        private IRepository<IRoute> routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {

            int routeId = this.routes.GetAll().Count + 1;

            IRoute existingRoute = this.routes
                .GetAll()
                .FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint);

            if (existingRoute != null)
            {
                if (existingRoute.Length == length)
                {
                    return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
                }
                else if (existingRoute.Length < length)
                {
                    return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
                }
                else if (existingRoute.Length > length)
                {
                    existingRoute.LockRoute();
                }
            }
            IRoute newRoute = new Route(startPoint, endPoint, length, routeId);
            this.routes.AddModel(newRoute);

            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.FindById(drivingLicenseNumber);

            if (user.IsBlocked == true)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }

            IVehicle vehicle = vehicles.FindById(licensePlateNumber);

            if (vehicle.IsDamaged == true)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }

            IRoute route = routes.FindById(routeId);

            if (route.IsLocked == true)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }

            vehicle.Drive(route.Length);

            if (isAccidentHappened == true)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            IUser userToRegister = this.users.FindById(drivingLicenseNumber);
            if (userToRegister != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            userToRegister = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(userToRegister);
            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string RepairVehicles(int count)
        {
            var damagedVehicles = this.vehicles.GetAll().Where(v => v.IsDamaged == true).OrderBy(v => v.Brand).ThenBy(v => v.Model);

            int vehiclesCount = 0;

            if (damagedVehicles.Count() < count)
            {
                vehiclesCount = damagedVehicles.Count();
            }
            else
            {
                vehiclesCount = count;
            }

            var selectedVehicles = damagedVehicles.ToArray().Take(vehiclesCount);

            foreach (var vehicle in selectedVehicles)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }

            return string.Format(OutputMessages.RepairedVehicles, vehiclesCount);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType is not ("PassengerCar" or "CargoVan"))
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            IVehicle vehicleToUpload = vehicles.FindById(licensePlateNumber);

            if (vehicleToUpload != null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            if (vehicleType == "PassengerCar")
            {
                vehicleToUpload = new PassengerCar(brand, model, licensePlateNumber);
            }
            else if (vehicleType == "CargoVan")
            {
                vehicleToUpload = new CargoVan(brand, model, licensePlateNumber);
            }

            vehicles.AddModel(vehicleToUpload);

            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string UsersReport()
        {
            StringBuilder sb = new();
            sb.AppendLine("*** E-Drive-Rent ***");

            var orderedUsers = users.GetAll().OrderByDescending(r => r.Rating).ThenBy(l => l.LastName).ThenBy(f => f.FirstName);

            foreach (var user in orderedUsers)
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
