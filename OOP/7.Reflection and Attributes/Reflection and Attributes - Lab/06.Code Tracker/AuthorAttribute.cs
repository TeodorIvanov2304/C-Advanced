



namespace AuthorProblem
{
    //Указваме на атрибута, за кои части от класа ще искаме информация, в случая метод и клас, и му даваме труе на AllowMultiple, за да документира и двата атрибута
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}

