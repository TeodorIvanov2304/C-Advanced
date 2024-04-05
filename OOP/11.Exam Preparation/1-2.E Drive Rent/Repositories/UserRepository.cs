using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> _users;

        public UserRepository()
        {
            _users = new List<IUser>();
        }
        public void AddModel(IUser model)
        {
            _users.Add(model);
        }

        public IUser FindById(string identifier)
        {

            //public IUser FindById(string identifier) =>
            //this.users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);
            return _users.FirstOrDefault(i => i.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll() => _users.AsReadOnly();
        

        public bool RemoveById(string identifier)
        {   
            return _users.Any(d => d.DrivingLicenseNumber == identifier);
        }
    }
}
