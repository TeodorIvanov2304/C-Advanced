namespace _01.ImplementingStackAndQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();
            list.Add(999);
            list.Add(111);
            list.Add(234);
            Console.WriteLine(list.Contains(999));
            Console.WriteLine(list.Contains(989));
            
            Console.WriteLine(list);
            list.Swap(0, 2);
            //Изпечатваме като използваме override ToString
            Console.WriteLine(list);
            Console.WriteLine("****************************");
            CustomStack stack = new CustomStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine(stack.Pop());
            Console.WriteLine("*****************************");
            //Подаваме Action на метода ForEach
            stack.ForEach(Console.WriteLine);
        }
    }
}