namespace Restaurant
{
    public class Coffee : HotBeverage
    {   
        private const double coffeeMilliliters = 50;
        private const decimal cofeePrice = 3.50m;

        //Махаме pride и milliliters от конструктора, и подаваме const coffeeMilliliters, cofeePrice на base
        //конструктора
        public Coffee(string name, double caffeine) : base(name, cofeePrice, coffeeMilliliters)
        {
            Caffeine = caffeine;
        }

        
        public double Caffeine { get; set; }
    }
}
