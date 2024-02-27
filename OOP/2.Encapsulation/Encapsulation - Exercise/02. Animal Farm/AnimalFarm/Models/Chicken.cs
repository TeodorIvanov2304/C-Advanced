using System;

namespace AnimalFarm.Models
{
    public class Chicken
    {
        
        private const int minAge = 0;
        private const int maxAge = 15;

        private string name;
        private int age;

        internal Chicken(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                name = value;
            }
        }

        public int Age
        {
            get => age;
            
            private set
            {
                if (value < minAge || value > maxAge)
                {   
                    throw new ArgumentException($"Age should be between {minAge} and {maxAge}.");
                }
                age = value;
            }
        }

        //New syntax, we use only getter
        public double ProductPerDay => CalculateProductPerDay();

        //CalculateProductPerDay() is private, because the logic isn't needed for the outside world
        private double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }

        public override string ToString()
        {
            return $"Chicken {Name} (age {Age}) can produce {ProductPerDay} eggs per day.";
        }
    }
}
