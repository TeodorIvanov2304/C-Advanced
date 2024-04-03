namespace BankLoan.Models
{
    public class StudentLoan : Loan
    {
        private const int StudentInterestRate = 1;
        private const double StudentAmount = 10_000;
        public StudentLoan() : base(StudentInterestRate, StudentAmount)
        {

        }
    }
}
