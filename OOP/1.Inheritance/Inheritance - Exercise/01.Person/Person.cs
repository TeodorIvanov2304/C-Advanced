using System;

namespace Person
{
    public class Person
    {
        private string _name;
        private int _age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        //New syntax
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        //The property is set to virtual, so we can override the Age in Child class
        public virtual int Age
        {
            get => _age;
            set 
            { 
                if (value < 0)
                {   
                    //If age < 0, age = 0
                    //_age = 0;
                    throw new ArgumentException("Age cannot be negative");
                }
                _age = value; 
            }
        }

        
        

        public override string ToString()
        {
            
            return $"Name: {this.Name}, Age: {this.Age}";
        }

    }
}
