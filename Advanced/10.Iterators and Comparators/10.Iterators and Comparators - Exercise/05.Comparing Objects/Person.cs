using System.ComponentModel;

namespace ComparingObjects
{
    public class Person:IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person? other)
        {
            //Създаваме променлива,в която ще пазим резултата. После директно й присвояваме стойността от първото сравнение, по град
            int result = this.Name.CompareTo(other.Name);
            if(result !=0)
            {
                return result;
            }
            //Ако първите са равни, презаписваме стойността на второто сравнение
            result = this.Age.CompareTo(other.Age);
            if(result !=0) 
            {
                return result;
            }

            //Ако пак са равни, направо връщаме резултата от третото сравнение
            return this.Town.CompareTo(other.Town);
        }
    }
}
