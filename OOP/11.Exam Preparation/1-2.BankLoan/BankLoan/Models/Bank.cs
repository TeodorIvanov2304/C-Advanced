using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string _name;
        private int _capacity;
        private List<ILoan> _loans;
        private List<IClient> _clients;

        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            _loans = new List<ILoan>();
            _clients = new List<IClient>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                _name = value;
            }
        }

        public int Capacity
        {
            get => _capacity;
            private set
            {
                _capacity = value;
            }
        }

        //As read only?
        public IReadOnlyCollection<ILoan> Loans => _loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => _clients.AsReadOnly();

        public void AddClient(IClient Client)
        {
            if (_capacity == _clients.Count)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
            _clients.Add(Client);
        }

        public void AddLoan(ILoan loan)
        {
            _loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Name: {_name}, Type: {GetType().Name}");
            sb.Append("Clients: ");
            if (_clients.Any())
            {
                var clients = _clients.Select(n => n.Name);
                sb.Append(string.Join(", ", clients));
                
            }
            else
            {
                sb.Append("none");
            }
            sb.AppendLine();
            sb.AppendLine($"Loans: {_loans.Count}, Sum of Rates: {this.SumRates()}");

            return sb.ToString().TrimEnd();
        }

        public void RemoveClient(IClient Client)
        {
            _clients.Remove(Client);
        }

        public double SumRates()
        {   
            double sumRates = 0;
            foreach (ILoan loan in _loans)
            {
                sumRates += loan.InterestRate;
            }

            return sumRates;
        }
    }
}
