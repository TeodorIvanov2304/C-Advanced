namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> parser = n => double.Parse(n);
            //Създаваме предикат, който ще добави 20% към числата
            Func<double, double> vat = p => p * 1.20;
            double[] products = Console.ReadLine()
                                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(parser)
                                .Select(vat) //Правим още един Select, и му vat предикатът
                                .ToArray();

            
            foreach (var product in products) 
            {
                Console.WriteLine($"{product:F2}");
            }

        }
    }
}