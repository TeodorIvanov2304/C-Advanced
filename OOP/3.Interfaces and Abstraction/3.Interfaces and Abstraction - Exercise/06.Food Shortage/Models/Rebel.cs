using BirthdayCelebrations.Models.Interfaces;

namespace FoodShortage.Models.Interfaces
{
    public class Rebel : INameable, IAgeble,IBuyer,IFoodable
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; init; }
        public int Age { get; private set; }

        public string Group { get; private set; }

        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
