namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car(); // First Constructor
            Car secondCar = new Car(make, model, year); //Second Constructor
            Car thirdCar = new Car(make,model,year,fuelQuantity,fuelConsumption); //Third
        }
    }
}