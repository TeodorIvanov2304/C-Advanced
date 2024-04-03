using BankLoan.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories.Contracts
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> _listOfBanks;

        public BankRepository()
        {
            _listOfBanks = new List<IBank>();
        }

        public IReadOnlyCollection<IBank> Models => _listOfBanks.AsReadOnly();

        public void AddModel(IBank model)
        {
            _listOfBanks.Add(model);
        }

        public IBank FirstModel(string name)
        {
            IBank bank = _listOfBanks.FirstOrDefault(n=>n.Name == name);
            if (bank != null)
            {
                return bank;
            }
            return null;
        }

        public bool RemoveModel(IBank model) => _listOfBanks.Remove(model);
       
    }
}
