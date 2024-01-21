namespace _02._Line_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Пишем using, и създавем нов StreamReader, като в скобите пишем@$" тук е целият път, + окончанието на файла"
            //Това е абсолютен път, и използването му обикновено е грешка, защото се чете само на твоят компютър
            using (StreamReader reader = new StreamReader(@$"C:\Users\Garo\Desktop\C#\ReadingFromFiles\READ.txt"))
            {
                int line = 1;
                //Пускаме while-loop, който върти, докато не даде EndOfStream, т.е стигне до последния ред
                while (!reader.EndOfStream) 
                {   
                    //Изпечатваме с reader.ReadLine();
                    Console.WriteLine($"{line++}. {reader.ReadLine()}");
                }
            }
        }
    }
}
