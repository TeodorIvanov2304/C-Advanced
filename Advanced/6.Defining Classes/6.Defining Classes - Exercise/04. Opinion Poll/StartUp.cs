using DefiningClasses;


public class StartUp
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();
        for (int i = 0; i < n; i++)
        {
            string[] currentPerson = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = currentPerson[0];
            int age = int.Parse(currentPerson[1]);

            Person person = new Person(name, age);

            persons.Add(person);
        }

        List<Person> personsMoreThan30 = persons.OrderBy(person => person.Name).ThenBy(p=>p.Age).ToList();

        foreach (var person in personsMoreThan30.Where(p=>p.Age > 30))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}