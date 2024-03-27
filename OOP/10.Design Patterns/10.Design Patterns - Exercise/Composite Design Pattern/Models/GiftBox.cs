using Composite_Design_Pattern.Interfaces;
using System.Text;

namespace Composite_Design_Pattern.Models
{   
    //This is the 'Composite' in our case
    public class GiftBox : GiftBase,IBoxOperations
    {
        public GiftBox(string name, decimal price)
        {
            Gifts = new List<GiftBase>();
            Name = name;
            Price = price;
        }
        public List<GiftBase> Gifts { get; set; }

        

        public void Add(GiftBase gift)
        {
            Gifts.Add(gift);
        }

        public override decimal CalculateTotalPrice()
        {
            return Price + Gifts.Sum(p=>p.CalculateTotalPrice());
        }

        public void Remove(GiftBase gift)
        {
            Gifts.Remove(gift);
        }

        public override string ToString()
        {   
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Box: {Name} costing {Price} and consisting of the following items: ");

            foreach (var gift in Gifts)
            {
                sb.AppendLine(gift.ToString());
            }

            sb.AppendLine($"Total for {Name} box: {this.CalculateTotalPrice()}");

            return sb.ToString();
        }
    }
}
