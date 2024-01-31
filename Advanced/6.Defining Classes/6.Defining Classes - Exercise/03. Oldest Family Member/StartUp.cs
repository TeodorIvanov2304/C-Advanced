using System;
using System.Reflection;
using System.Linq;
using DefiningClasses;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();
        for (int i = 0; i < n; i++)
        {
            string[] currentPerson = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = currentPerson[0];
            int age = int.Parse(currentPerson[1]);

            Person person = new Person(name,age);
            
            family.AddMember(person);
        }

        Person oldestPerson = family.GetOldestMember();
        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}