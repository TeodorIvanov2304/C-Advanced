namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double _grams = 22;
        public Fish(string name, decimal price) : base(name, price, _grams)
        {
        }
    }
}
