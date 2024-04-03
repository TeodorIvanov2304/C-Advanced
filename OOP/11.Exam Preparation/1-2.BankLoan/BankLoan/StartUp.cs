using BankLoan.Core;
using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using System;

namespace BankLoan
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            //Student student = new("SILATA", "121g", 1000);
            //student.IncreaseInterest();

            //Adult adult = new("Sasho", "1111HHH", 3000);
            //adult.IncreaseInterest();
            ////IBank bank = new BranchBank("Fibank");
            //Controller controller = new Controller();
            //Console.WriteLine(controller.AddBank("CentralBank", "Fibank"));
            ////Console.WriteLine(controller.AddBank("BrnchBank", "Fibank"));
            //Console.WriteLine(controller.AddLoan("StudentLoan"));
            //Console.WriteLine(controller.ReturnLoan("Fibank", "StudentLoan"));
            ////Console.WriteLine(controller.ReturnLoan("Fibank", "StudenstLoan"));
            
            //Console.WriteLine(controller.AddClient("Fibank", "Student", "Mister M", "212i", 1000));
            //Console.WriteLine(controller.AddClient("Fibank", "Adult", "Mister S", "212i", 2000));
            //Console.WriteLine(controller.FinalCalculation("Fibank"));

            //Console.WriteLine(controller.Statistics());

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
