using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int _minAge = 12;
        private const int _maxAge = 90;
        
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }
        [MyRange(_minAge, _maxAge)]
        public int Age { get; set; }
    }
}
