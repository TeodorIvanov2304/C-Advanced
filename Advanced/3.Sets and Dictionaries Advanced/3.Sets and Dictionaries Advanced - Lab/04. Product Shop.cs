namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Четем речник от тип стринг, с вложен речник тип стринг, дабъл
            Dictionary<string, Dictionary<string, double>> stores = new Dictionary<string, Dictionary<string, double>>();

            string commands = "";

            while ((commands = Console.ReadLine()) != "Revision")
            {
                string[] input = commands.Split(", ");
                string store = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!stores.ContainsKey(store))
                {
                    //Инициализираме new Dictionary<string, double>()
                    stores.Add(store, new Dictionary<string, double>());
                }

                //Stores от първия ключ
                if (!stores[store].ContainsKey(product))
                {   
                    //В Stores от първи ключ добавяме двете стойности на вложения речник
                    stores[store].Add(product, 0);
                }

                //В stores от ключ 1, ключ 2 добавяме стойността(цената)
                stores[store][product] = price;
            }

            //Сортираме
            stores = stores.OrderBy(store=>store.Key).ToDictionary(d=>d.Key,d=>d.Value);

            //Когато изпечатваме с foreach, изписваме първо първият ключ, после втория
            foreach ((string store, Dictionary<string, double> products) in stores)
            {
                Console.WriteLine($"{store}->");
                //С вторият foreach слагаме в скобите първо вторият ключ, посе стойността
                foreach ((string prodcut, double price) in products)
                {
                    Console.WriteLine($"Product: {prodcut}, Price: {price}");
                }
            }
        }
    }
}