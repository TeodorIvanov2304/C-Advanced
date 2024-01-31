namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Car> cars = new();
            for (int i = 0; i < lines; i++)
            {
                string[] carStats = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string model = carStats[0];
                double fuelAmount = double.Parse(carStats[1]);
                double fuelConsumption1Km = double.Parse(carStats[2]);
                double travelledDistance = 0;
                Car car = new(model, fuelAmount, fuelConsumption1Km, travelledDistance);
                cars.Add(car);
                
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = commandArgs[1];
                double distance = double.Parse(commandArgs[2]);

                Car carToCheck = cars.FirstOrDefault(x => x.Model == model);
                double fuelConsumed = distance * carToCheck.FuelConsumptionPerKilometer;
                carToCheck.Drive(carToCheck, distance,fuelConsumed);

            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}