using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> _vehicles;

        public VehicleRepository()
        {
            _vehicles = new List<IVehicle>();
        }
        public void AddModel(IVehicle model)
        {
            _vehicles.Add(model);
        }

        public IVehicle FindById(string identifier)
        {
            return _vehicles.FirstOrDefault(i => i.LicensePlateNumber == identifier);
        }

        public IReadOnlyCollection<IVehicle> GetAll() => _vehicles;

        public bool RemoveById(string identifier)
        {
            return _vehicles.Any(d => d.LicensePlateNumber == identifier);
        }
    }
}
