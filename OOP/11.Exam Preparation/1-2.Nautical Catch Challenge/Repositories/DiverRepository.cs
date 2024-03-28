using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver> //IRepository<T>
    {   
        //Отново създаваме лист, нищо че пропъртито е IReadOnlyCollection
        private List<IDiver> models;

        public DiverRepository()
        {
            models = new List<IDiver>();
        }
        public IReadOnlyCollection<IDiver> Models { get { return models.AsReadOnly(); } }

        public void AddModel(IDiver model)
        {
            models.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return models.FirstOrDefault(n => n.Name == name);
        }
    }
}
