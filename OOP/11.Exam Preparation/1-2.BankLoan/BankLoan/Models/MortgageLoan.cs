namespace BankLoan.Models
{
    public class MortgageLoan : Loan
    {
        private const int MortgageInterestRate  = 3;
        private const double MortgageIAmount  = 50_000;
        public MortgageLoan() : base(MortgageInterestRate, MortgageIAmount)
        {

        }
    }
}
