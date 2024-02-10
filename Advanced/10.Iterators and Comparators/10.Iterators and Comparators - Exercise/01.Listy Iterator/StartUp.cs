namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                           .Split(' ',StringSplitOptions.RemoveEmptyEntries);
            //Директно подаваме на listy стойностите, като скипваме командата
            ListyIterator<string> listy = new ListyIterator<string>(input.Skip(1).ToList());
            while ((input[0] = Console.ReadLine()) != "END")
            {
                switch (input[0])
                {
                    case "HasNext":
                        //Направо изпечатваме true / false
                        Console.WriteLine(listy.HasNext());
                        break;
                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;
                    case "Print":
                        //Пробваме да изпринтим, ако не стане, хвърляме exception
                        try
                        {
                            listy.Print();
                        }
                        catch (InvalidOperationException ioe)
                        {

                            Console.WriteLine("Invalid Operation!");
                        }
                        break;
                    
                }
            }
        }
    }
}