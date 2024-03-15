using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Console.WriteLine(Assembly.GetAssembly(typeof(string)).GetTypes().Length);
            foreach (var type in Assembly.GetAssembly(typeof(Int32)).GetTypes())
            {
                Console.WriteLine(type.FullName);
            }

            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t == typeof(StartUp)).ToArray();

            foreach (var type in allTypes)
            {
                PrintAllMethodAuthors(type);
                continue;
            }
        }

        private void PrintAllMethodAuthors(Type type)
        {
            MethodInfo[] methods = type.GetMethods((BindingFlags)60);
            foreach (var method in methods)
            {
                if (!method.GetCustomAttributes().Any(a => a.GetType() == typeof(AuthorAttribute)))
                {
                    continue;
                }

                Attribute[] attributes = method.GetCustomAttributes().ToArray();

                foreach (var attr in attributes)
                {
                    if (attr is AuthorAttribute)
                    {
                        AuthorAttribute author = (AuthorAttribute)attr;
                        Console.WriteLine($"{method.Name} is written by {author.Name}");
                    }
                }
            }
        }
    }
}