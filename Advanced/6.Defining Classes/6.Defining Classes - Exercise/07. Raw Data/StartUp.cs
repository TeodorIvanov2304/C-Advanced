namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new();
            for (int i = 0; i < numberOfCars; i++)
            {   
                
                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"

                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                Engine engine = new(engineSpeed, enginePower);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                Cargo cargo = new(cargoWeight, cargoType);
                List<Tires> tires = new(4);
               
                double tire1Pressure = double.Parse(carInfo[5]);
                int tire1Year = int.Parse(carInfo[6]);
                Tires tire1 = new(tire1Pressure, tire1Year);
                tires.Add(tire1);

                double tire2Pressure = double.Parse(carInfo[7]);
                int tire2Year = int.Parse(carInfo[8]);
                Tires tire2 = new(tire2Pressure, tire2Year);
                tires.Add(tire2);

                double tire3Pressure = double.Parse(carInfo[9]);
                int tire3Year = int.Parse(carInfo[10]);
                Tires tire3 = new(tire3Pressure, tire3Year);
                tires.Add(tire3);

                double tire4Pressure = double.Parse(carInfo[11]);
                int tire4Year = int.Parse(carInfo[12]);
                Tires tire4 = new(tire4Pressure, tire4Year);
                tires.Add(tire4);

                Car newCar = new(carModel,engine,cargo,new List<Tires>(4));
                for (int j = 0; j < tires.Count; j++)
                {
                    newCar.Tires.Add(tires[j]);
                }
                cars.Add(newCar);
            }

            string type = Console.ReadLine();

            if (type == "fragile")
            {
                foreach (var car in cars.Where(t=>t.Cargo.Type == "fragile"))
                {
                    int count = 0;
                    foreach (var tire in car.Tires)
                    {
                        if (tire.Pressure < 1)
                        {
                            count++;
                        }
                    }

                    if (count>0)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else
            {
                foreach (var car in cars.Where(t => t.Engine.Power>250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}