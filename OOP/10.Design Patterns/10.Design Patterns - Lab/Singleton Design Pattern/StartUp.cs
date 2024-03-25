namespace Singleton_Design_Pattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before Singleton");
            //С този синтаксис се връща релната инстанция
            UserSingleton userSingleton = UserSingleton.Instance;

            //
            UserSingleton.Instance.Username = "Dimitrichko";
            UserSingleton.Instance.Password = "Password";
            
        }
    }
}