namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            //Създавме променлива, която ще пази резултата от StringBuilder, като параметри подаваме метода името на класа, и името на филдовете, които търсим
            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }
}