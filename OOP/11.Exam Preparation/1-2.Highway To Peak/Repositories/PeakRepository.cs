using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{

    //За да спазим принципа на loose coupling, наследяваме IRepository<IPeak>, а не IRepository<Peak>
    //Така става по-абстрактно
    public class PeakRepository : IRepository<IPeak>
    {   
        private HashSet<IPeak> allPeaks;

        public PeakRepository()
        {
            allPeaks = new HashSet<IPeak>();
        }

        public IReadOnlyCollection<IPeak> All => allPeaks;

        public void Add(IPeak model)
        {
            allPeaks.Add(model);
        }

        public IPeak Get(string name)
        {
            return allPeaks.FirstOrDefault(n => n.Name == name);
        }
    }
}
