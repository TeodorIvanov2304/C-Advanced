namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string input = "";
            while ((input = Console.ReadLine()) != "END") 
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
                persons.Add(person);
            }

            //Тук се пази индекса на човека, по който ще сравняваме другите хора. Вадим едно от индекса, защото по условие хората трябва да започват от 1
            int referenceIndex = int.Parse(Console.ReadLine()) -1 ;
            Person reference = persons[referenceIndex];
            int equalCount = 0;
            int differentCount = 0;

            foreach (var person in persons)
            {
                if (person.CompareTo(reference) == 0)
                {
                    equalCount++;
                }
                else 
                {
                    differentCount++;
                }
            }

            if (equalCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {differentCount} {persons.Count}");
            }
        }
    }
}