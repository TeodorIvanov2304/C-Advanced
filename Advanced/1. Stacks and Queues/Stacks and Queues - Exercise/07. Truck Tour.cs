namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolPumpsCount = int.Parse(Console.ReadLine());
            Queue<int[]> pumpsAndFuel = new Queue<int[]>();
            //Queue<int, int> pumpsAndFuel2 = new Queue<int,int>(); Може да се направи и с този вариант

            for (int i = 0; i < petrolPumpsCount; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int petrol = input[0];
                int distance = input[1];

                pumpsAndFuel.Enqueue(input);

            }

            int bestRoute = 0;

            while (true)
            {
                int totalPetrol = 0;

                foreach (int[] pump in pumpsAndFuel)
                {
                    totalPetrol += pump[0];
                    int currentDistance = pump[1];

                    //Ако горивото няма да стигне, брейкваме и отиваме на следващия foreach
                    if (totalPetrol - currentDistance < 0)
                    {
                        totalPetrol = 0;
                        break;
                    }
                    //Ако е достатъчно, вадима разстоянието от горивото
                    else
                    {
                        totalPetrol -= currentDistance;
                    }

                    
                }
                //Ако горивото е достатъчно, излизаме от while
                if (totalPetrol > 0)
                {
                    break;
                }
                bestRoute++;
                //Добавяме в опашката най-отзад премахнатия pumpsAndFuel.Dequeue() най-отпред
                pumpsAndFuel.Enqueue(pumpsAndFuel.Dequeue());
            }
        
            Console.WriteLine(bestRoute);
        }
    }
}