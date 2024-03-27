using Composite_Design_Pattern.Models;

namespace Composite_Design_Pattern
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            SingleGift toyTruck = new("Toy Truck", 9.99m);
            SingleGift toySoldier = new("Toy Soldier", 12.50m);
            SingleGift toySpider = new("Toy Spider", 11.10m);

            GiftBox plainBox = new GiftBox("Plain box", 0m);
            plainBox.Add(toyTruck);
            plainBox.Add(toySoldier);

            
            GiftBox shinyBox = new ("Shiny",10m);
            shinyBox.Add(plainBox);
            Console.WriteLine(shinyBox);

        }
    }
}