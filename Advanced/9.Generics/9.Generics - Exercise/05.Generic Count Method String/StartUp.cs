namespace GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Box<string> list = new Box<string>();

            for (int i = 0; i < lines; i++)
            {
                list.Add(Console.ReadLine());
            }

            string elementForComparsion = Console.ReadLine();
            int count = list.Counts(elementForComparsion);
            Console.WriteLine(count);
            //Съкратено
            //Console.WriteLine(list.Counts(elementForComparsion));
        }
    }
}