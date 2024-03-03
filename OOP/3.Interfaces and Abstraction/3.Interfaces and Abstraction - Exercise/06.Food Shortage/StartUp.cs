using BorderControl.Models;
using FoodShortage.Models.Interfaces;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            List<IFoodable> personsToBuy = new List<IFoodable>();
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 4)
                {
                    IFoodable citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    personsToBuy.Add(citizen);
                }
                else
                {
                    IFoodable rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    personsToBuy.Add(rebel);
                }
            }

            string peopleToBuy = "";
            while ((peopleToBuy = Console.ReadLine()) != "End")
            {   
                var citizen =  personsToBuy.Where(n=>n.Name ==  peopleToBuy).FirstOrDefault();
                if (citizen != null)
                {
                    citizen.BuyFood();
                }
            } 
            Console.WriteLine(personsToBuy.Sum(f => f.Food));
        }
    }
}