namespace _00.Delegate_Example
{
    internal class Program
    {   
        //Обявяваме делегата
        public delegate int DoMath(int a, int b);
        static void Main(string[] args)
        {   
            //Single cast
            //Записваме делегата като променлива, и я приравняваме на метода Add
            //DoMath doMatch = Add;
            //После го подаваме на CW, като подаваме и стойностите , които искаме да сметне
            //Console.WriteLine(doMatch(5,6));

            //Multicast
            DoMath doMatch2 = Add;
            //Добавяме към делегата и другия метод за умножение
            doMatch2 += Multiply;
            //Когато подадем числата на doMath2 в скобите, се изпълняват и двата ме тода един след друг
            doMatch2(5, 7);
        }

        public static int Add(int a, int b)
        {
            Console.WriteLine(a + b);
            return a + b;
        }

        public static int Multiply(int a, int b)
        {
            Console.WriteLine(a * b);
            return a * b;
        }

        public static int Calculate(int a, int b)
        {
            return a * a + b * b;
        }
    }
}