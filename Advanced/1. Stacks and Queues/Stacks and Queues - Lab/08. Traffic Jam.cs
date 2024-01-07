namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Четем от конзолата колко коли ще се пропускат наведнъж
            int numberOfCars = int.Parse(Console.ReadLine());    
            string input = "";
            //Създаваме празно Queue<string>
            Queue<string> carQueue = new Queue<string>();
            //Създаваме брояча на колите(колко са преминали)
            int carsPassed = 0;
            //Въртим while-loop, докато не получим команда End
            while ((input = Console.ReadLine()) != "end")
            {
                //Ако командата е различна от green, слагаме кола на опашката
                if (input != "green")
                {
                    carQueue.Enqueue(input);
                }
                //Ако е green, пропускаме numberOfCars брой коли
                if (input == "green")
                {
                    //Пускаме цикъл, който върти numberOfCars бр. пъти
                    for (int i = 0; i < numberOfCars; i++)
                    {   
                        //Ако колите свършат, break-ваме
                        if (carQueue.Count == 0)
                        {
                            break;
                        }
                        //Създаваме променлива, която пази името на текущата кола и я махаме от опашката
                        string carToPass = carQueue.Dequeue();
                        //Добавяме кола към брояча
                        carsPassed++;
                        //Изпечатваме името на преминалата кола
                        Console.WriteLine($"{carToPass} passed!");
                    }


                }
            }
            //Изпечатваме броя на преминалите коли
            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}