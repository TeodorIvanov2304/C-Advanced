namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();
            int users = int.Parse(Console.ReadLine());

            for (int i = 0; i < users; i++)
            {
                string user = Console.ReadLine();
                usernames.Add(user);
            }

            foreach (var user in usernames)
            {
                Console.WriteLine(user);
            }
        }
    }
}