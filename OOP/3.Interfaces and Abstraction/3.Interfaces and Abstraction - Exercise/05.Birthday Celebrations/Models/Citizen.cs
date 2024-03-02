using BirthdayCelebrations.Models.Interfaces;
using BorderControl.Models.Interfaces;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable,IBirthable,INameable
    {
        public Citizen(string name, int age, string id,  string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public string Id { get; init; }
        public string Name { get; set; }
        public int Age { get; private set; }
        public string BirthDate { get; init; }
    }
}
