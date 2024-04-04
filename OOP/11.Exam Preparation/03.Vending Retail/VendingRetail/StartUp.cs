using System;

namespace VendingRetail
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CoffeeMat cm = new(1000, 2);
            Console.WriteLine(cm.FillWaterTank());
        }
    }
}
