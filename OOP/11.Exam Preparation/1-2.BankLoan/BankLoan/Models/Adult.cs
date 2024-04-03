namespace BankLoan.Models.Contracts
{
    //Accepted only with CentralBank
    public class Adult : Client
    {
        private const int InitialInterest = 4;
        public Adult(string name, string id, double income) : base(name, id, InitialInterest, income)
        {
        }

        public override void IncreaseInterest()
        {
            Interest += 2;
        }
    }
}
