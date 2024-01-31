namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                engines.Add(CreateEngine(engineInfo));
            }
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                cars.Add(CreateCar(carInfo, engines));
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        public static Engine CreateEngine(string[] engineInfo)
        {
            Engine engine = new(engineInfo[0], int.Parse(engineInfo[1]));
            if (engineInfo.Length > 2)
            {
                //Ако има променлива на трето място в input, ще върне нова променлива(out) int displacement
                bool isDigit = int.TryParse(engineInfo[2], out int displacement);
                if (isDigit)
                {
                    engine.Displacement = displacement;
                }
                else
                {
                    engine.Efficiency = engineInfo[2];
                }

                if (engineInfo.Length > 3)
                {
                    engine.Efficiency = engineInfo[3];
                }
            }
            return engine;
        }

        public static Car CreateCar(string[] carInfo, List<Engine> engines)
        {
            string carModel = carInfo[0];
            string engineModel = carInfo[1];
            Engine engine = engines.Find(e => e.Model == engineModel);
            Car car = new Car(carModel, engine);
            if (carInfo.Length > 2)
            {
                bool isDigit = int.TryParse(carInfo[2], out int weight);
                if (isDigit)
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = carInfo[2];
                }

                if (carInfo.Length > 3)
                {
                    car.Color = carInfo[3];
                }
            }

            return car;
        }
    }
}