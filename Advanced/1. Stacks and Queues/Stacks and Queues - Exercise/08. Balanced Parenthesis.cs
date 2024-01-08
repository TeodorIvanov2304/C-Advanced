namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> chars = new Stack<char>();
            foreach (char item in input)
            {   

                //Добавяме отварящите скоби в стека
                if (item == '('
                    || item == '['
                    ||item =='{')
                {
                    chars.Push(item);
                    continue;
                }
                //Ако скобите са огледални, но има още затварящи скоби, ще излезне че са огледални. Но те не са, защото има една затваряща скоба повече, която няма да бъде добавена.За това просто добавяме скобата с push, и минаваме в крайния Else
                if (chars.Count == 0)
                {   
                    chars.Push(item);
                    break;
                }
                if (item == ')' && chars.Peek() == '(')
                {
                    chars.Pop();
                }
                else if (item == ']' && chars.Peek() == '[')
                {
                    chars.Pop();
                }
                else if (item == '}' && chars.Peek() == '{')
                {
                    chars.Pop();
                }
                
            }

            if (chars.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}