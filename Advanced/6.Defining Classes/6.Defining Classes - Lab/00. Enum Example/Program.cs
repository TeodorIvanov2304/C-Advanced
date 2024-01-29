namespace _00._Enum_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weekday day = Weekday.Monday;
            Console.WriteLine(day);
            //Можем да парснем енумерацията, и тя ще ни изкара стойността срещу, в случая деня
            Console.WriteLine((int)day);
            // ((Weekday)5 връща деня от седмицата, който отговаря на 5, съответно Friday
            Console.WriteLine((Weekday)5);

            //Изпозлваме метода IsWeekend, като му подаваме Weekday.Monday
            Console.WriteLine(IsWeekend(Weekday.Monday));
            //Може да се кастне Weekday към стойността на деня. Т.е (IsWeekend((Weekday)6)) връща true
            Console.WriteLine(IsWeekend((Weekday)6));

        }

        static bool IsWeekend(Weekday day) 
        {
            switch (day)
            {
                case Weekday.Monday:
                    return false;
                case Weekday.Tuesday:
                    return false;
                case Weekday.Wednesday:
                    return false;
                case Weekday.Thursday:
                    return false;
                case Weekday.Friday:
                    return false;
                case Weekday.Saturday:
                    return true;
                case Weekday.Sunday:
                    return true;
                default:
                    return false;
            }
        }
    }
}