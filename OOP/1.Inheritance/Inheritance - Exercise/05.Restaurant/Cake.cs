namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double _grams = 250;
        private const double _calories = 1000;
        private const decimal _cakePrice = 5m;
        //Когато добавяме константните цени, няма нужда да добавяме от нещата, които ще заменим с константни стойности
        // в base конструктора
        public Cake(string name) : base(name, _cakePrice, _grams, _calories)
        {

        }
    }
}
