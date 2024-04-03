using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> models;
        public TeamRepository()
        {
            models = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => models.AsReadOnly();

        public void AddModel(ITeam model)
        {
            models.Add(model);
        }

        public bool ExistsModel(string name) => models.Any(x => x.Name == name);

        public ITeam GetModel(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
        public bool RemoveModel(string name) => this.models.Remove(this.models.FirstOrDefault(p => p.Name == name));
    }
}
