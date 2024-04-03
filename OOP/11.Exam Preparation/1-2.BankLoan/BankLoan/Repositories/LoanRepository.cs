using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> _listOfLoans;

        public LoanRepository()
        {
            _listOfLoans = new List<ILoan>();
        }
        public IReadOnlyCollection<ILoan> Models => _listOfLoans.AsReadOnly();

        public void AddModel(ILoan model)
        {
            _listOfLoans.Add(model);
        }
 
        public ILoan FirstModel(string name) 
        {
            ILoan loan = _listOfLoans.FirstOrDefault(n=>n.GetType().Name == name);

            if (loan != null)
            {
                return loan;
            }
            return null;
        }

        //Директно връща true или false, ако е премахнат заема
        public bool RemoveModel(ILoan model) => _listOfLoans.Remove(model);
       
    }
}
