namespace _04._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Четем израза от конзолата
            string expression = Console.ReadLine();
            //Създаваме променлива от тип Stack<int> 
            Stack<int> openingBrackets = new Stack<int>();

            //Пускаме for-loop, който ще върти по дължината на израза
            for (int i = 0; i < expression.Length; i++)
            {   
                //Ако i == (, пушваме индекса (i) в стака
                if (expression[i] == '(')
                {
                    openingBrackets.Push(i);
                }
                //Ако е затваряща скоба, pop-ваме индекса на отварящата скоба, и го запазваме в променлива
                if (expression[i] == ')')
                {
                    int openingBracketIndex = openingBrackets.Pop();

                    //Изпечатваме на конзолата със Substring, от запазеният индекс, с брой i - запазения индекс
                    Console.WriteLine(expression.Substring(openingBracketIndex,i-openingBracketIndex+1));
                }
            }
        }
    }
}