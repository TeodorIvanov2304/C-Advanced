namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersOfPersons = int.Parse(Console.ReadLine());
            List<Person> listOfPersons = new List<Person>(numbersOfPersons);
            for (int i = 0; i < numbersOfPersons; i++)
            {
                string[] nameAndAge = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                        .ToArray();
                string name = nameAndAge[0];
                int age = int.Parse(nameAndAge[1]);
                Person newPerson = new Person(name, age);
                listOfPersons.Add(newPerson);
            }

            //Read and store the filter data
            string filter = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            //Create refference to the method GetAgeCondition
            Func<Person,bool> predicate = GetAgeCondition(filter, filterAge);

            //Create refference to the method GetFormatter
            Func<Person, string> formatter = GetFormatter(format);

            PrintPeople(listOfPersons, predicate, formatter);
        }

        static void PrintPeople(List<Person> people, Func<Person, bool> preciate, Func<Person, string> formatter)
        {
            foreach (var person in people)
            {   
                //If predicate from person == true (younger or older)
                //Check all persons, and print it with formatter refference
                if (preciate(person))
                {   
                    //Print format, when the given format = name, age or name age
                    Console.WriteLine(formatter(person));
                }
            }
        }
        static Func<Person,string> GetFormatter(string format)
        {   
            //Predicates to return specific format, baset on name, age or both
            if (format == "name")
            {   
                //If format == name, return Person.Name
                return p => $"{p.Name}";
            }
            else if (format == "age")
            {
                return p => $"{p.Age}";
            }
            else if(format == "name age")
            {
                return p => $"{p.Name} - {p.Age}";
            }

            return null;
        }

        static Func<Person, bool> GetAgeCondition(string filter, int filterAge)
        {
            if (filter == "younger")
            {   
                //Predicate to return true if person is younger
                return p => p.Age < filterAge; 
            }
            else if (filter == "older")
            {   
                //Olfer
                return p => p.Age >= filterAge;
            }

            //Return null to avoid code error, because we are missing else?
            return null;
        }
    }

    
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}