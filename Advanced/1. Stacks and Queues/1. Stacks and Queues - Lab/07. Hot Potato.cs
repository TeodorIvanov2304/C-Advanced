namespace _07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Създаване опашка, тим String която направо четем от конзолата, и сплитваме
            //!! Console.ReadLine().Split() се пише направо в скобите, които по принцип остават празни - 
            //new Queue<string>()
            Queue<string> children = new Queue<string>(Console.ReadLine().Split());

            //Четем на хвърлянията от конзолата
            int tossCount = int.Parse(Console.ReadLine());
            //Създаваме променлива, която ще пази броя на хвърлянията
            int tosses = 0;
            //Създаваме while-loop, който върти докато не остане само едно дете, т.е победителя
            while (children.Count>1)
            {   
                //При всяко завъртане, добавяме по едно дете
                tosses++;
                //Създаваме променлива, която ще пази текущото дете, което изкарваме от опашката с Dequeue()
                string childWithPotato = children.Dequeue();

                //Ако броят на хвърлянията, е равен на посочените хвърляния, изпечатваме отпадналото дете
                if (tossCount == tosses)
                {
                    tosses = 0;
                    Console.WriteLine($"Removed {childWithPotato}");
                }
                //Ако не е , го връщаме най-отзад в опашката
                else 
                {
                    children.Enqueue(childWithPotato);
                }
            }

            //Изпечатваме на конзолата победителя(последното останало дете)
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}