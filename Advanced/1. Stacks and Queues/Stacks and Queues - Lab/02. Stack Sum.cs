namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Четем инпута и го запазваме в List от int
            List<int> numberList = Console.ReadLine().Split().Select(int.Parse). ToList();
            //Създаваме stack от int и добавяме директно List-a от числа
            Stack<int> numberStack = new Stack<int>(numberList);

            //Можем да го дожавим и ръчно с foreach
            //foreach (int number in numberList) 
            //{
            //    numberStack.Push(number);
            //}

            //Създаваме стринг, в който се пазят командите, и му даваме ToLower(), защото командите може да са с различна големина на буквите
            string command = Console.ReadLine().ToLower();

            //Създаваме while цикъл, в който четем команди до получаването на end
            while (command  != "end") 
            {   
                //Сплитваме командата и добавяме резултата в масив
                string[] commandArgs = command.Split().ToArray();
                //Създаваме суич-кейс, в който въртим командата
                switch(commandArgs[0])
                {   
                    //При команда add
                    case "add":
                        //Създаваме променлива, която пази първото число за добавяне
                        int firstNumber = int.Parse(commandArgs[1]);
                        //Второто число
                        int secondNumber = int.Parse(commandArgs[2]);

                        //Push-ваме двете числа към стака
                        numberStack.Push(firstNumber);
                        numberStack.Push(secondNumber);
                        break;
                    
                    //При команда remove
                    case "remove":
                        
                        //Четем броя числа, които трябва да изтрием от стака и ги запазваме в променлива
                        int numbersToRemove = int.Parse(commandArgs[1]);
                        
                        //Ако броят числа е по-малък или равен на броя числа в стака
                        if (numbersToRemove <= numberStack.Count) 
                        {   
                            //Създаваме while - цикъл, в който въртим, докато броят числа за изтриване стане 0
                            while (numbersToRemove > 0)
                            {   
                                //Трием от стака с метода Pop();
                                numberStack.Pop();
                                //Вадим 1 от числата за добавяне
                                numbersToRemove--;
                            }
                        }
                        break;
                }
                command = Console.ReadLine().ToLower();
            }

            //Създаваме променлива, в която пазим сумата на числата от стака
            int sum = numberStack.Sum();
            //Изпечатваме сумата на stack
            Console.WriteLine($"Sum: {sum}");
        }
    }
}