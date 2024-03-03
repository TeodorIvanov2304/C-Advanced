using BirthdayCelebrations.Models.Interfaces;
using BorderControl.Models.Interfaces;
using FoodShortage.Models.Interfaces;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable,IBirthable,INameable,IAgeble,IBuyer,IFoodable
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public string Id { get; init; }
        public string Name { get; init; }
        public int Age { get; private set; }
        public string BirthDate { get; init; }

        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
