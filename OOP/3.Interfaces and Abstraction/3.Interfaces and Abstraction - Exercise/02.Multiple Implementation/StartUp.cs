namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();

            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);

            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);

            Citizen citizen = new Citizen("Grom", 11, "OF22123S", "91.92.22999");

        }
    }
}