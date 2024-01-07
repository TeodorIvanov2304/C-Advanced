namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int queries = int.Parse(Console.ReadLine());

            for (int i = 0; i < queries; i++)
            {
                string[] command = Console.ReadLine()
                    .Split()
                    .ToArray();


                switch (command[0])
                {
                    case "1":
                        int numberToAdd = int.Parse(command[1]);
                        stack.Push(numberToAdd);
                        break;
                    case "2":
                        //Даваше runtime error, защото се опитвах да поп-на от празен стак
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }

                        break;
                    case "3":

                        if (stack.Count > 0)
                        {
                            Console.WriteLine($"{stack.Max()}");
                        }

                        break;
                    case "4":
                        if (stack.Count > 0)
                        {
                            Console.WriteLine($"{stack.Min()}");
                        }

                        break;

                }


            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}