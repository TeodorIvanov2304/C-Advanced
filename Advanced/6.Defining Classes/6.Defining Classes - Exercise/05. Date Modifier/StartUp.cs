namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();
        DateModifier dateModifier = new DateModifier(firstDate, secondDate);
        //Изпечатваме property-то на dateModifier
        Console.WriteLine(dateModifier.Difference);
    }
}
