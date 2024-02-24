using System;

namespace Animals
{   
    //We call the class abstract, when there is no implementation. Abstract class is implemented in child classes
    public abstract class Animal
    {
        private string _name;

        private int _age;

        private string _gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get => _name;
           
            set
            {   
                //Check for empty input
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid Input");
                }
                _name = value;
            }
        }
        

        public int Age
        {
            get => _age;
            set 
            {   
                //Check if age is < 0
                if (value < 0)
                {
                    throw new ArgumentException("Invalid Input");
                }

                _age = value;
            }
        }
        

        public string Gender
        {
            get => _gender;
            set 
            {   //Check if string is empty
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid Input");
                }
                _gender = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} {Age} {Gender}";
        }
        public abstract string ProduceSound();
        //public virtual void ProduceSound()
        //{

        //}
    }
}
