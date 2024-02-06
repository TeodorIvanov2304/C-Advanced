namespace GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Box<double> list = new Box<double>();

            for (int i = 0; i < lines; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            double elementForComparsion = double.Parse(Console.ReadLine());
            Console.WriteLine(list.CountBiggerValues(elementForComparsion));
        }
    }
}