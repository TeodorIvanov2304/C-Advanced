using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            this.Capacity = capacity;
            this.Turnover = 0;
            this.Stall = new List<Product>();
        }
        public int Capacity { get; set; }
        public double Turnover { get; set; }
        public List<Product> Stall { get; set; }

        public void AddProduct(Product product)
        {   
            Product productToCheck = Stall.FirstOrDefault(p=>p.Name == product.Name);
            if (Stall.Count < Capacity && productToCheck == null)
            {
                Stall.Add(product);
            }
        }

        public bool RemoveProduct(string name)
        {
            Product productToCheck = Stall.FirstOrDefault(p => p.Name == name);
            if(productToCheck!=null)
            {
                Stall.Remove(productToCheck);
                return true;
            }
            return false;
        }

        public string SellProduct(string name, double quantity)
        {   
            Product productToCheck = Stall.FirstOrDefault(x => x.Name == name);
            if (productToCheck!=null)
            {   
                double totalPrice = productToCheck.Price * quantity;
                totalPrice = Math.Round(totalPrice, 2);
                Turnover += totalPrice;
                return $"{productToCheck.Name} - {totalPrice:F2}$" ;

            }

            return "Product not found";
        }
        //public string SellProduct(string name, double quantity)
        //{
        //    if (!Stall.Any(x => x.Name == name))
        //    {
        //        return $"Product not found";
        //    }

        //    Product product = Stall.First(x => x.Name == name);
        //    double totalPrice = Math.Round(product.Price * quantity, 2);
        //    Turnover += totalPrice;

        //    return $"{product.Name} - {totalPrice:f2}$";
        //}
        public string GetMostExpensive()
        {   
            Product mostExpensive = Stall.OrderByDescending(x=>x.Price).First();
            return mostExpensive.ToString();
        }

        public string CashReport()
        {
            return $"Total Turnover: {Turnover:F2}$";
        }

        public string PriceList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Groceries Price List:");
            foreach (Product product in Stall) 
            {
                sb.AppendLine(product.ToString());
            }
            return sb.ToString().TrimStart().TrimEnd();
        }
    }
}
