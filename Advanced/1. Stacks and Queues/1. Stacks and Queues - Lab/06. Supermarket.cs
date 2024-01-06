namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Създаваме празна променлива, която ще пълним с while цикъл
            string input = "";
            //Създаваме опашка
            Queue<string> names = new Queue<string>();
            //Създваме променлива, която ще пази броя на хората
            int people = 0;

            while ((input = Console.ReadLine()) != "End") 
            {   
                //Ако входът е == Paid
                if (input == "Paid")
                {   
                    //Пускаме foreach цикъл, който върти по дължината на опашката
                    foreach (string item in names)
                    {   
                        //Изпечатваме името на човека, и след това махаме 1 човек от брояча на хора
                        Console.WriteLine($"{item}");
                        people--;
                    }
                    //Изчистваме опашката
                    names.Clear();
                }
                //Ако входът е име, го добавяме към опашката и добавяме 1 човек към брояча
                else
                {
                    names.Enqueue(input);
                    people++;
                }
            }
            //Изпечатваме броя на останалите хора (people-брояч)
            Console.WriteLine($"{people} people remaining.");
        }
    }
}