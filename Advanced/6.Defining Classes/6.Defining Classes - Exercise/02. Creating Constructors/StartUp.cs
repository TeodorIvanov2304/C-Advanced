using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
           
            //Подаваме директно стойностите на името и годините, без да правим специални променливи
            Person person2 = new Person(15);
            Person person3 = new Person("Gari", 32);

            Console.WriteLine($"{person1.Name} {person1.Age}");
            Console.WriteLine($"{person2.Name} {person2.Age}");
            Console.WriteLine($"{person3.Name} {person3.Age}");


        }
    }
}