using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }

        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }
        public int GetCount => Drinks.Count;

        public void AddDrink(Drink drink)
        {
            if (Drinks.Count < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name)
        {
            Drink drink = Drinks.FirstOrDefault(n => n.Name == name);
            if (drink != null)
            {
                Drinks.Remove(drink);
                return true;
            }
            return false;
        }

        public Drink GetLongest()
        {
            return Drinks.OrderByDescending(v=>v.Volume).First();
        }

        public Drink GetCheapest() 
        {
            return Drinks.OrderBy(p=>p.Price).First();
        }

        public string BuyDrink(string name)
        {
            return Drinks.FirstOrDefault(n => n.Name == name).ToString();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Drinks available:");
            foreach (var drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
