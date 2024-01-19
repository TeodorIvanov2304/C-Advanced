namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            //Създаваме речник от тип int, bool
            Dictionary<int, bool> numbers = new Dictionary<int, bool>();

            for (int i = 0; i < lines; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                //Целта е да намерим числото, което се съдържа четен брой пъти
                //Ако текущото число, вече се съдържа в речника, числото с ключ текущо число става обратното на false(true) при две срещания. При три ще стане false, и т.н

                if (numbers.ContainsKey(currentNumber))
                {
                    numbers[currentNumber] = !numbers[currentNumber];
                }
                //Ако не се съдържа, добавяме int и false
                else
                {
                    numbers.Add(currentNumber, false);
                }
            }

            foreach (var number in numbers.Keys)
            {   
                //Ако numbers от ключ number = true
                if (numbers[number])
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}