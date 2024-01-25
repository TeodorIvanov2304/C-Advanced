namespace _00._Predicate_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Създавме предикат от int , който проверява дали едно число е отрицателно
            Predicate<int> isNegative = x => x < 0;

            //Можем да го изпечатаме, като стойността която подадваме се слага в скобите
            Console.WriteLine(isNegative(5));
            Console.WriteLine(isNegative(-5));

            List<int> numbers = new List<int> { 3, 5, -2, 10, 0, -3 };
            //Използваме метода FindAll за да намерим всички негативни числа
            List<int> negatives = numbers.FindAll(isNegative);

            Console.WriteLine(string.Join(", ",negatives));
        }
    }
}