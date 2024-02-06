namespace BoxOfString

{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Box<string> stringBox = new Box<string>();
            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                stringBox.Add(input);
            }

            Console.WriteLine(stringBox);
        }
    }
}