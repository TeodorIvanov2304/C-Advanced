using ShoppingSpree.Models;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            char[] delimiters = new[] {';','='};
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleData = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            string[] productData = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            try
            {   
                //Fill list with people wit step 2
                for (int i = 0; i < peopleData.Length; i+=2)
                {   
                    //Create person with name and money and add it to the list
                    people.Add(new Person(peopleData[i], int.Parse(peopleData[i + 1])));
                }

                //Fill list with products with step 2
                for (int i = 0; i < productData.Length; i+=2)
                {
                    //Create product with name and price and add it to the list
                    products.Add(new Product(productData[i], int.Parse(productData[i + 1])));
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //Find the person with the name in tokens[0]
                var person = people.Find(p=>p.Name == tokens[0]);

                //Find the product with the name in tokens[1]
                var product = products.Find(p=>p.Name == tokens[1]);

                try
                {
                    if (person is not null && product is not null)
                    {
                        person.AddProduct(product);
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            foreach (var person in people)
            {
                Console.Write($"{person.Name} - ");
                if (person.Bag.Count == 0)
                {
                    Console.WriteLine("Nothing bought");
                    break;
                }
                Console.WriteLine(string.Join(", ",person.Bag.Select(i=>i.Name)));
            }
        }
    }
}