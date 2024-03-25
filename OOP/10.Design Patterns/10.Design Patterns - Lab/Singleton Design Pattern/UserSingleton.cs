namespace Singleton_Design_Pattern
{
    public class UserSingleton
    {   
        //Правим реалнта единствена инстанция!
        private static UserSingleton instance;
        //Правим обект, който ще използваме за заключване
        private static object instanceLock = new object();
        //Правим private конструктор
        private UserSingleton()
        {
            Console.WriteLine("In constructor");
        }

        //Правим единствената инстанция, която ще е статична!
        public static UserSingleton Instance
        {
            get
            {   
                //В този if, ще влезнем само веднъж, при създаването на инстанцията
                if (instance == null)
                {   
                    //Заключваме инстанцията, така, че да има само една създадена инстанция само 1 път
                    lock (instanceLock)
                    {
                        if (instance == null)
                        {
                            instance = new UserSingleton();
                        }
                    }
                    
                }

                return instance;
            }
        }
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
