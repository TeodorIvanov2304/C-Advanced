namespace Fluent_Interface
{
    public class Program
    {
        static void Main(string[] args)
        {
            new Fluent().DoNothing().DoSomething().DoNothing().DoNothing();
        }
    }

    public class Fluent
    {
        public Fluent DoSomething()
        {
            return this;
        }

        public Fluent DoNothing()
        {
            return this;
        }
    }
}