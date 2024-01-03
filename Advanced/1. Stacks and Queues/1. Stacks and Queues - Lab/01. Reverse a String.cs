namespace _1._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Четем входа 
            string input = Console.ReadLine();
            //Създаваме stack от char, в който ще пазим символите
            Stack<char> charStack = new Stack<char>();

            //Създаваме foreach, който върти по дължината на input-а
            foreach (char ch in input)
            {   
                // Push-ваме всеки един от елеметните на входа, и понеже стака слага всичко най-отгоре
                // се получава обърнат стринг
                charStack.Push(ch);
            }

            // Изпечатваме обърнатия input с while-loop
            while (charStack.Count > 0)
            {
                Console.Write(charStack.Pop());
            }
        }
    }
}