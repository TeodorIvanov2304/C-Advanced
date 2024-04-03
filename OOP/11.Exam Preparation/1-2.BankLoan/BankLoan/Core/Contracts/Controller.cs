using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace BankLoan.Core.Contracts
{
    public class Controller : IController
    {
        private LoanRepository _loanRepository;
        private BankRepository _bankRepository;

        public Controller()
        {
            _loanRepository = new LoanRepository();
            _bankRepository = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            if (bankTypeName is not ("BranchBank" or "CentralBank"))
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            IBank bank = null;
            if (bankTypeName == "BranchBank")
            {
                bank = new BranchBank(name);
            }
            else if (bankTypeName == "CentralBank")
            {
                bank = new CentralBank(name);
            }
            _bankRepository.AddModel(bank);
            return string.Format(OutputMessages.BankSuccessfullyAdded, bank.GetType().Name);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {

            IBank bank = _bankRepository.FirstModel(bankName);

            if (clientTypeName is not ("Adult" or "Student"))
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }

            if (clientTypeName == "Student" && _bankRepository.FirstModel(bankName).GetType().Name == "CentralBank")
            {
                return string.Format(OutputMessages.UnsuitableBank);
            }
            if (clientTypeName == "Adult" && _bankRepository.FirstModel(bankName).GetType().Name == "BranchBank")
            {
                return string.Format(OutputMessages.UnsuitableBank);
            }

            IClient client = null;

            if (clientTypeName == "Student")
            {
                client = new Student(clientName,id,income);
            }
            else if (clientTypeName == "Adult")
            {
                client = new Adult(clientName, id, income);
            }

            bank.AddClient(client);
            return string.Format(OutputMessages.ClientAddedSuccessfully, client.GetType().Name,bankName);
        }

        public string AddLoan(string loanTypeName)
        {
            if (loanTypeName is not ("MortgageLoan" or "StudentLoan"))
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            ILoan loan = null;
            //if (loanTypeName == typeof(MortgageLoan).Name)
            if (loanTypeName == "MortgageLoan")
            {
                loan = new MortgageLoan();
            }
            else if (loanTypeName == "StudentLoan")
            {
                loan = new StudentLoan();
            }
            _loanRepository.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loan.GetType().Name);
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = _bankRepository.FirstModel(bankName);
            double sumOfFunds = bank.Clients.Sum(x => x.Income) + bank.Loans.Sum(x => x.Amount);

            return string.Format($"The funds of bank {bankName} are {sumOfFunds:F2}.");
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            IBank bank = _bankRepository.FirstModel(bankName);
            ILoan loan = _loanRepository.FirstModel(loanTypeName);

            if (loan is null) //not ("StudentLoan" or "MortgageLoan"))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            bank.AddLoan(loan);
            _loanRepository.RemoveModel(loan);
            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string Statistics()
        {
            StringBuilder sb = new();

            foreach (var bank in _bankRepository.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
