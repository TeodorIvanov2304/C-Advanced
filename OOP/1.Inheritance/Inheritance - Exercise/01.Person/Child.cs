using System;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {

        }

        public override int Age 
        {   
            //We are getting the age from the base class Person
            get => base.Age;

            //Cannot set the value over 15
            set
            {
                if (value>15)
                {
                    throw new ArgumentException("A child cannot be more than 15");
                }
                base.Age = value;
            }
        }
    }
}
