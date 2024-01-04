namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Четем входа от конзолата
            string input = Console.ReadLine();
            //Сплитваме входа и го запазваме в масив от string
            string[] inputArgs = input.Split();
            //Създаваме Stack<string>
            Stack<string> stack = new Stack<string>();

            //Пускаме обратен for-loop, за да напълним стака в обратен ред(както е по условие)
            for (int i = inputArgs.Length - 1; i >= 0; i--)
            {
                //Пушваме inputArgs[i] в стака
                stack.Push(inputArgs[i]);
            }

            //Създаваме int променлива, която ще пази сумата и pop-ваме първата цифра
            int sum = int.Parse(stack.Pop());

            //Пускаме while-loop, който ще върти докато не се изпразни стака(stack.Count ==0)
            while (stack.Count > 0) 
            {   
                //Pop-ваме първият символ, който винаги е операция, и го запазваме в string променлива
                string operation = stack.Pop();
                //Pop-ваме втория символ, който винаги е число, и го парсваме в Int променлива
                int number = int.Parse(stack.Pop());

                //Проверяваме, дали знака е + или -
                if (operation == "+")
                {
                    sum+= number;
                }
                else 
                {
                    sum-= number;
                }
            }

            //Изпечаваме сумата
            Console.WriteLine(sum);
        }
    }
}