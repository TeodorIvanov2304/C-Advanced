using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> _routes;

        public RouteRepository()
        {
            _routes = new List<IRoute>();
        }
        public void AddModel(IRoute model)
        {
            _routes.Add(model);
        }

        public IRoute FindById(string identifier)
        {
            int id = int.Parse(identifier);

            return _routes.FirstOrDefault(i=>i.RouteId == id);
        }

        public IReadOnlyCollection<IRoute> GetAll() => _routes;

        public bool RemoveById(string identifier)
        {
            int id = int.Parse(identifier);
            return _routes.Any(r => r.RouteId == id);
        }
    }
}
