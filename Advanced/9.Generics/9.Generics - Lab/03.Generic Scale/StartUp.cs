namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {   
            //Директно подаваме двете числа 5 и 6, защото конструктора ги изисква
            EqualityScale<int> scale = new(5,6);
            //Използваме създадения метод AreEqual
            Console.WriteLine(scale.AreEqual());
        }
    }
}