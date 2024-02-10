namespace EqualityLogic
{
    public class Person :IComparable<Person>
    {
        private string _name;
        private int _age;

        public Person(string name, int age)
        {
            this._name = name;
            this._age = age;
        }

        public string Name
        {
            get => _name;
            private set =>_name = value;
        }
        public int Age
        {
            get => _age;
            private set => _age = value;
        }

        public int CompareTo(Person? other)
        {
            int result = this.Name.CompareTo(other.Name);
            if(result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }
            return result;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode();
        }
        public override bool Equals(object? obj)
        {   
            Person other = obj as Person;
            if (other == null)
            {
                return false;
            }
            return this.Name == other.Name && this.Age == other.Age;
        }
    }
}
