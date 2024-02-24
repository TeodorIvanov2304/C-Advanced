namespace Restaurant
{
    public class Fish : MainDish
    {    
        //Също премахваме от конструктора grams, и заместваме в base конструктора grams с _grams
        private const double _grams = 22;
        public Fish(string name, decimal price) : base(name, price, _grams)
        {
        }
    }
}
