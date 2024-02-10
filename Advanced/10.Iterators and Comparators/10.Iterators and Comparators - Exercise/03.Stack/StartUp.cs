namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();

            string input = "";
            string[] delimiters = { ",", " " };
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];
                if (command == "Push")
                {
                    for (int i = 1; i < inputArgs.Length; i++)
                    {
                        stack.Push(inputArgs[i]);
                    }
                }
                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException e)
                    {

                        Console.WriteLine("No elements");
                    }
                }
            }

            
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}