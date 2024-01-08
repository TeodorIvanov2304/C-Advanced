namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int totalCarsPassed = 0;
            Queue<string> cars = new Queue<string>();
            string input = Console.ReadLine();

            while (input  != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }

                int currentGreenLightDuration = greenDuration;

                while(cars.Count > 0 && currentGreenLightDuration > 0)
                {
                    string currentCar = cars.Dequeue();

                    if (currentGreenLightDuration - currentCar.Length > 0)
                    {
                        currentGreenLightDuration -= currentCar.Length;
                        totalCarsPassed++;
                        continue;
                    }

                    else if(currentGreenLightDuration + freeWindowDuration - currentCar.Length >= 0)
                    {
                        totalCarsPassed++;
                        break;
                    }

                    else
                    {
                        char hittedSymbol = currentCar[currentGreenLightDuration + freeWindowDuration];
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {hittedSymbol}.");
                        return;
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}